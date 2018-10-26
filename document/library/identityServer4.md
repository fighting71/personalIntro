

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

## words ##

> grand

	vt. 授予；允许；承认
	vi. 同意
	n. 拨款；[法] 授予物

> agent

	n. 代理人，代理商；药剂；特工
	vt. 由…作中介；由…代理
	adj. 代理的

----------
> start

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

----------
author:monster

since:10/25/2018 9:08:52 AM 

direction:study