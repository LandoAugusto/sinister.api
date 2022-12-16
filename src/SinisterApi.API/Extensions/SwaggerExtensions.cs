using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace SinisterApi.API.Extensions
{
    internal static class SwaggerExtensions
    {
        public static IApplicationBuilder ConfigureSwagger(
            this IApplicationBuilder app,
            IConfiguration configuration,
            IApiVersionDescriptionProvider provider)
        {

            var useSwagger = configuration.GetValue<bool>("UseSwagger");

            if (!useSwagger)
            {
                return app;
            }

            return app
                .UseSwagger()
                .UseSwaggerUI(o => provider.ApiVersionDescriptions
                    .ToList()
                    .ForEach(d =>
                        o.SwaggerEndpoint($"/swagger/{d.GroupName}/swagger.json", d.GroupName.ToUpper())));
        }
    }
}
