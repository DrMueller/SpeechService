using System.Threading.Tasks;

namespace Mmu.SpeechService.Console.Commands.Infrastructure.Services.Servants
{
    public interface IConsoleCommandsContainer
    {
        Task ShowCommands();
    }
}