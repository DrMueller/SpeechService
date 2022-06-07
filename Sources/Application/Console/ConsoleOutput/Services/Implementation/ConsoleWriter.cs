using System;

namespace Mmu.FrenchLearningSystem.Console.ConsoleOutput.Services.Implementation
{
    internal class ConsoleWriter : IConsoleWriter
    {
        public void Write(string text, ConsoleColor? backgroundColor, ConsoleColor? foregroundColor)
        {
            AdjustColors(backgroundColor, foregroundColor);
            System.Console.Write(text);
            System.Console.ResetColor();
        }

        public void WriteLine(string text, ConsoleColor? backgroundColor, ConsoleColor? foregroundColor)
        {
            AdjustColors(backgroundColor, foregroundColor);
            System.Console.WriteLine(text);
            System.Console.ResetColor();
        }

        private static void AdjustColors(ConsoleColor? backgroundColor, ConsoleColor? foregroundColor)
        {
            if (backgroundColor.HasValue)
            {
                System.Console.BackgroundColor = backgroundColor.Value;
            }

            if (foregroundColor.HasValue)
            {
                System.Console.ForegroundColor = foregroundColor.Value;
            }
        }
    }
}