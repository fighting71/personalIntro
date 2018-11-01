

> ID Token的主要构成部分

1. 	iss = Issuer Identifier：必须。提供认证信息者的唯一标识。一般是一个https的url（不包含querystring和fragment部分）。
1. 	sub = Subject Identifier：必须。iss提供的EU的标识，在iss范围内唯一。它会被RP用来标识唯一的用户。最长为255个ASCII个字符。
1. 	aud = Audience(s)：必须。标识ID Token的受众。必须包含OAuth2的client_id。
1. 	exp = Expiration time：必须。过期时间，超过此时间的ID Token会作废不再被验证通过。
1. 	iat = Issued At Time：必须。JWT的构建的时间。
1. 	auth_time = AuthenticationTime：EU完成认证的时间。如果RP发送AuthN请求的时候携带max_age的参数，则此Claim是必须的。
1. 	nonce：RP发送请求的时候提供的随机字符串，用来减缓重放攻击，也可以来关联ID Token和RP本身的Session信息。
1. 	acr = Authentication Context Class Reference：可选。表示一个认证上下文引用值，可以用来标识认证上下文类。
1. 	amr = Authentication Methods References：可选。表示一组认证方法。
1. 	azp = Authorized party：可选。结合aud使用。只有在被认证的一方和受众（aud）不一致时才使用此值，一般情况下很少使用。


----------
> start —— Config

## partial1-IdentityResource ##

	public static IEnumerable<IdentityResource> GetIdentityResources()
    {
        //Requested scope not allowed: custom.profile
        var customProfile = new IdentityResource(
            name: "custom.profile",//标识名 - 唯一
            displayName: "Custom profile",//显示名
            claimTypes: new[] {"role"});//to be continue

        return new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            customProfile
        };
    }

intro:Models a user identity resource.

explain:对用户标识资源进行建模。

understand:即IdentityResource定义的为用户包含信息(信息载体协议)

## partial2-ApiResource ##

	public static IEnumerable<ApiResource> GetApiResources()
    {

        return new[]
        {
             new ApiResource(
                    name: "api1", //同上...
                    displayName: "My API",//同上...
                    claimTypes: new List<string>() {JwtClaimTypes.Role})
        };

    }

intro:Models a web API resource.

explain:为web API资源建模

understand: 由于is4存在多个协议约定 当api使用is4时  需要先确定好协议 用来确定api访问的是is4的那个资源 

## partial3-client ##
		public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                new Client()
                {
                    ClientId = "client",//标识名 - 唯一
                    AllowedGrantTypes = GrantTypes.ClientCredentials,//grantType 指定允许的授予类型(授权码、隐式、混合、资源所有者、客户凭证的合法组合)。

                    ClientSecrets =//客户端机密——仅与需要机密的流相关
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes =//指定允许客户端请求的api范围。如果为空，客户端不能访问任何范围
                    {
                        "api1", IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                }
            };
		}

intro:Models an OpenID Connect or OAuth2 client

explain:为web API资源建模

understand:添加client客户端 根据AllowedScopes 访问不同的api

## partial-TestUser ##
		public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "alice",
                    Password = "password",
                    Claims = new List<Claim>() {new Claim(JwtClaimTypes.Role, "superadmin")}
                }
            };
        }

emm... 测试用户 不详解。


----------

> Server - Startup

        public void ConfigureServices(IServiceCollection services)
        {
            // configure identity server with in-memory stores, keys, clients and scopes
            services
                .AddIdentityServer()//添加is
                .AddDeveloperSigningCredential()//设置为临时凭证
                
                //添加本地资源  (向ioc容器中添加对象)
                .AddInMemoryIdentityResources(Config.GetIdentityResources())//添加内存_用户建模资源
                .AddInMemoryApiResources(Config.GetApiResources())//添加api资源

                //将client 添加到唯一注入
                //并添加其他Transient依赖
                .AddInMemoryClients(Config.GetClients())//添加内存_客户端

                .AddTestUsers(Config.GetUsers())//添加测试用户


                .AddProfileService<CustomProfileService>()//添加概要服务
                .AddResourceOwnerValidator<CustomResourceOwnerPasswordValidator>();//添加资源验证对象
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            loggerFactory.AddConsole(LogLevel.Debug);//添加日志输出

            app.UseIdentityServer();//使用is

        } 

> Api - Start

		public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);//设置兼容版本

            //添加中间件
            services
                .AddMvcCore()//添加mvc
                .AddAuthorization()//添加授权认证
                .AddJsonFormatters();//添加json格式处理

            services
                .AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "http://localhost:5000";//令牌签发人的基本地址
                    options.RequireHttpsMetadata = false;//是否使用https
                    options.ApiName = "api1";//用于针对内省端点进行身份验证的API资源的名称
                });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //启用授权认证
            app.UseAuthentication();

            app.UseMvc();
        }


----------
> IResourceOwnerPasswordValidator

