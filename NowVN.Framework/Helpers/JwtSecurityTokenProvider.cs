﻿using Microsoft.IdentityModel.Tokens;
using NowVN.Framework.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NowVN.Framework.Helpers
{
    public class JwtSecurityTokenProvider
    {
        public ExtensionSettings extensionSettings;

        public JwtSecurityTokenProvider(ExtensionSettings extensionSettings)
        {
            this.extensionSettings = extensionSettings;
        }

        public string createAccesstoken(Customer customer)
        {
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(extensionSettings.appSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.UserId, customer.Id),
                    new Claim(ClaimTypes.Username ,customer.Username)
                }),

                Expires = DateTime.UtcNow.AddHours(extensionSettings.appSettings.TokenExpireTime),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),

            };

            var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
        

    }
}
