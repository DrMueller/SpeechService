using System;

namespace Mmu.FrenchLearningSystem.Console.ExceptionHandling.Services
{
    public interface IExceptionHandler
    {
        void HandleException(Exception exception);
    }
}