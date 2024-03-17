using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.Utilities.Helpers
{
    public interface IUserInterface
    {
        string DisplayMessageAndGetUserInput(string message, ConsoleColor color);

        void DisplayMessage(string message, ConsoleColor color);

        string GetUserInput();

        void DisplayResultInBox(double result, ConsoleColor color);
    }
}
