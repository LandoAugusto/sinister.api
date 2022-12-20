using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SinisterApi.Application.Extensions;
using SinisterApi.Infra.Logger.Extensions;
using SinisterApi.Repository.Extensions;
using SinisterApi.Service.Extensions;

namespace SinisterApi.Infra.IoC.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddIoC(this IServiceCollection services, IConfiguration configuration) =>
            services
           .AddApplicationIoC()
           .AddInfraLoggerIoC(configuration)         
           .AddServiceIoC(configuration)
           .AddInfraRepositoriesIoC(configuration);
    }
}
