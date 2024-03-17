using CalculatorApp.Utilities.Helpers;

namespace CalculatorApp.Services.Interfaces
{
    public interface IInputValidator
    {
        ValidationResult Validate(string input);
    }
}
