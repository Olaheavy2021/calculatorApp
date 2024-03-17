// See https://aka.ms/new-console-template for more information
using CalculatorApp.Services;
using CalculatorApp.Utilities.Helpers;
using CalculatorApp.Services.Interfaces;
using CalculatorApp.Services.BasicCalculator;
using CalculatorApp.Presentation;

// Create instances of necessary services
IInputValidator validator = new InputValidator();
IUserInterface ui = new ConsoleUserInterface();
ICalculatorProcessor processor = new BasicCalculatorProcessor();
ICalculator basicCalculator = new BasicCalculator(processor);

// Start the application's main loop 
var app = new CalculationEngine(validator, ui, basicCalculator);
app.Run();
