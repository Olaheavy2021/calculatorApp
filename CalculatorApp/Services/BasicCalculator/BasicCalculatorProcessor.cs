namespace CalculatorApp.Services.BasicCalculator
{
    public class BasicCalculatorProcessor : CalculatorProcessorBase
    {
        protected override string TokenPattern => @"(NEG\d+|\d+|\+|\-|\*|\/)";
    }
}
