using CalculatorApp.Models;
using CalculatorApp.Services.Interfaces;
using CalculatorApp.Utilities.Constants;
using System.Text.RegularExpressions;


namespace CalculatorApp.Services
{
    public abstract class CalculatorProcessorBase : ICalculatorProcessor
    {
        protected abstract string TokenPattern { get; }

        public List<Token> ParseExpression(string input)
        {
            // Step 1: Preprocess to handle negative numbers at the start
            string preprocessed = PreprocessNegativeNumbers(input);

            // Step 2: Parse the preprocessed expression
            return ParseTokens(preprocessed);
        }

        private List<Token> ParseTokens(string input)
        {
            // Regular expression to match individual tokens within the input.
            var matches = Regex.Matches(input, TokenPattern);
            var tokens = new List<Token>();

            // Iterate through each regular expression match.
            foreach (Match match in matches.Cast<Match>())
            {
                tokens.Add(Token.Create(match.Value));
            }

            return tokens;
        }

        public List<Token> ConvertToPostfix(List<Token> infixTokens)
        {
            var outputQueue = new Queue<Token>();
            var operatorStack = new Stack<OperatorToken>();

            foreach (var token in infixTokens)
            {
                switch (token)
                {
                    // Numbers are directly added to the output queue.
                    case NumberToken numberToken:
                        outputQueue.Enqueue(numberToken);
                        break;

                    // Pop higher or equal precedence operators from the stack (while preserving left-associativity)
                    case OperatorToken operatorToken:
                        while (operatorStack.Count > 0 &&
                               operatorStack.Peek().Precedence >= operatorToken.Precedence &&
                               operatorToken.IsLeftAssociative)
                        {
                            outputQueue.Enqueue(operatorStack.Pop());
                        }

                        // Or push the current operator onto the stack.
                        operatorStack.Push(operatorToken);
                        break;
                }
            }

            // Pop any remaining operators from the stack and add them to the output.
            while (operatorStack.Count > 0)
            {
                outputQueue.Enqueue(operatorStack.Pop());
            }

            return outputQueue.ToList();
        }


        public double EvaluatePostfix(List<Token> postfixTokens)
        {
            var stack = new Stack<double>();

            foreach (var token in postfixTokens)
            {
                switch (token)
                {
                    // Push numbers onto the stack.
                    case NumberToken numberToken:
                        stack.Push(numberToken.Number);
                        break;

                    // Pop two numbers from the stack (right operand, then left operand).
                    case OperatorToken operatorToken:
                        var right = stack.Pop();
                        var left = stack.Pop();

                        // Perform the calculation
                        stack.Push(EvaluateOperation(left, right, operatorToken.Value));
                        break;
                }
            }

            if (stack.Count != 1)
            {
                throw new InvalidOperationException("The postfix expression is invalid.");
            }

            return stack.Pop();
        }

        private static string PreprocessNegativeNumbers(string input)
        {
            // Replace negative numbers at the start of the string with a unique marker "NEG"
            string pattern = @"^-(\d+)";
            string replaced = Regex.Replace(input, pattern, "NEG$1");
            return replaced;
        }

        private static double EvaluateOperation(double left, double right, string operation)
        {
            return operation switch
            {
                OperatorSymbols.Add => left + right,
                OperatorSymbols.Subtract => left - right,
                OperatorSymbols.Multiply => left * right,
                OperatorSymbols.Divide when right != 0 => left / right,
                OperatorSymbols.Divide => throw new DivideByZeroException(),
                _ => throw new InvalidOperationException($"Unsupported operator: {operation}")
            };
        }
    }
}
