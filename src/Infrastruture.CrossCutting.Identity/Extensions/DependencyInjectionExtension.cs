using Application.DTO.Standard;
using Infrastruture.CrossCutting.Identity.Configuration;
using Infrastruture.CrossCutting.Identity.Context;
using Infrastruture.CrossCutting.Identity.Interfaces;
using Infrastruture.CrossCutting.Identity.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.CodeAnalysis;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Infrastruture.CrossCutting.Identity.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjectionExtension
    {
        private const string ConnectionName = "DefaultConnection";
        public static IServiceCollection AddIdentityIoC(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDbContext<IdentityDbContext>(options => options.UseSqlServer(configuration.GetConnectionString(ConnectionName)))
                .AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityDbContext>()
                .AddDefaultTokenProviders();

            services
                .AddConfiguration(configuration)
                .AddScoped<IUser,User>();        

            return services;
        }

        private static IServiceCollection AddConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var signingConfigurations = new SigningConfiguration();

            services.AddSingleton(signingConfigurations);
            
            var tokenConfiguration = configuration.GetSection("TokenConfiguration");
            services.Configure<TokenConfiguration>(tokenConfiguration);
            var config = tokenConfiguration.Get<TokenConfiguration>();            

            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwtOptions =>
            {

                var secretKey = configuration.GetValue<string>("Jwt:SecretKey");
                var validateSigningKey = !string.IsNullOrWhiteSpace(secretKey);

                var paramsValidation = jwtOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfigurations.Key;
                paramsValidation.ValidAudience = config.ValidoEm;
                paramsValidation.ValidIssuer = config.Emissor;
                paramsValidation.ValidateIssuerSigningKey = true;
                paramsValidation.ValidateLifetime = true;
                paramsValidation.ClockSkew = TimeSpan.Zero;

                if (validateSigningKey)
                {
                    var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);
                    jwtOptions.TokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes);
                }
                else
                {
                    jwtOptions.TokenValidationParameters.RequireExpirationTime = false;
                    jwtOptions.TokenValidationParameters.RequireSignedTokens = false;
                    jwtOptions.TokenValidationParameters.SignatureValidator = (token, _) =>
                        new JwtSecurityToken(token);
                }

                jwtOptions.Events = new JwtBearerEvents
                {
                    OnChallenge = async (context) =>
                    {
                        context.HandleResponse();
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        await context.HttpContext.Response.WriteAsJsonAsync(ErrorResponseModel.FromBadAuthorization());
                    },
                    OnForbidden = async (context) =>
                    {
                        context.Response.StatusCode = StatusCodes.Status403Forbidden;
                        await context.HttpContext.Response.WriteAsJsonAsync(ErrorResponseModel.FromBadAuthorization());
                    },
                };
            });

            return services;
        }

    }
}
