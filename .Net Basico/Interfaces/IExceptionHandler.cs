using Microsoft.AspNetCore.Diagnostics;

public class MyExceptionHandler : IExceptionHandler
{
    private readonly ILogger<MyExceptionHandler> _logger;

    public MyExceptionHandler(ILogger<MyExceptionHandler> logger)
    {
        _logger = logger;
    }

    public ValueTask<bool> TryHandleAsync(
        HttpContext httpContext, Exception exception,
        CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "Error processing request");
        return new ValueTask<bool>(true); //Hay que devolver true si el error ha sido manejado para indicar en la pipeline que ya se puede devolver
        //Si se devolviese false, el error pasaria al siguiente middleware y asi sucesivamente
    }
}
