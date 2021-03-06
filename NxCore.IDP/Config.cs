// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace NxCore.IDP
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            { 
                new IdentityResources.OpenId(),
                 new IdentityResources.Profile(),
                 new IdentityResources.Address(),
                 new IdentityResource(
                     "roles", "Your roles(s)",
                     new List<string>(){ "role"}
                     ),
                 new IdentityResource(
                     "country", "The country you re living in",
                     new List<string>(){ "country"}
                     ),
                 new IdentityResource(
                     "subscriptionlevel", "Your subscripton level",
                     new List<string>(){ "subscriptionlevel" }
                     ),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            { 
            };
        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[]
            {
                // api requires role in token
                 new ApiResource("nxcoreapi", "NxCore Demo API", new List<string>(){ "role" })
            };

        public static IEnumerable<Client> Clients =>
            new Client[] 
            {
            /*
             * Once we have some clients:
             * AllowedScopes = {
             * IdentityServerConstants.StandardScopes.OpenId,
             * IdentityServerConstants.StandardScopes.Profile
             * IdentityServerConstants.StandardScopes.Adress,
             * -------- these are non standard below -------
             * "roles",
             * "imagegalleryapi"
             * "country",
             * "subscriptionlevel"
             * }
             * **/
            };
    }
}