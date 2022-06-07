using System;
using Lamar;
using Lamar.Microsoft.DependencyInjection;
using Lamar.Scanning.Conventions;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mmu.SpeechService.Console.Commands.Infrastructure.Models;
using Mmu.SpeechService.Console.Commands.Infrastructure.Services;
using Mmu.SpeechService.Console.Commands.Infrastructure.Services.Implementation;
using Mmu.SpeechService.Console.Commands.Infrastructure.Services.Servants;
using Mmu.SpeechService.Console.Commands.Infrastructure.Services.Servants.Implementation;
using Mmu.SpeechService.Console.ConsoleOutput.Services;
using Mmu.SpeechService.Console.ConsoleOutput.Services.Implementation;
using Mmu.SpeechService.Console.ExceptionHandling.Services;
using Mmu.SpeechService.Console.ExceptionHandling.Services.Implementation;
using Mmu.SpeechService.Console.ExecutionContext.Services;
using Mmu.SpeechService.Console.ExecutionContext.Services.Implementation;
using Mmu.SpeechService.CrossCutting.Settings.Models;

namespace Mmu.SpeechService.Console.Initialization
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
                                scanner.AddAllTypesOf<IConsoleCommand>();
                                scanner.WithDefaultConventions(OverwriteBehavior.Never, ServiceLifetime.Singleton);
                            });

                        registry.For<IConsoleCommandsContainer>().Use<ConsoleCommandsContainer>().Singleton();
                        registry.For<IConsoleActionHandler>().Use<ConsoleActionHandler>().Singleton();
                        registry.For<IConsoleWriter>().Use<ConsoleWriter>().Singleton();
                        registry.For<IExceptionHandler>().Use<ExceptionHandler>().Singleton();
                        registry.For<IConsoleCommandsStartupService>().Use<ConsoleCommandsStartupService>();
                        registry.AddHttpClient();
                        registry.AddMediatR(typeof(HostFactory));

                    })
                .UseConsoleLifetime();

            return builder.Build();
        }
    }
}