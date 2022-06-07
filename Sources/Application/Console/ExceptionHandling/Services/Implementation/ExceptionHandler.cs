using System;
using System.Text;
using Mmu.SpeechService.Console.ConsoleOutput.Services;

namespace Mmu.SpeechService.Console.ExceptionHandling.Services.Implementation
{
    internal class ExceptionHandler : IExceptionHandler
    {
        private readonly IConsoleWriter _consoleWriter;

        public ExceptionHandler(IConsoleWriter consoleWriter)
        {
            _consoleWriter = consoleWriter;
        }

        public void HandleException(Exception exception)
        {
            var sb = new StringBuilder();
            sb.Append("Exception Message: ");
            sb.AppendLine(exception.Message);
            sb.Append("Exception Type: ");
            sb.AppendLine(exception.GetType().Name);
            sb.Append("Stack Trace: ");
            sb.AppendLine(exception.StackTrace);

            _consoleWriter.WriteLine(sb.ToString(), null, ConsoleColor.Red);
        }
    }
}