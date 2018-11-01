using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4;
using IdentityServer4.Models;

namespace LimitServer
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new[]
            {
                new ApiResource(
                    name: "user_api",
                    displayName: "user information",
                    claimTypes: new string[]
                    {
                    }
                ),
            };
        }

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

        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                new Client()
                {
                    ClientId = "mvc",
                    ClientName = "MVC Client",
                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    RedirectUris           = { "http://localhost:5002/signin-oidc" },
                    PostLogoutRedirectUris = { "http://localhost:5002/signout-callback-oidc" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api1"
                    },
                    AllowOfflineAccess = true
                },
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new[]
            {
                new IdentityResource(name: "user", displayName: "idr_user", claimTypes: new string[]
                {
                }),
            };
        }
    }
}