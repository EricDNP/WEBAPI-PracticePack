using System.Text;
using Application.Models;
using Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;
using System.Text.Json;
using Domain.Enums;

namespace Infrastructure.Configuration
{
    public static class AuthenticationManager
    {
        public static IServiceCollection ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            int.TryParse(configuration["TokenSettings:Expiration"], out int expiration);

            var authenticationSettings = new AuthenticationSettings()
            {
                Secret = configuration["TokenSettings:JwtSecret"],
                Issuer = configuration["TokenSettings:Issuer"],
                Audience = configuration["TokenSettings:Audience"],
                Expiration = expiration
            };

            var encodedKey = Encoding.UTF8.GetBytes(authenticationSettings.Secret ?? "");

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = false,
                IssuerSigningKey = new SymmetricSecurityKey(encodedKey)
            };

            services.AddSingleton(authenticationSettings);
            services.AddSingleton(tokenValidationParameters);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = tokenValidationParameters;
                });

            return services;
        }

        public static UserAuth? GetUserInfoFromHeader(string authHeader, IServiceProvider provider)
        {
            if (!string.IsNullOrEmpty(authHeader) && authHeader.ToLower().StartsWith("bearer "))
            {
                var token = authHeader["bearer ".Length..].Trim();
                return GetUserInfo(token, provider);
            }

            return null;
        }

        public static UserAuth? GetUserInfo(string? token, IServiceProvider provider)
        {
            var handler = new JwtSecurityTokenHandler();
            var validationParemetrs = provider.GetRequiredService<TokenValidationParameters>();

            try
            {
                var principal = handler.ValidateToken(token, validationParemetrs, out _);
                var accessor = provider.GetRequiredService<IHttpContextAccessor>();

                AccessUser(principal, accessor);

                return GetUserFromClaims(principal);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en TRY");
                Console.WriteLine("Message: " + ex.Message);
                Console.WriteLine("Exception: " + ex.InnerException);

                return null;
            }
        }

        public static void AccessUser(ClaimsPrincipal claims, IHttpContextAccessor accessor)
        {
            if (accessor.HttpContext != null)
            {
                accessor.HttpContext.User = claims;
            }
            else
            {
                var context = new DefaultHttpContext();
                context.User = claims;
                accessor.HttpContext = context;
            }
        }

        public static UserAuth GetUserFromClaims(ClaimsPrincipal claims)
        {
            Guid.TryParse(claims.FindFirst(ClaimTypes.NameIdentifier)?.Value, out Guid id);

            var role = JsonSerializer.Deserialize<UserRole>(claims.FindFirst(ClaimTypes.Role)?.Value ?? "");

            return new UserAuth()
            {
                Id = id,
                Name = claims.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                Email = claims.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                Role = role
            };
        }
    }
}
