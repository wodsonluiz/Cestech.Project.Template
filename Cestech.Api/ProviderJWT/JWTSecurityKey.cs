﻿using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Cestech.Api.ProviderJWT
{
    public class JWTSecurityKey
    {
        public static SymmetricSecurityKey Create(string secret)
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
        }
    }
}
