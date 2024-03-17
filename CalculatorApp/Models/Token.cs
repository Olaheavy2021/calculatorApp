using CalculatorApp.Models.Enums;
using CalculatorApp.Utilities.Constants;

namespace CalculatorApp.Models
{
    public abstract class Token
    {
        public string Value { get; private set; }

        protected Token(string value)
        {
            Value = value;
        }

        // Factory method to create the appropriate Token subclass.
        public static Token Create(string value)
        {
            if (value.StartsWith(OperatorSymbols.NegativeRegex))
            {
                // Handle "NEG" prefix for negative numbers
                var correctedValue = value.Replace(OperatorSymbols.NegativeRegex, OperatorSymbols.Subtract);
                return new NumberToken(correctedValue);
            }
            else if (double.TryParse(value, out _))
            {
                // Attempt to parse the value as a number.
                return new NumberToken(value);
            }
            else
            {
                // Otherwise, treat the value as an operator.
                var precedence = value switch
                {
                    OperatorSymbols.Add => OperatorPrecedence.AddSubtract,
                    OperatorSymbols.Subtract => OperatorPrecedence.AddSubtract,
                    OperatorSymbols.Multiply => OperatorPrecedence.MultiplyDivide,
                    OperatorSymbols.Divide => OperatorPrecedence.MultiplyDivide,
                    _ => throw new ArgumentException($"Unsupported operator: {value}")
                };
                return new OperatorToken(value, precedence);
            }
        }

        public override bool Equals(object? obj)
        {
            if (obj is Token other)
            {
                return Value == other.Value;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
