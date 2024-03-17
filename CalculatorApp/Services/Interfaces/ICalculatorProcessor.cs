using CalculatorApp.Models;

namespace CalculatorApp.Services.Interfaces
{
    public interface ICalculatorProcessor
    {
        List<Token> ParseExpression(string input);

        List<Token> ConvertToPostfix(List<Token> infixTokens);

        double EvaluatePostfix(List<Token> postfixTokens);
    }
}
