using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.SpeechService.Console.Commands.Infrastructure.Models;
using Mmu.SpeechService.Console.ExecutionContext.Services;

namespace Mmu.SpeechService.Console.Commands.Infrastructure.Services.Servants.Implementation
{
    internal class ConsoleCommandsContainer : IConsoleCommandsContainer
    {
        public ConsoleCommandsContainer(IEnumerable<IConsoleCommand> consoleCommands, IConsoleActionHandler consoleActionHandler)
        {
            _consoleActionHandler = consoleActionHandler;
            _consoleCommands = consoleCommands.OrderBy(c => c.Key).ToList();
        }

        public async Task ShowCommands()
        {
            await ListenForInputs();
        }

        private readonly IConsoleActionHandler _consoleActionHandler;
        private readonly IReadOnlyCollection<IConsoleCommand> _consoleCommands;

        private void DisplayCommands()
        {
            System.Console.WriteLine("---------------------------------------------------------");
            foreach(var cc in _consoleCommands)
            {
                System.Console.WriteLine($"{cc.Key} - {cc.Description}");
            }
        }

        private async Task ListenForInputs()
        {
            await _consoleActionHandler.HandleAsyncAction(
                async () =>
                {
                    DisplayCommands();
                    System.Console.WriteLine();

                    var keyInfo = System.Console.ReadKey(true);

                    var command = _consoleCommands.FirstOrDefault(f => f.Key == keyInfo.Key);
                    if (command == null)
                    {
                        System.Console.WriteLine($"No Command for {keyInfo.Key} found!");
                        await ListenForInputs();
                    }

                    System.Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: Executing {keyInfo.Key}..");
                    await command.ExecuteAsync();
                    System.Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: Execution of {keyInfo.Key} finished.");
                    System.Console.WriteLine();
                    System.Console.WriteLine();
                });

            await ListenForInputs();
        }
    }
}