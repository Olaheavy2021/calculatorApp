using CalculatorApp.Models.Enums;

namespace CalculatorApp.Models
{
    public class OperatorToken : Token
    {
        public OperatorPrecedence Precedence { get; }
        public bool IsLeftAssociative { get; }

        public OperatorToken(string value, OperatorPrecedence precedence, bool isLeftAssociative = true) : base(value)
        {
            Precedence = precedence;
            IsLeftAssociative = isLeftAssociative;
        }
    }
}
