namespace LR1.Views
{
    internal class ConsoleView
    {
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

        public void PrintWarning(string message) => PrintColored(message, ConsoleColor.Yellow);

        public void PrintError(string message) => PrintColored(message, ConsoleColor.Yellow);

        public void PrintInfo(string message) => PrintColored(message, ConsoleColor.Green);

        public string Prompt(string message)
        {
            PrintColored(message, ConsoleColor.Cyan);
            return Console.ReadLine();
        }
    }
}
