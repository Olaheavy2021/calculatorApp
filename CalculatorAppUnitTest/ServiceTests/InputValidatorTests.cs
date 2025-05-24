using CalculatorApp.Services;
using CalculatorApp.Utilities.Constants;

namespace CalculatorAppUnitTest.ServiceTests;

public class InputValidatorTests
{
    [Theory]
    [InlineData("10+5", true, "")]
    [InlineData("-10+5", true, "")]
    [InlineData("10+", false, DisplayMessages.StartEndWithDigit)]
    [InlineData("+10", false, DisplayMessages.StartEndWithDigit)]
    [InlineData("a+10", false, DisplayMessages.StartEndWithDigit)]
    [InlineData("10+5-2", true, "")]
    [InlineData("10++5", false, DisplayMessages.InvalidOperatorUsage)]
    [InlineData("10.5*2.2", true, "")]
    [InlineData("-10.5*-2", true, "")]
    [InlineData("-10.5@-2", false, DisplayMessages.InvalidOperatorUsage)]
    [InlineData("-10.5 -2", false, DisplayMessages.ExpressionContainsSpaces)]
    [InlineData("-+10-2", false, DisplayMessages.StartEndWithDigit)]
    public void Validate_InputExpressions_ReturnsExpectedResult(string input, bool expectedIsValid, string expectedMessage)
    {
        // Arrange
        var validator = new InputValidator();

        // Act
        var result = validator.Validate(input);

        // Assert
        Assert.Equal(expectedIsValid, result.IsValid);
        if (!expectedIsValid)
        {
            Assert.Equal(expectedMessage, result.ErrorMessage);
        }
    }
}
