using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SinisterApi.Repository.Contexts;
using SinisterApi.Repository.Interfaces.Repositories;
using SinisterApi.Repository.Repositories;
using System.Diagnostics.CodeAnalysis;

namespace SinisterApi.Repository.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class ServicesExtension
    {
        private const string ConnectionName = "DefaultConnection";

        public static IServiceCollection AddInfraRepositoriesIoC(this IServiceCollection services, IConfiguration configuration) =>

            services
                .AddDbContext<SinisterDbContext>(
                    options =>
                        options.UseSqlServer(configuration.GetConnectionString(ConnectionName)), ServiceLifetime.Scoped
                )
                .AddRepositories();

        private static IServiceCollection AddRepositories(this IServiceCollection services) =>
            services
            .AddScoped<IStatusSinisterRepository, StatusSinisterRepository>()
            .AddScoped<IPeriodTyperRepository, PeriodTyperRepository>()
            .AddScoped<ICommunicantTypeRepository, CommunicantTypeRepository>()
            .AddScoped<IProductRepository, ProductRepository>();
    }
}
