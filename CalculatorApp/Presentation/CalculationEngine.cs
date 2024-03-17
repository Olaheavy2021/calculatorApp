using CalculatorApp.Services.Interfaces;
using CalculatorApp.Utilities.Constants;
using CalculatorApp.Utilities.Helpers;

namespace CalculatorApp.Presentation
{
    public class CalculationEngine(IInputValidator validator, IUserInterface ui, ICalculator calculator)
    {
        private readonly IInputValidator validator = validator;
        private readonly IUserInterface ui = ui;
        private readonly ICalculator calculator = calculator;

        public void Run()
        {
            bool isExitCommand = false;
            ui.DisplayMessage(DisplayMessages.WelcomeMessage, ConsoleColor.Green);

            while(!isExitCommand)
            {
                try
                {
                    // Prompt the user for input and store the response.
                    string input = ui.DisplayMessageAndGetUserInput(DisplayMessages.PromptUserToEnterInput, ConsoleColor.Green);

                    // If it's the exit command, display the exit message and break the loop.
                    isExitCommand = input.Equals(OperatorSymbols.Exit, StringComparison.CurrentCultureIgnoreCase);
                    if (isExitCommand)
                    {
                        ui.DisplayMessage(DisplayMessages.ExitMessage, ConsoleColor.Green);
                        break;
                    }

                    //validate the input from the user
                    ValidationResult validationResult = validator.Validate(input);
                    if (!validationResult.IsValid)
                    {
                        ui.DisplayMessage(validationResult.ErrorMessage, ConsoleColor.Red);
                        continue;

                    }

                    // Attempt to calculate the result.
                    double result = calculator.Calculate(input);
                    ui.DisplayResultInBox(result, ConsoleColor.Green);
                    continue;

                }
                catch (Exception e)
                {
                    ui.DisplayMessage($"Error: {e.Message}", ConsoleColor.Red);
                    continue;
                }
            }
        }
    }
}
