using CalculatorApp.Services.Interfaces;
using CalculatorApp.Utilities.Constants;
using CalculatorApp.Utilities.Helpers;
using System.Text.RegularExpressions;


namespace CalculatorApp.Services
{
    public partial class InputValidator : IInputValidator
    {
        public ValidationResult Validate(string input)
        {
            if (ContainsSpaces(input))
            {
                return new ValidationResult(false, DisplayMessages.ExpressionContainsSpaces);
            }

            if (!StartsAndEndsWithDigitOrMinusDigit(input))
            {
                return new ValidationResult(false, DisplayMessages.StartEndWithDigit);
            }

            if (!IsValidOperatorUsage(input))
            {
                return new ValidationResult(false, DisplayMessages.InvalidOperatorUsage);
            }

            return new ValidationResult(true);
        }


        [GeneratedRegex(@"^-?\d+(\.\d+)?([+\-*/]-?\d+(\.\d+)?)*$")]
        private static partial Regex InvalidOperatorRegex();

        private bool ContainsSpaces(string input)
        {
            return input.Contains(' ');
        }

        private bool StartsAndEndsWithDigitOrMinusDigit(string input)
        {
            return (char.IsDigit(input[0]) || (input[0] == '-' && input.Length > 1 && char.IsDigit(input[1]))) && char.IsDigit(input[input.Length - 1]);
        }

        private bool IsValidOperatorUsage(string input)
        {
            return InvalidOperatorRegex().IsMatch(input);
        }
    }
}
