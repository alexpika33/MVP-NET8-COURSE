using System.Diagnostics;

public class SimpleProfilerMiddleware : IMiddleware //Si implementamos esta interfaz , ademas de usar el metodo app.UseMiddleware , hay que registrarlo en builder.Services y como queramos, si transcient singleton o scoped
{
        //La instancia de este middleware se crea una vez al inicio de la aplicacion, al metodo Invoko se le pasa el contexto y entra por cada peticion que se realiza 
        //aqui hay que estar atentos si no llega, por que eso significaria que un middleware anterior ha cortado la cadena de llamadas
    // private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public SimpleProfilerMiddleware(/*RequestDelegate next*/ ILogger<SimpleProfilerMiddleware> logger)
    {
        // _next = next;
        _logger = logger;
    }
   
    // public async Task Invoke(HttpContext context) //Si fuesen servicios con ciclo de vida scoped o per request habria que meterlos aqui en el Invoke
    // {
    //     var watch = Stopwatch.StartNew();
    //     await _next(context);
    //     var path = context.Request.Path;
    //     var statusCode = context.Response.StatusCode;
    //     _logger.LogDebug($"Path='{path}', status={statusCode}, time={watch.Elapsed}");
    // }

     public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var watch = Stopwatch.StartNew();
        await next(context);
        var path = context.Request.Path;
        var statusCode = context.Response.StatusCode;
        _logger.LogDebug(
            $"Path='{path}', status={statusCode}, time={watch.Elapsed}"
        );
    }
}
