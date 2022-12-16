using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using SinisterApi.Infra.Logger.Interfaces;
using SinisterApi.Infra.Logger.Services;

namespace SinisterApi.Infra.Logger.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddInfraLoggerIoC(this IServiceCollection services, IConfiguration configuration) =>
          services
          .ConfigLoggerSerilog()
          .AddScoped<ILogWriter, LogWriter>();


        public static IServiceCollection ConfigLoggerSerilog(
           this IServiceCollection services) => services.AddSingleton(_ =>
           {
               return ConfigLogger();
           });

        public static ILogger ConfigLogger()
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile(
                    $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
                    optional: true)
                .Build();

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithMachineName()
                .WriteTo.Debug()
                .WriteTo.Console()                
                .Enrich.WithProperty("Environment", environment)
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            return Log.Logger;
        }
    }
}
