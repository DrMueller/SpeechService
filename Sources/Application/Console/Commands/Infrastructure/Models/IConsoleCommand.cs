using System;
using System.Threading.Tasks;

namespace Mmu.SpeechService.Console.Commands.Infrastructure.Models
{
    public interface IConsoleCommand
    {
        string Description { get; }
        ConsoleKey Key { get; }

        Task ExecuteAsync();
    }
}