using System;

namespace Mmu.SpeechService.Console.ConsoleOutput.Services
{
    public interface IConsoleWriter
    {
        void Write(string text, ConsoleColor? backgroundColor = ConsoleColor.Black, ConsoleColor? foregroundColor = ConsoleColor.Gray);

        void WriteLine(string text, ConsoleColor? backgroundColor = ConsoleColor.Black, ConsoleColor? foregroundColor = ConsoleColor.Gray);
    }
}