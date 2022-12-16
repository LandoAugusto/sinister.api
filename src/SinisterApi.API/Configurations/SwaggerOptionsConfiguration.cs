using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace ASinisterApi.API.Configurations
{
    internal class SwaggerOptionsConfiguration : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public SwaggerOptionsConfiguration(IApiVersionDescriptionProvider provider) => _provider = provider;

        public void Configure(SwaggerGenOptions options)
        {
            _provider.ApiVersionDescriptions
                .ToList()
                .ForEach(v =>
                {
                    var info = new OpenApiInfo()
                    {
                        Title = "Sinister API",
                        Description = "Sinister (ASP.NET net6.0)",
                        Version = v.ApiVersion.ToString(),
                        Contact = new OpenApiContact()
                        {
                            Name = "Leandro",
                            Email = "teste@teste.com.br"
                        },
                    };

                    options.SwaggerDoc(v.GroupName, info);
                });

            options.ExampleFilters();
        }
    }
}