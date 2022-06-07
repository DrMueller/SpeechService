using System;

namespace Mmu.SpeechService.Console.ExceptionHandling.Services
{
    public interface IExceptionHandler
    {
        void HandleException(Exception exception);
    }
}