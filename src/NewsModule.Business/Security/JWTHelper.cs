using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NewsModule.DTOs.UserDtos;
using NewsModule.Entities.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NewsModule.Business.Security
{
    public class JWTHelper : IJWTHelper
    {
        private readonly TokenOptions _tokenOptions;
        public JWTHelper(IConfiguration configuration)
        {
            _tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }
        public TokenDto CreateJwtToken(User user)
        {
            var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                    new Claim(ClaimTypes.Email,user.Email)
                };
            if (user.Roles != null)
            {
                claims.AddRange(collection: user.Roles.Select(p => new Claim(ClaimTypes.Role, p.RoleName)));
            }


            // Token Operations
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.SecurityKey));
            var signinCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
            var jwt = new JwtSecurityToken(
                audience: _tokenOptions.Audience,
                issuer: _tokenOptions.Issuer,
                expires: DateTime.UtcNow.AddMinutes(_tokenOptions.ExpiresMinute),
                notBefore: DateTime.UtcNow,
                signingCredentials: signinCredentials,
                claims: claims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            return new TokenDto(jwtSecurityTokenHandler.WriteToken(jwt));
        }
    }
}
