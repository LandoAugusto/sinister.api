using Application.Extensions;
using Infrastructure.Data.Repository.Extensions;
using Infrastruture.CrossCutting.Identity.Extensions;
using Infrastruture.Logger.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Integration.BMG.Extensions;

namespace Infrastruture.CrossCutting.IoC.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddIoC(this IServiceCollection services, IConfiguration configuration) =>
            services
           .AddIdentityIoC(configuration)
           .AddApplicationIoC()
           .AddInfraLoggerIoC(configuration)         
           .AddServiceIoC(configuration)
           .AddInfraRepositoriesIoC(configuration);
    }
}
