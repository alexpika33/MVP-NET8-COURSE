using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOptions();
builder.Services.Configure<MyAppSettings>(builder.Configuration);
builder.Configuration.AddIniFile("Config.Files/MySettings.ini", optional: false, reloadOnChange: true); //El parametro reloadOnChange es el que hace que si cambia algo de estos archivos la app lo coge
var env = builder.Environment.EnvironmentName;
builder.Configuration.AddIniFile(
    $"Config.Files/MySettings.{env}.ini",  // Ejemplo: MySettings.Development.ini
    optional: true,
    reloadOnChange: true
);

// builder.WebHost.ConfigureAppConfiguration(config =>
// {
//     var sources = config.Sources
//                         .OfType<JsonConfigurationSource>()
//                         .ToList();
//     foreach (var jsonSource in sources)
//         config.Sources.Remove(jsonSource);

//     var settings = new Dictionary<string, string>
//     {
//         ["title"] = "New title"
//     };
//     config.AddConfiguration.AddInMemoryCollection(settings.Cast<KeyValuePair<string, string?>>());
// }); 
//****TODO: arreglar esto y ademas realizar el siguiente ejercicio************************/
/*
Partiendo de una aplicación ASP.NET Core vacía, añádele un archivo settings .JSON y otro .INI. Puedes usar los que hemos visto en esta lección.

Tras ello, configura el sistema de settings añadiendo como orígenes los dos archivos anteriores, primero el JSON y luego el INI.

Añade al pipeline un middleware simple, como el que hemos visto más arriba, que muestre el valor de varios settings de los contenidos en dichos archivos.

Comprueba que "el último gana" modificando en el archivo .INI el valor de un setting que tengas definidos en ambos archivos de configuración, como la propiedad "Title".

Por último, haz cambios en el código para acceder a la configuración de la aplicación de forma tipada, en lugar de hacerlo a través del IConfiguration.

Comprueba que si modificas el contenido de los archivos de settings que has creado, la aplicación tendrá acceso a los nuevos valores siempre que estés estableciendo a cierto el parámetro reloadOnChanges.


*/
var app = builder.Build();

// app.Run(async (ctx)=>
// {
//     //para que esto funcione o lo ponemos en los settings o iniciamos con dotnet run title="Nombre de la app"
//     await ctx.Response.WriteAsync($"Title:{app.Configuration["title"]}");

//     //en caso de que sea estructura compleja la de configuracion se puede hacer asi:
//     // var stringOption = app.Configuration["options:stringOption"]; // donde options seria el padre de la propiedad stringOption

// });

app.Run(async ctx =>
{
    var options = ctx.RequestServices.GetRequiredService<IOptionsSnapshot<MyAppSettings>>(); //Esto no es muy recomendable, ya que se recomienda inyectar las dependencias en el constructor
    MyAppSettings settings = options.Value;
    var title = settings.Title;
    var stringOption = settings.Options.StringOption;
    await ctx.Response.WriteAsync($"Title: {title}, Options.StringOption: {stringOption}");
});

app.Run();