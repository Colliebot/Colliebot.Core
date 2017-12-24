using System;
using System.Threading.Tasks;

namespace Colliebot
{
    public static class PrettyConsole
    {
        public static void Append(string text, ConsoleColor foreground = ConsoleColor.White, ConsoleColor background = ConsoleColor.Black)
        {
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;
            Console.Write(text);
        }

        public static void NewLine(string text = "", ConsoleColor foreground = ConsoleColor.White, ConsoleColor background = ConsoleColor.Black)
        {
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;
            Console.Write(Environment.NewLine + text);
        }

        public static void Log(object severity, string source, string message)
        {
            NewLine($"{DateTime.Now.ToString("hh:mm:ss")} ", ConsoleColor.DarkGray);
            Append($"[{severity}] ", ConsoleColor.Red);
            Append($"{source}: ", ConsoleColor.DarkGreen);
            Append(message, ConsoleColor.White);
        }

        public static Task LogAsync(object severity, string source, string message)
        {
            NewLine($"{DateTime.Now.ToString("hh:mm:ss")} ", ConsoleColor.DarkGray);
            Append($"[{severity}] ", ConsoleColor.Red);
            Append($"{source}: ", ConsoleColor.DarkGreen);
            Append(message, ConsoleColor.White);
            return Task.CompletedTask;
        }
    }
}
