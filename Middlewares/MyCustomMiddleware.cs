public class MyCustomMiddleware
{
    private readonly RequestDelegate _next;
    public MyCustomMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        // Hacer algo antes de pasar el control al siguiente middleware
        await _next(context); // Pasamos el control al siguiente middleware
        // Hacer algo después de ejecutar el siguiente middleware
    }
}
