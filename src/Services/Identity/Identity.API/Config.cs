using IdentityServer4.Models;
using IdentityServer4.Test;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.API
{
    public static class Config
    {
        public static List<ApiResource> GetApiResources() => new List<ApiResource>
        {
            new ApiResource("contractorders","Contract Orders API")
        };

        public static List<Client> GetClients() => new List<Client>
        {
            new Client {
                ClientId = "contractorderingswaggerui",
                ClientName = "Contract Ordering Swagger UI",

                AllowedGrantTypes = GrantTypes.Implicit,

                RedirectUris = { "http://localhost:3900/swagger/oauth2-redirect.html" },
                PostLogoutRedirectUris = { "http://localhost:3900/swagger/" },

                AllowAccessTokensViaBrowser = true,
                AllowedScopes={ "contractorders" }
            }
        };

        public static IEnumerable<IdentityResource> GetIdentityResources() => new List<IdentityResource>
        {
        };
    }
}
