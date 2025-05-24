using CalculatorApp.Models;
using CalculatorApp.Utilities.Constants;


namespace CalculatorAppUnitTest.ModelTests;

public class TokenTests
{
    [Theory]
    [InlineData("42", typeof(NumberToken))]
    [InlineData("-13.5", typeof(NumberToken))]
    [InlineData(OperatorSymbols.Add, typeof(OperatorToken))]
    [InlineData(OperatorSymbols.Subtract, typeof(OperatorToken))]
    [InlineData(OperatorSymbols.Multiply, typeof(OperatorToken))]
    [InlineData(OperatorSymbols.Divide, typeof(OperatorToken))]
    public void Create_ShouldReturnCorrectTokenType(string value, Type expectedType)
    {
        var token = Token.Create(value);

        Assert.IsType(expectedType, token);
        Assert.Equal(value, token.Value);
    }

    [Theory]
    [InlineData("a")]
    [InlineData("^")]
    public void Create_ShouldThrowForUnsupportedOperators(string value)
    {
        var exception = Assert.Throws<ArgumentException>(() => Token.Create(value));

        Assert.Equal($"Unsupported operator: {value}", exception.Message);
    }
}
