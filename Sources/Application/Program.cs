using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Mmu.FrenchLearningSystem.Areas.Orchestration.Services;
using Mmu.FrenchLearningSystem.Infrastructure.Initialization;

namespace Mmu.FrenchLearningSystem
{
    public static class Program
    {
        public static async Task Main()
        {
            using var host = HostFactory.Create();

            var orchestrator = host.Services.GetRequiredService<IAudoCreationOrchestrator>();
            await orchestrator.CreateAsync();
        }
    }
}