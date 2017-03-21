﻿using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNet.Identity;

namespace EasyFlights.Services.Infrastracture.Account
{
    public class ExternalLoginData
    {
        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }

        public string UserName { get; set; }

        public static ExternalLoginData FromIdentity(ClaimsIdentity identity)
        {
            Claim providerKeyClaim = identity?.FindFirst(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(providerKeyClaim?.Issuer) || string.IsNullOrEmpty(providerKeyClaim.Value))
            {
                return null;
            }

            if (providerKeyClaim.Issuer == ClaimsIdentity.DefaultIssuer)
            {
                return null;
            }

            return new ExternalLoginData
            {
                LoginProvider = providerKeyClaim.Issuer,
                ProviderKey = providerKeyClaim.Value,
                UserName = identity.FindFirstValue(ClaimTypes.Name)
            };
        }

        public IList<Claim> GetClaims()
        {
            IList<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, ProviderKey, null, LoginProvider));

            if (UserName != null)
            {
                claims.Add(new Claim(ClaimTypes.Name, UserName, null, LoginProvider));
            }

            return claims;
        }
    }
}
