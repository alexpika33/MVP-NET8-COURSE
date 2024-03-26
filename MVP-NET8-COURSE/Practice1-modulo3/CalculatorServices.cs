public interface ICalculatorServices
{
    int Calculate(int a, int b, string operation);
}

public class CalculatorServices : ICalculatorServices
{
    private readonly ICalculationEngine _calculationEngine;
    private readonly ILogger<CalculatorServices> _logger;

    public CalculatorServices(ICalculationEngine calculationEngine, ILogger<CalculatorServices> logger)
    {
        _calculationEngine = calculationEngine;
        _logger = logger;
    }
   

    public int Calculate(int a, int b, string operation)
    {
        _logger.LogDebug($"Trying to calculate: {a}{operation}{b}");
        switch (operation)
        {
            case "add":
                return _calculationEngine.Add(a, b);
            case "sub":
                return _calculationEngine.Subtract(a, b);
            case "mul":
                return _calculationEngine.Multiply(a, b);
            case "div":
                return _calculationEngine.Divide(a, b);
            default:
                var message = $"Operation '{operation}' not supported";
                throw new ArgumentOutOfRangeException(nameof(operation), message);
        }
    }
}
