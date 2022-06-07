using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Mmu.FrenchLearningSystem.Console.Commands.Services;
using Mmu.FrenchLearningSystem.Console.Initialization;

namespace Mmu.FrenchLearningSystem
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