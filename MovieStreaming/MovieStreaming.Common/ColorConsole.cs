using System;

namespace MovieStreaming.Common
{
    public static class ColorConsole
    {
        public static void WriteMagenta(string message, params object[] args)
        {
            WriteLineColor(message, ConsoleColor.Magenta, args);
        }

        public static void WriteLineGreen(string message, params object[] args)
        {
            WriteLineColor(message, ConsoleColor.Green, args);
        }

        public static void WriteLineYellow(string message, params object[] args)
        {
            WriteLineColor(message, ConsoleColor.Yellow, args);
        }

        internal static void WriteLineWhite(string message, params object[] args)
        {
            WriteLineColor(message, ConsoleColor.White, args);
        }

        public static void WriteLineGray(string message, params object[] args)
        {
            WriteLineColor(message, ConsoleColor.Gray, args);
        }

        public static void WriteLineCyan(string message, params object[] args)
        {
            WriteLineColor(message, ConsoleColor.Cyan, args);
        }

        public static void WriteLineRed(string message, params object[] args)
        {
            WriteLineColor(message, ConsoleColor.Red, args);
        }

        private static void WriteLineColor(string message, ConsoleColor color, params object[] args)
        {
            var originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            if (args != null && args.Length > 0)
            {
                Console.WriteLine(string.Format(message, args));
            }
            else
            {
                Console.WriteLine(message);
            }

            Console.ForegroundColor = originalColor;
        }
    }
}
