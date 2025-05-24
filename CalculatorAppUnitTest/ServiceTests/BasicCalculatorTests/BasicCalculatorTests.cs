using CalculatorApp.Models;
using CalculatorApp.Models.Enums;
using CalculatorApp.Services.BasicCalculator;
using CalculatorApp.Services.Interfaces;
using Moq;

namespace CalculatorAppUnitTest.ServiceTests.BasicCalculatorTests;

public class BasicCalculatorTests
{
    [Fact]
    public void Calculate_ValidExpression_ReturnsExpectedResult()
    {
        // Arrange
        var mockProcessor = new Mock<ICalculatorProcessor>();
        var input = "3 + 4 * 2";
        var tokens = new List<Token>
        {
            new NumberToken("3"),
            new OperatorToken("+", OperatorPrecedence.AddSubtract),
            new NumberToken("4"),
            new OperatorToken("*", OperatorPrecedence.MultiplyDivide),
            new NumberToken("2")
        };

        var postfixTokens = new List<Token>
        {
            new NumberToken("3"),
            new NumberToken("4"),
            new NumberToken("2"),
            new OperatorToken("*",OperatorPrecedence.MultiplyDivide),
            new OperatorToken("+",OperatorPrecedence.AddSubtract)
        };
    
        var expectedResult = 11.0;

        mockProcessor.Setup(p => p.ParseExpression(input)).Returns(tokens);
        mockProcessor.Setup(p => p.ConvertToPostfix(tokens)).Returns(postfixTokens);
        mockProcessor.Setup(p => p.EvaluatePostfix(postfixTokens)).Returns(expectedResult);

        var calculator = new BasicCalculator(mockProcessor.Object);

        // Act
        var result = calculator.Calculate(input);

        // Assert
        Assert.Equal(expectedResult, result);
        mockProcessor.Verify(p => p.ParseExpression(input), Times.Once());
        mockProcessor.Verify(p => p.ConvertToPostfix(tokens), Times.Once());
        mockProcessor.Verify(p => p.EvaluatePostfix(postfixTokens), Times.Once());
    }

    [Fact]
    public void Calculate_InvalidExpression_ThrowsInvalidOperationException()
    {
        // Arrange
        var mockProcessor = new Mock<ICalculatorProcessor>();
        var input = "3 + * 2";
        mockProcessor.Setup(p => p.ParseExpression(input)).Throws<InvalidOperationException>();

        var calculator = new BasicCalculator(mockProcessor.Object);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => calculator.Calculate(input));
    }

    [Fact]
    public void Calculate_DivisionByZero_ThrowsDivideByZeroException()
    {
        // Arrange
        var mockProcessor = new Mock<ICalculatorProcessor>();
        var input = "8/0";
        var tokens = new List<Token> { new NumberToken("8"), new OperatorToken("/", OperatorPrecedence.MultiplyDivide), new NumberToken("0") };
        var postfixTokens = new List<Token> { new NumberToken("8"), new NumberToken("0"), new OperatorToken("/", OperatorPrecedence.MultiplyDivide) };

        mockProcessor.Setup(p => p.ParseExpression(input)).Returns(tokens);
        mockProcessor.Setup(p => p.ConvertToPostfix(tokens)).Returns(postfixTokens);
        mockProcessor.Setup(p => p.EvaluatePostfix(postfixTokens)).Throws<DivideByZeroException>();

        var calculator = new BasicCalculator(mockProcessor.Object);

        // Act & Assert
        Assert.Throws<DivideByZeroException>(() => calculator.Calculate(input));
    }
}