自定义 Resource owner password 验证器

根据 client 的 AllowedGrantTypes进行调用

	public class CustomResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        /// <summary>
        /// 这里为了演示我们还是使用TestUser作为数据源，
        /// 正常使用此处应当传入一个 用户仓储 等可以从
        /// 数据库或其他介质获取我们用户数据的对象
        /// </summary>
        private readonly TestUserStore _users;

        private readonly ISystemClock _clock;

        public CustomResourceOwnerPasswordValidator(TestUserStore users, ISystemClock clock)
        {
            _users = users;
            _clock = clock;
        }

        /// <summary>
        /// 验证
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            //此处使用context.UserName, context.Password 用户名和密码来与数据库的数据做校验
            if (_users.ValidateCredentials(context.UserName, context.Password))
            {
                var user = _users.FindByUsername(context.UserName);

                //验证通过返回结果 
                //subjectId 为用户唯一标识 一般为用户id
                //authenticationMethod 描述自定义授权类型的认证方法 
                //authTime 授权时间
                //claims 需要返回的用户身份信息单元 此处应该根据我们从数据库读取到的用户信息 添加Claims 如果是从数据库中读取角色信息，那么我们应该在此处添加
                context.Result = new GrantValidationResult(
                    user.SubjectId ?? throw new ArgumentException("Subject ID not set", nameof(user.SubjectId)),
                    OidcConstants.AuthenticationMethods.Password, _clock.UtcNow.UtcDateTime,
                    user.Claims);
            }
            else
            {
                //验证失败
                context.Result =
                    new GrantValidationResult(TokenRequestErrors.InvalidGrant, "invalid custom credential");
            }

            return Task.CompletedTask;
        }
    }

----------
## 相关引用 ##

> Server

	McApp.AppCore.IdentityServer4

> api

	IdentityServer4.AccessTokenValidation
	Microsoft.AspNetCore.App
	Microsoft.VisualStudio.Web.CodeGeneration.Design


----------
## DOCUMENTS ##

> grandType

		//隐含
        //隐式授权类型针对基于浏览器的应用程序进行了优化。仅用于用户身份验证（服务器端和JavaScript应用程序），或身份验证和访问令牌请求（JavaScript应用程序）。

        // 在隐式流程中，所有令牌都通过浏览器传输，因此不允许使用刷新令牌等高级功能。
        // public const string Implicit = "implicit";


        //混合流是隐式和授权代码流的组合 - 它使用多种授权类型的组合，最典型的是。code id_token

        // 在混合流中，身份令牌通过浏览器通道传输，并包含签名协议响应以及其他工件（如授权代码）的签名。这减轻了许多适用于浏览器通道的攻击。成功验证响应后，反向通道用于检索访问和刷新令牌。

        // 这是希望检索访问令牌（也可能是刷新令牌）的本机应用程序的推荐流程，用于服务器端Web应用程序和本机桌面/移动应用程序。
        // public const string Hybrid = "hybrid";


        //授权代码流最初由OAuth 2指定，并提供了一种在反向通道上检索令牌而不是浏览器前端通道的方法。它还支持客户端身份验证。

        // 虽然这种授权类型本身是受支持的，但通常建议您将其与身份令牌结合使用，将其转换为所谓的混合流。混合流程为您提供重要的额外功能，如签名协议响应。
        // public const string AuthorizationCode = "authorization_code";


        //客户端凭证
        //这是最简单的授权类型，用于服务器到服务器通信 - 始终代表客户端而不是用户请求令牌。

        //使用此授权类型，您可以向令牌端点发送令牌请求，并获取代表客户端的访问令牌。客户端通常必须使用其客户端ID和密钥对令牌端点进行身份验证。
        // public const string ClientCredentials = "client_credentials";


        //资源所有者密码
        //资源所有者密码授予类型允许通过将用户的名称和密码发送到令牌端点来代表用户请求令牌。这就是所谓的“非交互式”身份验证，通常不推荐使用。

        // 某些遗留或第一方集成方案可能有原因，其中此授权类型很有用，但一般建议使用隐式或混合的交互式流来代替用户身份验证。

        // 有关如何使用它的示例，请参阅资源所有者密码快速入门。您还需要提供用户名/密码验证的代码，可以通过实现IResourceOwnerPasswordValidator接口来提供。您可以在此处找到有关此界面的更多信息。
        // public const string ResourceOwnerPassword = "password";


[http://docs.identityserver.io/en/release/topics/grant_types.html](http://docs.identityserver.io/en/release/topics/grant_types.html "官方文档")

----------

## words ##

> grant

	vt. 授予；允许；承认
	vi. 同意
	n. 拨款；[法] 授予物

> agent

	n. 代理人，代理商；药剂；特工
	vt. 由…作中介；由…代理
	adj. 代理的

----------
author:monster

since:10/25/2018 9:08:52 AM 

direction:study