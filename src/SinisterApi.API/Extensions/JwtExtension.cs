using Account.TransactionApi.Api.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SinisterApi.API.Configurations;
using SinisterApi.Domain.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace SinisterApi.API.Extensions
{
    internal static class JwtExtension
    {
        public static IServiceCollection AddJwt(this IServiceCollection services, IConfiguration configuration)
        {
            var signingConfigurations = new SigningConfiguration();
            services.AddSingleton(signingConfigurations);

            var tokenConfiguration = new TokenModel();
            new ConfigureFromConfigurationOptions<TokenModel>
                (configuration.GetSection("TokenConfigurations")).Configure(tokenConfiguration);

            services.AddSingleton(tokenConfiguration);

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
                paramsValidation.ValidAudience = tokenConfiguration.Audience;
                paramsValidation.ValidIssuer = tokenConfiguration.Issuer;
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
