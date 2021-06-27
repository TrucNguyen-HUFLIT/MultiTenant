using System.Collections.Generic;
using System.Security.Claims;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace MultiTenant.Login
{
    internal class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client> //Tenant
            {
                //new Client
                //{
                //    ClientId = "oauthClient",
                //    ClientName = "Example client application using client credentials",
                //    AllowedGrantTypes = GrantTypes.ClientCredentials,
                //    ClientSecrets = new List<Secret> {new Secret("SuperSecretPassword".Sha256())}, // change me!
                //    AllowedScopes = new List<string> {"api1.read", "api1.write"}
                //},
                new Client
                {
                    ClientId = "mgmt",
                    ClientName = "Tenant Management",
                    ClientSecrets = new List<Secret> {new Secret("SuperSecretPassword".Sha256())}, // change me!
                    
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = new List<string> {"https://localhost:5001/signin-oidc"},
                    FrontChannelLogoutUri = "https://localhost:5001/signout-oidc",
                    PostLogoutRedirectUris = new List<string>  { "https://localhost:5001/signout-callback-oidc" },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        //IdentityServerConstants.StandardScopes.Email,
                        "role",
                    },

                    RequirePkce = true,
                    AllowPlainTextPkce = false
                },
                 new Client
                 {
                    ClientId = "tenant",
                    ClientName = "Main Tenant",
                    ClientSecrets = new List<Secret> {new Secret("SuperSecretPassword".Sha256())}, // change me!
                    
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = new List<string> {"https://localhost:5002/signin-oidc"},
                    FrontChannelLogoutUri = "https://localhost:5002/signout-oidc",
                    PostLogoutRedirectUris = new List<string>  { "https://localhost:5002/signout-callback-oidc" },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        //IdentityServerConstants.StandardScopes.Email,
                        "role",
                    },

                    RequirePkce = true,
                    AllowPlainTextPkce = false
                },
                new Client
                {
                    ClientId = "tenant1",
                    ClientName = "Tenant 1",
                    ClientSecrets = new List<Secret> {new Secret("SuperSecretPassword".Sha256())}, // change me!
                    
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = new List<string> {"https://tenant1.localhost:5002/signin-oidc"},
                    FrontChannelLogoutUri = "https://tenant1.localhost:5002/signout-oidc",
                    PostLogoutRedirectUris = new List<string>  { "https://tenant1.localhost:5002/signout-callback-oidc" },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        //IdentityServerConstants.StandardScopes.Email,
                        "role",
                    },

                    RequirePkce = true,
                    AllowPlainTextPkce = false
                },
            };
        }
    }

    internal class Resources
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                //new IdentityResources.Email(),
                new IdentityResource
                {
                    Name = "role",
                    UserClaims = new List<string> {"role"}
                }
            };
        }

        //public static IEnumerable<ApiResource> GetApiResources()
        //{
        //    return new[]
        //    {
        //        new ApiResource
        //        {
        //            Name = "api1",
        //            DisplayName = "API #1",
        //            Description = "Allow the application to access API #1 on your behalf",
        //            Scopes = new List<string> {"api1.read", "api1.write"},
        //            ApiSecrets = new List<Secret> {new Secret("ScopeSecret".Sha256())}, // change me!
        //            UserClaims = new List<string> {"role"}
        //        }
        //    };
        //}

        //public static IEnumerable<ApiScope> GetApiScopes()
        //{
        //    return new[]
        //    {
        //        new ApiScope("api1.read", "Read Access to API #1"),
        //        new ApiScope("api1.write", "Write Access to API #1")
        //    };
        //}
    }

    internal class Users
    {
        public static List<TestUser> Get()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "truc",
                    Password = "Password123!",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Email, "ngoctruc020100@gmail.com"),
                        new Claim(JwtClaimTypes.Role, "admin"),
                        new Claim(JwtClaimTypes.ClientId, "mgmt")
                    }
                },

                new TestUser
                {
                    SubjectId = "2",
                    Username = "huy",
                    Password = "Password123!",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Email, "giahuyngh16@gmail.com"),
                        new Claim(JwtClaimTypes.Role, "admin"),
                        new Claim(JwtClaimTypes.ClientId, "mgmt")
                    }
                },

                new TestUser
                {
                    SubjectId = "3",
                    Username = "tam",
                    Password = "Password123!",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Email, "minhtam@gmail.com"),
                        new Claim(JwtClaimTypes.Role, "customer"),
                        new Claim(JwtClaimTypes.ClientId, "tenant")
                    }
                },
                new TestUser
                {
                    SubjectId = "4",
                    Username = "tri",
                    Password = "Password123!",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Email, "tri@gmail.com"),
                        new Claim(JwtClaimTypes.Role, "customer"),
                        new Claim(JwtClaimTypes.ClientId, "tenant1")
                    }
                },
            };
        }
    }
}
