
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// builder.Host -> Configuración del host
// builder.WebHost -> Configuración del servidor
// builder.Services -> Configuración de servicios

//Aqui configuramos los settings, logging, dependencias ...
//El siguiente es un ejemplo de como configurar settings desde un archivo json
// builder.Configuration.AddJsonFile("mysettings.json", optional: false);

//Aqui se añaden los servicios que se injectan
builder.Services.AddControllersWithViews();

// Registra los servicios de Entity Framework Core para SQLite
// builder.Services.AddDbContext<ApplicationDbContext>(
//     options => options.UseSqlite(connectionString: "...")
// ); Creo que aqui no existe el metodo addDbContext por que no tenemos puesto el EntityFramework

// Registra los servicios de autenticación basada en cookies
builder.Services.AddAuthentication().AddCookie();

// Registra los servicios del framework MVC
// builder.Services.AddControllersWithViews();

// Cuando algún componente requiera una instancia de ICalculator,
// el contenedor retornará siempre un nuevo objeto MyCalculator:
// builder.Services.AddTransient<ICalculator, MyCalculator>();

// Cuando en el contexto de una petición los componentes requieran instancias de
// IDataConnection, el contenedor retornará siempre el mismo MyDataConnection,
// que será liberado al finalizar su proceso:
// builder.Services.AddScoped<IDataConnection, MyDataConnection>();

// Se creará una instancia de MyRemoteClient cuando se solicite un IRemoteClient
// por primera vez, y se reutilizará en todas las peticiones posteriores
// durante la vida de la aplicación:
// builder.Services.AddSingleton<IRemoteClient, MyRemoteClient>();

// Usa la factoría para crear la instancia de ICalculator:
// builder.Services.AddTransient<ICalculator>(svc => new MyCalculator());

// var singleton = new MySingleton()
// {
    // TODO: inicializar aquí las propiedades del objeto singleton
// };
// builder.Services.AddSingleton(singleton);

//La key no tiene por que ser texto, es de tipo object
// builder.Services.AddKeyedScoped<IAnimal, Cat>("gato");
// builder.Services.AddKeyedScoped<IAnimal, Dog>("perro");

//Añædir servicios segun entorno
// if(builder.Environment.IsDevelopment())
// {
//     builder.Services.AddSingleton<ISender, FakeSender>();
// }
// else
// {
//     builder.Services.AddSingleton<ISender, EmailSender>();
// }
var app = builder.Build();
//Poniendolo de primero captura todas las excepciones de los middlewares. Este middleware viene por defecto añadido cuando es Development, en stagign y production no viene añadido por defecto da error 500
// if(app.Environment.IsDevelopment())
// {
//     app.UseDeveloperExceptionPage();
// }

//************************************ vamos por la parte de la leccion donde enseña useStatusCodePages - SEGUIR AQUI, STEP 13 ****************************
app.UseStatusCodePages();
app.UseWelcomePage("/welcome"); // un middleware que muestra una pagina de bienvenida en esa ruta si todo fue bien

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/friendlyError500.html"); //Este archivo habria que crearlo dentro de wwwroot en la raiz del proyecto
}

// ¡Importante! Incluir el siguiente middleware es necesario 
// para que la aplicación pueda retornar archivos estáticos:
app.UseStaticFiles();

//Aqui configuramos el comportamiento de la app generada por el builder
app.MapGet("/", (HttpContext context) =>{ 
    var name = (string)context.Request.Query["name"] ?? "Usuario Anónimo 1";
    return Results.Text($"Hola, {name}");
    }
);

//Test para probar el UseDeveloperExceptionPage
app.Run(async (context) =>
{
    if (context.Request.Path == "/boom")
        throw new InvalidOperationException("Invalid operation");

    await context.Response.WriteAsync("Hello, world!");
});

// app.MapGet("/", () =>
//     app.Environment.IsDevelopment()
//         ? "Hello developer!"
//         : "Hello user!"
// );

//Si seteamos otros nombres de entorno diferente a development stagign o production se puede checkear asi:
if(app.Environment.IsEnvironment("Home"))
{
    app.MapGet("/home", () => "This is only available for Home environment");
}
//Asi en teoria se añaden los controladores en MVC
// app.MapDefaultControllerRoute();

app.MapGet("/time",()=>{
    return Results.Text($"La hora actual es: {DateTime.Now}");
});

app.MapGet("/environment", () => app.Environment.EnvironmentName);

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