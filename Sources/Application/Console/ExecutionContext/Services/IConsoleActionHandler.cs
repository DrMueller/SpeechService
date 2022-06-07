using System;
using System.Threading.Tasks;

namespace Mmu.SpeechService.Console.ExecutionContext.Services
{
    public interface IConsoleActionHandler
    {
        void HandleAction(Action callback);

        Task HandleAsyncAction(Func<Task> callback);
    }
}