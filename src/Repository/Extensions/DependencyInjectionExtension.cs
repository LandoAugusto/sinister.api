using Infrastructure.Data.Repository.Contexts;
using Infrastructure.Data.Repository.Interfaces.Repositories;
using Infrastructure.Data.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.Interfaces.Repositories;
using Repository.Repositories;
using System.Diagnostics.CodeAnalysis;

namespace Infrastructure.Data.Repository.Extensions
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
            .AddScoped<IPhoneTypeRepository, PhoneTypeRepository>()
            .AddScoped<IEmailTypeRepository, EmailTypeRepository>()
            .AddScoped<IProcessTypeRepository, ProcessTypeRepository>()
            .AddScoped<IStatusRepository, StatusRepository>()
            .AddScoped<IPeriodTypeRepository, PeriodTypeRepository>()
            .AddScoped<ICommunicantRepository, CommunicantRepository>()
            .AddScoped<ICommunicantTypeRepository, CommunicantTypeRepository>()
            .AddScoped<IProductRepository, ProductRepository>()
            .AddScoped<IPolicyRepository, PolicyRepository>()
            .AddScoped<IOccurrenceRepository, OccurrenceRepository>()
            .AddScoped<INotificationRepository, NotificationRepository>()
            .AddScoped<INotificationComplementRepository, NotificationComplementRepository>()
            .AddScoped<ISituationRepository, SituationRepository>();
    }
}
