using CalculatorApp.Models;


namespace CalculatorAppUnitTest.ModelTests
{
    public class NumberTokenTests
    {
        [Theory]
        [InlineData("42", 42)]
        [InlineData("-13.5", -13.5)]
        [InlineData("0", 0)]
        [InlineData("3.14159", 3.14159)]
        public void NumberToken_CorrectlyParsesValue(string stringValue, double expectedNumber)
        {
            var token = new NumberToken(stringValue);

            Assert.Equal(stringValue, token.Value); // Verify string representation is correct
            Assert.Equal(expectedNumber, token.Number); // Verify parsed double value is correct
        }

        [Fact]
        public void NumberToken_ThrowsFormatExceptionForNonNumericValue()
        {
            var nonNumericValue = "abc";

            var exception = Assert.Throws<FormatException>(() => new NumberToken(nonNumericValue));
        }
    }
}
