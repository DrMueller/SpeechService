using System;
using Lamar;
using Lamar.Microsoft.DependencyInjection;
using Lamar.Scanning.Conventions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mmu.FrenchLearningSystem.Infrastructure.Settings.Models;

namespace Mmu.FrenchLearningSystem.Infrastructure.Initialization
{
    public static class HostFactory
    {
        public static IHost Create()
        {
            var builder = new HostBuilder()
                .ConfigureAppConfiguration(
                    (_, configBuilder) =>
                    {
                        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

                        configBuilder
                            .SetBasePath(AppContext.BaseDirectory)
                            .AddJsonFile("appsettings.json", true, false);

                        if (environment == "Development")
                        {
                            configBuilder.AddUserSecrets<AppSettings>();
                        }
                    })
                .UseServiceProviderFactory<ServiceRegistry>(new LamarServiceProviderFactory())
                .ConfigureServices(
                    (hostContext, services) =>
                    {
                        services.Configure<AppSettings>(hostContext.Configuration.GetSection(AppSettings.SectionKey));
                        services.AddLamar();
                    })
                .ConfigureContainer(
                    (HostBuilderContext _, ServiceRegistry registry) =>
                    {
                        registry.Scan(
                            scanner =>
                            {
                                scanner.AssemblyContainingType(typeof(HostFactory));
                                scanner.WithDefaultConventions(OverwriteBehavior.Never, ServiceLifetime.Singleton);
                            });

                        registry.AddHttpClient();
                    })
                .UseConsoleLifetime();

            return builder.Build();
        }
    }
}