using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using NewsModule.Business.Security;
using System.Text;

namespace NewsModule.Business.Configurations
{
    public static class SecurityInjection
    {
        public static IServiceCollection AddSecurityInjection(this IServiceCollection services, IConfiguration configuration)
        {
            Security.TokenOptions tokenOptions = configuration.GetSection("TokenOptions").Get<Security.TokenOptions>();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey));
            var signinCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = securityKey
                    };
                });

            services.AddSingleton<IJWTHelper, JWTHelper>();
            return services;
        }
    }
}
