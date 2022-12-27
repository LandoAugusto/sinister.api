using Microsoft.Extensions.DependencyInjection;
using SinisterApi.Application.Interfaces;
using SinisterApi.Application.Services;

namespace SinisterApi.Application.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddApplicationIoC(this IServiceCollection services) =>
           services
            .AddScoped<IBrokerApplication, BrokerApplication>()
            .AddScoped<ICommonApplication, CommonApplication>()
            .AddScoped<IInsurdeApplication, InsurdeApplication>()
            .AddScoped<IPolicyApplication, PolicyApplication>()
            .AddScoped<IProposalApplication, ProposalApplication>()
            .AddScoped<IProductApplication, ProductApplication>()
            .AddScoped<INotificationApplication, NotificationApplication>()
            .AddScoped<ISinisterApplication, SinisterApplication>();
    }
}
    