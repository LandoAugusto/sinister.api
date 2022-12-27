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
            .ConfigureServices()
            .AddSingleton(configuration.GetSection("MiddlewareApiConfig").Get<MiddlewareApiConfig>())
            .AddScoped<IRequestErrorHandler, RequestErrorHandler>()
            .AddScoped<IRequestExecutador, RequestExecutador>()
            .AddScoped<IRequestTokenHandler, RequestTokenHandler>();            

        private static IServiceCollection ConfigureFlurlClient(
             this IServiceCollection services) =>
         services
             .AddSingleton<IFlurlClientFactory, PerBaseUrlFlurlClientFactory>();

        private static IServiceCollection ConfigureServices(
             this IServiceCollection services) =>
         services
            .AddScoped<IAuthenticationService, AuthenticationService>()
            .AddScoped<IAddressService, AddressService>()
            .AddScoped<IInsuredService, InsuredService>()
            .AddScoped<IPolicyService, PolicyService>()
            .AddScoped<IProposalService, ProposalService>()
            .AddScoped<IBrokerService, BrokerService>();
    }
}
