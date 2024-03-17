namespace CalculatorApp.Models
{
    public class NumberToken : Token
    {
        public double Number { get; }

        public NumberToken(string value) : base(value)
        {
            Number = double.Parse(value);
        }
    }
}
