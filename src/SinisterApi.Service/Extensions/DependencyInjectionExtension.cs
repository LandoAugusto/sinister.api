using Flurl.Http.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SinisterApi.Service.Configurations;
using SinisterApi.Service.Http;
using SinisterApi.Service.Http.Interfaces;
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
            .AddScoped<IRequestErrorHandler, RequestErrorHandler>()
            .AddScoped<IRequestExecutador, RequestExecutador>()
            .AddScoped<IRequestTokenHandler, RequestTokenHandler>()
            .AddScoped<IInsuredService, InsuredService>()
            .AddScoped<IPolicyService, PolicyService>()
            .AddScoped<IProposalSevice, ProposalSevice>()
            .AddScoped<IBrokerService, BrokerService>()
            .AddScoped<IAuthenticationService, AuthenticationService>();

        private static IServiceCollection ConfigureFlurlClient(
             this IServiceCollection services) =>
         services
             .AddSingleton<IFlurlClientFactory, PerBaseUrlFlurlClientFactory>();
    }
}
