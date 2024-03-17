using CalculatorApp.Models;
using CalculatorApp.Models.Enums;
using CalculatorApp.Services.BasicCalculator;
using CalculatorApp.Utilities.Constants;
using System.Diagnostics;

namespace CalculatorAppUnitTest.ServiceTests.BasicCalculatorTests
{
    public class BasicCalculatorProcessorTests
    {
        [Fact]
        public void ParseToken_ShouldCorrectlyParseMixedInput()
        {
            // Arrange
            var processor = new BasicCalculatorProcessor();
            string input = "3+5-2*6/2";
            var expectedTokens = new List<string> { "3", "+", "5", "-", "2", "*", "6", "/", "2" };

            // Act
            var tokens = processor.ParseExpression(input);

            // Assert
            Assert.Equal(expectedTokens.Count, tokens.Count);
            for (int i = 0; i < expectedTokens.Count; i++)
            {
                Assert.Equal(expectedTokens[i], tokens[i].Value);
            }
        }

        [Fact]
        public void ParseExpression_ShouldCorrectlyHandleNegativeNumberAtStart()
        {
            // Arrange
            var processor = new BasicCalculatorProcessor();
            string input = "-123+45-67";
            var expectedTokens = new List<string> { "-123", "+", "45", "-", "67" };

            // Act
            List<Token> resultTokens = processor.ParseExpression(input);

            // Convert Token objects back to strings for easy comparison
            // This assumes your Token class has a property (e.g., Value) to get its string representation
            var resultTokensValues = resultTokens.Select(token => token.Value).ToList();

            // Assert
            Assert.Equal(expectedTokens.Count, resultTokens.Count); // Check if the count of tokens matches
            for (int i = 0; i < expectedTokens.Count; i++)
            {
                Assert.Equal(expectedTokens[i], resultTokensValues[i]); // Check each token value
            }
        }

        [Fact]
        public void ConvertToPostfix_EmptyInput_ReturnsEmptyList()
        {
            // Arrange
            var processor = new BasicCalculatorProcessor();
            var input = new List<Token>();

            // Act
            var result = processor.ConvertToPostfix(input);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void ConvertToPostfix_SingleNumber_ReturnsSingleNumber()
        {
            // Arrange
            var processor = new BasicCalculatorProcessor();
            var input = new List<Token> { new NumberToken("5") };

            // Act
            var result = processor.ConvertToPostfix(input);

            // Assert
            var expected = new List<Token> { new NumberToken("5") };
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ConvertToPostfix_SimpleExpression_CorrectOrder()
        {
            // Arrange
            var processor = new BasicCalculatorProcessor();
            var input = new List<Token>
            {
               new NumberToken("3"),
               new OperatorToken("+", OperatorPrecedence.AddSubtract),
               new NumberToken("4")
            };

            var expected = new List<Token>
            {
               new NumberToken("3"),
               new NumberToken("4"),
               new OperatorToken("+", OperatorPrecedence.AddSubtract)
            };

            // Act
            var result = processor.ConvertToPostfix(input);

           
            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ConvertToPostfix_ComplexExpression_CorrectOrder()
        {
            // Arrange
            var processor = new BasicCalculatorProcessor();
            var input = new List<Token>
            {
                new NumberToken("3"),
                new OperatorToken("+", OperatorPrecedence.AddSubtract),
                new NumberToken("4"),
                new OperatorToken("*", OperatorPrecedence.MultiplyDivide),
                new NumberToken("2"),
                new OperatorToken("/", OperatorPrecedence.MultiplyDivide),
                new NumberToken("1"),
                new OperatorToken("-", OperatorPrecedence.MultiplyDivide),
                new NumberToken("5")
            };

            var expected = new List<Token>
            {
                new NumberToken("3"),
                new NumberToken("4"),
                new NumberToken("2"),
                new OperatorToken("*",OperatorPrecedence.MultiplyDivide),
                new NumberToken("1"),
                new OperatorToken("/",OperatorPrecedence.MultiplyDivide),
                new NumberToken("5"),
                new OperatorToken("-", OperatorPrecedence.MultiplyDivide),
                new OperatorToken("+", OperatorPrecedence.AddSubtract)
            };

            // Act
            var result = processor.ConvertToPostfix(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void EvaluatePostfix_ValidExpression_ReturnsCorrectResult()
        {
            // Arrange
            var processor = new BasicCalculatorProcessor();
            var tokens = new List<Token>
            {
                new NumberToken("3"),
                new NumberToken("4"),
                new OperatorToken(OperatorSymbols.Add, OperatorPrecedence.AddSubtract),
                new NumberToken("2"),
                new OperatorToken(OperatorSymbols.Multiply, OperatorPrecedence.MultiplyDivide),
                new NumberToken("1"),
                new OperatorToken(OperatorSymbols.Subtract, OperatorPrecedence.AddSubtract)
            };

            // Act
            var result = processor.EvaluatePostfix(tokens);// Replace YourClass with the actual class name

            // Assert
            Assert.Equal(13, result);
        }

        [Fact]
        public void EvaluatePostfix_InvalidExpression_ThrowsInvalidOperationException()
        {
            // Arrange
            var processor = new BasicCalculatorProcessor();
            var tokens = new List<Token>
            {
                new NumberToken("3"),
                new OperatorToken(OperatorSymbols.Add, OperatorPrecedence.AddSubtract) // Invalid postfix expression
            };
           

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => processor.EvaluatePostfix(tokens));
        }
    }
}
