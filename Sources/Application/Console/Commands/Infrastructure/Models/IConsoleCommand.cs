using System;
using System.Threading.Tasks;

namespace Mmu.FrenchLearningSystem.Console.Commands.Models
{
    public interface IConsoleCommand
    {
        string Description { get; }
        ConsoleKey Key { get; }

        Task ExecuteAsync();
    }
}