using System.Threading.Tasks;
using Mmu.FrenchLearningSystem.Console.Commands.Services.Servants;

namespace Mmu.FrenchLearningSystem.Console.Commands.Services.Implementation
{
    internal class ConsoleCommandsStartupService : IConsoleCommandsStartupService
    {
        private readonly IConsoleCommandsContainer _container;

        public ConsoleCommandsStartupService(IConsoleCommandsContainer container)
        {
            _container = container;
        }

        public void Start()
        {
            var commandsTask = _container.ShowCommands();
            Task.WaitAll(commandsTask);
        }
    }
}