using Microsoft.Extensions.DependencyInjection;
using Application.Interfaces;
using Application.Services;

namespace Application.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddApplicationIoC(this IServiceCollection services) =>
           services
            .AddScoped<IBrokerApplication, BrokerApplication>()
            .AddScoped<ICommunicantApplication, CommunicantApplication>()
            .AddScoped<IOccurenceApplication, OccurenceApplication>()
            .AddScoped<ICommonApplication, CommonApplication>()
            .AddScoped<IInsurdeApplication, InsurdeApplication>()
            .AddScoped<IPolicyApplication, PolicyApplication>()
            .AddScoped<IProposalApplication, ProposalApplication>()
            .AddScoped<IProductApplication, ProductApplication>()
            .AddScoped<INotificationApplication, NotificationApplication>()
            .AddScoped<ISinisterApplication, SinisterApplication>();
    }
}
    