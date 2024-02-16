
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", (HttpContext context) =>{ 
    var name = (string)context.Request.Query["name"] ?? "Usuario Anónimo";
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

app.Run();
