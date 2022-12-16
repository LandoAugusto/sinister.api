using Microsoft.Extensions.DependencyInjection;
using SinisterApi.Application.Interfaces;
using SinisterApi.Application.Services;

namespace SinisterApi.Application.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddApplicationIoC(this IServiceCollection services) =>
           services
            .AddScoped<ISinisterApplication, SinisterApplication>()
            .AddScoped<IPolicyApplication, PolicyApplication>()
            .AddScoped<IProductApplication, ProductApplication>();
    }
}
