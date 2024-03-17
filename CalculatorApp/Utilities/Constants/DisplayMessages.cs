namespace CalculatorApp.Utilities.Constants
{
    public static class DisplayMessages
    {
        public const string WelcomeMessage = @"
                  _             _ 
                 | |           | |
                 | |           | |
                 | |           | |
                 | |___________| |
                 | |           | |
                 | |           | |
                 |_|___________|_|

        Welcome to the Calculator Project!";

        public const string StartEndWithDigit = "The expression must start with a digit or a negative sign followed by a digit, and end with a digit. Please try again!";
        public const string InvalidOperatorUsage = "The expression contains invalid operator usage or characters. Please try again!";
        public const string ExpressionContainsSpaces = "The expression contains spaces. Please remove all spaces and then try again!";
        public const string PromptUserToEnterInput = "Please continue using the calculator by entering an expression.\n " +
                                                     "The calculator supports the following operation (+, -, *, /) \n " +
                                                     "Or Enter 'exit' to quit";
        public const string ExitMessage = @"
                  _             _ 
                 | |           | |
                 | |           | |
                 | |           | |
                 | |___________| |
                 | |           | |
                 | |           | |
                 |_|___________|_|

        Thank you for using the Calculator Project!";
        public const string ExpressionContainsNullOrSpaces = "Input cannot be null or empty. Please enter a valid value: ";
    }
}
