using CalculatorApp.Utilities.Constants;
using System.Drawing;

namespace CalculatorApp.Utilities.Helpers
{
    public class ConsoleUserInterface : IUserInterface
    {
        public string DisplayMessageAndGetUserInput(string message, ConsoleColor color = ConsoleColor.Green)
        {
            DisplayMessage(message, color);
            return GetUserInput();
        }

        public void DisplayMessage(string message, ConsoleColor color)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            SetConsoleColor(color);

            Console.WriteLine(message);

            ResetConsoleColor(originalColor); 
        }

        public string GetUserInput()
        {
            string input;
            do
            {
                //check if the input is not null or empty
                input = Console.ReadLine() ?? throw new InvalidOperationException("Input cannot be null."); ;
                if (string.IsNullOrWhiteSpace(input))
                {
                    DisplayMessage(DisplayMessages.ExpressionContainsNullOrSpaces, ConsoleColor.Red);
                }
            } while (string.IsNullOrWhiteSpace(input));

            return input;
        }

        public void DisplayResultInBox(double result, ConsoleColor color)
        {
            // Save the current console foreground color
            ConsoleColor originalColor = Console.ForegroundColor;
            SetConsoleColor(color);

            string resultText = $"Result: {result}";
            int padding = 3;
            int boxWidth = resultText.Length + (padding * 2);

            // Draw the top of the box
            Console.WriteLine(" " + new string('_', boxWidth));
            Console.WriteLine("|" + new string(' ', boxWidth) + "|");

            // Draw the sides of the box with the result text in the middle
            Console.WriteLine("|" + new string(' ', padding) + resultText + new string(' ', padding) + "|");

            // Draw the bottom of the box
            Console.WriteLine("|" + new string('_', boxWidth) + "|");

            ResetConsoleColor(originalColor);
        }

        private static void SetConsoleColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        private static void ResetConsoleColor(ConsoleColor originalColor)
        {
            Console.ForegroundColor = originalColor;
        }
    }
}
