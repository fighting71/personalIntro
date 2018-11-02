using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace DemoServer
{
    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            //Requested scope not allowed: custom.profile
            var customProfile = new IdentityResource(
                name: "custom.profile", //标识名
                displayName: "Custom profile", //显示名
                claimTypes: new[] {"test"}); //其他信息标识

            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                customProfile
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new[]
            {
                new ApiResource(
                    name: "api1",
                    displayName: "My API",
                    claimTypes: new List<string>() {JwtClaimTypes.Role})
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                new Client()
                {
                    ClientId = "client", //标识名 - 唯一
                    AllowedGrantTypes = GrantTypes.ClientCredentials, //grantType 指定允许的授予类型(授权码、隐式、混合、资源所有者、客户凭证的合法组合)。

                    ClientSecrets = //客户端机密——仅与需要机密的流相关
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = //指定允许客户端请求的api范围。如果为空，客户端不能访问任何范围
                    {
                        "api1", IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                },
                new Client
                {
                    ClientId = "ro.client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword ,
                    //设置OfflineAccess 时 此处必须设置为true 默认 false
                    //ScopeValidator:Error: offline_access is not allowed for this client: ro.client
//                    AllowOfflineAccess = true,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes =
                    {
                        "api1", IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile, "custom.profile"
                        //如果想带有RefreshToken，那么必须设置：StandardScopes.OfflineAccess
//                        //如果是Client Credentials模式不支持RefreshToken的，就不需要设置OfflineAccess

                        ,IdentityServerConstants.StandardScopes.OfflineAccess
                    },
                    //设置token的生命周期 s  默认为1小时
                    AccessTokenLifetime = 60
                    //AccessTokenLifetime = 3600, //AccessToken的过期时间， in seconds (defaults to 3600 seconds / 1 hour)
                    //AbsoluteRefreshTokenLifetime = 60, //RefreshToken的最大过期时间，in seconds. Defaults to 2592000 seconds / 30 day
//                    ,RefreshTokenUsage = TokenUsage.OneTimeOnly,   //默认状态，RefreshToken只能使用一次，使用一次之后旧的就不能使用了，只能使用新的RefreshToken
                    //RefreshTokenUsage = TokenUsage.ReUse,   //可重复使用RefreshToken，RefreshToken，当然过期了就不能使用了
                },
                new Client
                {
                    ClientId = "mvc",
                    ClientName = "MVC Client",
                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    RedirectUris = {"http://localhost:5002/signin-oidc"},
                    PostLogoutRedirectUris = {"http://localhost:5002/signout-callback-oidc"},

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api1"
                    },
                    AllowOfflineAccess = true
                }
            };
        }

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
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "bob",
                    Password = "password",

                    Claims = new List<Claim>() {new Claim(JwtClaimTypes.Role, "admin")},
                }
            };
        }
    }
}