// public interface ICalculatorServices
// {
//     int Calculate(int a, int b, string operation);
// }

// public class CalculatorServices : ICalculatorServices
// {
//     private readonly ICalculationEngine _calculationEngine;
//     private readonly ILogger<CalculatorServices> _logger;

//     public CalculatorServices(ICalculationEngine calculationEngine, ILogger<CalculatorServices> logger)
//     {
//         _calculationEngine = calculationEngine;
//         _logger = logger;
//     }
   

//     public int Calculate(int a, int b, string operation)
//     {
//         _logger.LogDebug($"Trying to calculate: {a}{operation}{b}");
//         switch (operation)
//         {
//             case "+":
//                 return _calculationEngine.Add(a, b);
//             case "-":
//                 return _calculationEngine.Subtract(a, b);
//             case "*":
//                 return _calculationEngine.Multiply(a, b);
//             case "/":
//                 return _calculationEngine.Divide(a, b);
//             default:
//                 var message = $"Operation '{operation}' not supported";
//                 throw new ArgumentOutOfRangeException(nameof(operation), message);
//         }
//     }
// }
