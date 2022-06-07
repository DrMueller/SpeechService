using System.Threading.Tasks;
using Mmu.SpeechService.Console.Commands.Infrastructure.Services.Servants;

namespace Mmu.SpeechService.Console.Commands.Infrastructure.Services.Implementation
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