
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
//Aqui configuramos los settings, logging, dependencias ...
//El siguiente es un ejemplo de como configurar settings desde un archivo json
// builder.Configuration.AddJsonFile("mysettings.json", optional: false);

var app = builder.Build();

//Aqui configuramos el comportamiento de la app generada por el builder
app.MapGet("/", (HttpContext context) =>{ 
    var name = (string)context.Request.Query["name"] ?? "Usuario Anónimo 1";
    return Results.Text($"Hola, {name}");
    }
);

app.MapGet("/time",()=>{
    return Results.Text($"La hora actual es: {DateTime.Now}");
});

app.MapGet("/sum",(HttpContext context)=>{
    var a = int.Parse(context.Request.Query["a"]);
    var b = int.Parse(context.Request.Query["b"]);
    return Results.Text($"La suma de {a} y {b} es: {a+b}");
});

//Esto introduce un middleware en las pipelines de la app, siendo añadida insitu
// app.Run( async (context)=>{ //Al añædir el middleware de esta manera, es finalizador, por lo que una vez pase por esta pipe se devuelve sin dejar que llegue a las demas
//     await context.Response.WriteAsync("Hello Worls!");
// });
//Para insertalo mas colaborativo seria:
app.Use(async(context,next)=>{
    var watch = Stopwatch.StartNew();
    await next(context);// el next hace que se ceda el control al siguiente middleware de la pipeline
    Debug.WriteLine($"La petición ha tardado: {watch.ElapsedMilliseconds} ms");
});

//Ejemplos de middlewares añadidos
// app.UseDeveloperExceptionPage();
// app.UseAuthentication();
// app.MapDefaultControllerRoute();
 //Con el run vacio se ejecuta la aplicación
app.Run();