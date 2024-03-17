using CalculatorApp.Models;
using CalculatorApp.Services.Interfaces;

namespace CalculatorApp.Services.BasicCalculator
{
    public class BasicCalculator(ICalculatorProcessor processor) : ICalculator
    {
        private readonly ICalculatorProcessor processor = processor;

        public double Calculate(string input)
        {
            // Parse the expression into a list of Token objects
            List<Token> tokens = processor.ParseExpression(input);

            // Convert the list of Token objects from infix to postfix notation
            List<Token> postfixTokens = processor.ConvertToPostfix(tokens);

            // Evaluate the postfix expression and return the result
            return processor.EvaluatePostfix(postfixTokens);
        }
    }
}
