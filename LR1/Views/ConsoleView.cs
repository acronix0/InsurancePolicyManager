using LR1.Builders;
using System.Drawing;

namespace LR1.Views
{
    internal class ConsoleView: IViewBuilder
    {
        public ConsoleColor TitleColor { get; set; } = ConsoleColor.Black;
        public ConsoleColor WarningColor { get; set; } = ConsoleColor.Black;
        public void PrintColored(string message, ConsoleColor textColor, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Console.ForegroundColor = textColor;
            Console.BackgroundColor = backgroundColor;
            Console.WriteLine(message);
            ResetColors();
        }

        public void ResetColors() => Console.ResetColor();

        public void PrintTitle(string title)
        {
            string border = new string('-', title.Length + 4);
            PrintColored($"+{border}+", ConsoleColor.Yellow);
            PrintColored($"|  {title}  |", ConsoleColor.Yellow);
            PrintColored($"+{border}+", ConsoleColor.Yellow);
        }

        public void PrintWarning(string message) => PrintColored(message, TitleColor == ConsoleColor.Black ? ConsoleColor.Yellow : TitleColor);

        public void PrintError(string message) => PrintColored(message, TitleColor == ConsoleColor.Black ? ConsoleColor.Yellow : TitleColor);

        public void PrintInfo(string message) => PrintColored(message, TitleColor == ConsoleColor.Black ? ConsoleColor.Yellow : TitleColor);

        public string Prompt(string message)
        {
            PrintColored(message, ConsoleColor.Cyan);
            return Console.ReadLine();
        }


        public IViewBuilder SetTitleColor(ConsoleColor color)
        {
            TitleColor = color;
            return this;
        }

        public IViewBuilder SetWarningColor(ConsoleColor color)
        {
            TitleColor = color;
            return this;
        }
    }
}
