using CalculatorApp.Models;
using CalculatorApp.Models.Enums;


namespace CalculatorAppUnitTest.ModelTests;

public class OperatorTokenTests
{
    [Theory]
    [InlineData("+", OperatorPrecedence.AddSubtract, true)]
    [InlineData("-", OperatorPrecedence.AddSubtract, true)]
    [InlineData("*", OperatorPrecedence.MultiplyDivide, true)]
    [InlineData("/", OperatorPrecedence.MultiplyDivide, true)]
    public void OperatorToken_CorrectlyInitializes(string value, OperatorPrecedence expectedPrecedence, bool expectedAssociativity)
    {
        var token = new OperatorToken(value, expectedPrecedence, expectedAssociativity);

        Assert.Equal(value, token.Value);
        Assert.Equal(expectedPrecedence, token.Precedence);
        Assert.Equal(expectedAssociativity, token.IsLeftAssociative);
    }


    [Fact]
    public void OperatorToken_DefaultsToLeftAssociative()
    {
        var token = new OperatorToken("+", OperatorPrecedence.AddSubtract);

        Assert.True(token.IsLeftAssociative);
    }
}
