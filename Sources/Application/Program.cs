using Microsoft.Extensions.DependencyInjection;
using Mmu.SpeechService.Console.Commands.Infrastructure.Services;
using Mmu.SpeechService.Console.Initialization;

namespace Mmu.SpeechService
{
    public static class Program
    {
        public static void Main()
        {
            using var host = HostFactory.Create();
            host
                .Services
                .GetRequiredService<IConsoleCommandsStartupService>()
                .Start();
        }
    }
}