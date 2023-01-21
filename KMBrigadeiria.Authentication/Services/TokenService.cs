﻿using KMBrigadeiria.Authentication.Models;
using KMBrigadeiria.Authentication.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KMBrigadeiria.Authentication.Services
{
    public class TokenService : ITokenService
    {
        public Token CreateToken(IdentityUser<int> user, string role)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            Claim[] userClaims = new Claim[]
            {
                new Claim("username", user.UserName),
                new Claim("id", user.Id.ToString()),
                new Claim(ClaimTypes.Role, role)
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("0j928jef09823jf9i0djf09asijfpjsnd0f1n9248un08rn3984n3hjnxoif")
                );

            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                    claims: userClaims,
                    signingCredentials: credentials,
                    expires: DateTime.UtcNow.AddHours(1)
                );

            string tokenValue = tokenHandler.WriteToken(token);

            return new Token(tokenValue);
        }
    }
}
