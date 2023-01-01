using ASinisterApi.API.Configurations;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using SinisterApi.API.Configurations;
using SinisterApi.API.Filters;
using SinisterApi.API.Interceptors;
using Domain.Core.Constants;
using Domain.Core.Infrastructure.Contexts;
using Domain.Core.Infrastructure.Contexts.Intefaces;

using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.IO.Compression;
using System.Reflection;

namespace SinisterApi.API.Extensions
{
    internal static class DependencyInjectionExtension
    {
        private const string BearerAuthenticationDescription = "JWT Authorization header using the Bearer scheme. Enter 'Bearer' [space] and then your token in the text input below. Example: 'Bearer 12345abcdef'";
        public static IServiceCollection AddApi(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddScoped<IRequestContextHolder, RequestContextHolder>()
                .ConfigControllersPipeline()
                .ConfigAppVersioning()
                .ConfigSwagger()                
                .Configure<GzipCompressionProviderOptions>(gzipCompressionProviderOptions =>
                    gzipCompressionProviderOptions.Level = CompressionLevel.Fastest)
                .AddResponseCompression(compressionOptions =>
                {
                    compressionOptions.EnableForHttps = true;
                    compressionOptions.Providers.Add<GzipCompressionProvider>();
                    compressionOptions.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[]
                    {
                        HttpHeaders.JsonApiContentType
                    });
                });

        private static IServiceCollection ConfigControllersPipeline(this IServiceCollection services)
        {
            services
               .AddControllers(mvcOptions =>
               {
                   mvcOptions.Filters.Add<ExceptionFilter>(order: 0);
                   mvcOptions.Filters.Add<ContextFilter>(order: 1);
                   mvcOptions.Filters.Add<ControllersFilter>(order: 2);
               })
               .AddJsonOptions(
                    options =>
                    {
                        options.JsonSerializerOptions.PropertyNamingPolicy = null;
                        options.JsonSerializerOptions.PropertyNameCaseInsensitive = false;
                    })
                .ConfigureApiBehaviorOptions(opt => opt
                    .SuppressModelStateInvalidFilter = true);

            services.AddFluentValidationAutoValidation();
            services.AddTransient<IValidatorInterceptor, FluentValidatorInterceptor>();

            return services;
        }
        private static IServiceCollection ConfigAppVersioning(this IServiceCollection services) =>
            services
                .AddApiVersioning(v => v.ReportApiVersions = true)
                .AddVersionedApiExplorer(v =>
                {
                    v.GroupNameFormat = "'v'VVV";
                    v.SubstituteApiVersionInUrl = true;
                });

        private static IServiceCollection ConfigSwagger(this IServiceCollection services) =>
            services
                .AddTransient<IConfigureOptions<SwaggerGenOptions>, SwaggerOptionsConfiguration>()
                .AddSwaggerGen(s =>
                {
                    s.OperationFilter<SwaggerDefaultValues>();
                    s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Description = BearerAuthenticationDescription,
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey
                    });
                    s.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                },
                            },

                            Array.Empty<string>()
                        },
                    });

                    var xmlApiFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlApiPath = Path.Combine(AppContext.BaseDirectory, xmlApiFile);

                    s.ExampleFilters();
                    s.OperationFilter<AddResponseHeadersFilter>();
                    s.CustomSchemaIds(type => type.FullName);
                    s.IncludeXmlComments(xmlApiPath);
                })
            .AddSwaggerExamplesFromAssemblyOf<Startup>();

    }
}
