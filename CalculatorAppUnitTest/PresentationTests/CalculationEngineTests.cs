using CalculatorApp.Presentation;
using CalculatorApp.Services.Interfaces;
using CalculatorApp.Utilities.Helpers;
using Moq;

namespace CalculatorAppUnitTest.PresentationTests;

public class CalculationEngineTests
{
    [Fact]
    public void Run_ValidInput_DisplaysResult()
    {
        // Arrange
        var mockValidator = new Mock<IInputValidator>();
        var mockUi = new Mock<IUserInterface>();
        var mockCalculator = new Mock<ICalculator>();
        var validInput = "valid input";
        var exitCommand = "exit";
        var expectedResult = 42.0;

        mockValidator.Setup(v => v.Validate(It.IsAny<string>()))
            .Returns(new ValidationResult(true));
        mockUi.SetupSequence(ui => ui.DisplayMessageAndGetUserInput(It.IsAny<string>(), It.IsAny<ConsoleColor>()))
            .Returns(validInput)
            .Returns(exitCommand);
        mockCalculator.Setup(c => c.Calculate(validInput)).Returns(expectedResult);
        mockUi.Setup(ui => ui.DisplayMessageAndGetUserInput("exit", ConsoleColor.Green));


       var engine = new CalculationEngine(mockValidator.Object, mockUi.Object, mockCalculator.Object);

        // Act
        engine.Run();

        // Assert
        mockUi.Verify(ui => ui.DisplayResultInBox(expectedResult, ConsoleColor.Green), Times.Once());
    }

    
    [Fact]
    public void Run_InvalidInput_DisplaysErrorMessage()
    {
        // Arrange
        var mockValidator = new Mock<IInputValidator>();
        var mockUi = new Mock<IUserInterface>();
        var mockCalculator = new Mock<ICalculator>(); // Mock ICalculator even though it won't be called
        var invalidInput = "invalid input";
        var exitCommand = "exit";
        var errorMessage = "Error message";

        mockValidator.Setup(v => v.Validate(It.IsAny<string>()))
            .Returns(new ValidationResult(false, errorMessage));
        mockUi.SetupSequence(ui => ui.DisplayMessageAndGetUserInput(It.IsAny<string>(), It.IsAny<ConsoleColor>()))
            .Returns(invalidInput)
            .Returns(exitCommand);

        // Use the mock for ICalculator even if it's not expected to be invoked, to avoid null references
        var engine = new CalculationEngine(mockValidator.Object, mockUi.Object, mockCalculator.Object);

        // Act
        engine.Run();

        // Assert
        mockUi.Verify(ui => ui.DisplayMessage(errorMessage, ConsoleColor.Red), Times.Once());
    }

    [Fact]
    public void Run_CalculateThrowsException_DisplaysErrorMessage()
    {
        // Arrange
        var mockValidator = new Mock<IInputValidator>();
        var mockUi = new Mock<IUserInterface>();
        var mockCalculator = new Mock<ICalculator>();
        var input = "valid input that causes exception";
        var exceptionMessage = "Calculation error";
        var exitCommand = "exit";

        // Set up the validator to return a valid result
        mockValidator.Setup(v => v.Validate(It.IsAny<string>()))
            .Returns(new ValidationResult(true));

        // Set up the calculator to throw an exception when Calculate is called
        mockCalculator.Setup(c => c.Calculate(It.IsAny<string>()))
            .Throws(new Exception(exceptionMessage));

        // Set up the UI to return the input that leads to the exception
        mockUi.SetupSequence(ui => ui.DisplayMessageAndGetUserInput(It.IsAny<string>(), It.IsAny<ConsoleColor>()))
            .Returns(input)
            .Returns(exitCommand);

        var engine = new CalculationEngine(mockValidator.Object, mockUi.Object, mockCalculator.Object);

        // Act
        engine.Run();

        // Assert
        // Verify that the UI displays the error message wrapped in "Error: {exceptionMessage}"
        mockUi.Verify(ui => ui.DisplayMessage($"Error: {exceptionMessage}", ConsoleColor.Red), Times.Once());
    }
}
