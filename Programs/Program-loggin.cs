// var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddSingleton<MyService>();
// builder.Logging.ClearProviders();
// builder.Logging.AddDebug();

// builder.Logging.SetMinimumLevel(LogLevel.Warning);

// builder.Logging.AddFilter((provider, category, loglevel) =>
//     !category.StartsWith("Microsoft")
//     && loglevel >= LogLevel.Information
// );
// var app = builder.Build();


// // El siguiente mensaje sólo será visible en la ventana Debug de Visual Studio
// // En consola no aparecerá absolutamente nada porque no la hemos añadido
// app.Logger.LogInformation("Configuring pipeline...");

// app.Logger.LogInformation("Inicializando Proceso");
// if(app.Environment.IsDevelopment())
// {
//     app.Logger.LogWarning("Estamos en desarrollo");
// }
// else
// {
//     app.Logger.LogWarning("No estamos en desarrollo");
// }

// app.Run(async ctx =>
// {
//     var service = ctx.RequestServices.GetRequiredService<MyService>();
//     service.DoWork();
//     await ctx.Response.WriteAsync("Hello World!");
// });

// app.Run();