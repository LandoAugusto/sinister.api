using Flurl.Http.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SinisterApi.Service.Configurations;
using SinisterApi.Service.Interfaces;
using SinisterApi.Service.Services;

namespace SinisterApi.Service.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddServiceIoC(this IServiceCollection services, IConfiguration configuration) =>
           services
            .ConfigureFlurlClient()
            .AddSingleton(configuration.GetSection("MiddlewareApiConfig").Get<MiddlewareApiConfig>())
            .AddScoped<IPolicyService, PolicyService>()
            .AddScoped<IAuthenticationService, AuthenticationService>();

        private static IServiceCollection ConfigureFlurlClient(
             this IServiceCollection services) =>
         services
             .AddSingleton<IFlurlClientFactory, PerBaseUrlFlurlClientFactory>();
    }
}
