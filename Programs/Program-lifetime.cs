// //Ciclo de vida
// var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddSingleton<IHostedService, MyBackgroundService>();

// var app = builder.Build();

// var applicationLifetime = app.Services.GetRequiredService<IHostApplicationLifetime>();
// var logFilePath = Path.Combine(app.Environment.ContentRootPath, "log.txt");
// applicationLifetime.ApplicationStarted.Register(async () =>
// {
//     await File.AppendAllTextAsync(logFilePath, DateTime.Now + ": Starting\n");
// });
// applicationLifetime.ApplicationStopping.Register(async () =>
// {
//     await File.AppendAllTextAsync(logFilePath, DateTime.Now + ": Stopping\n");
// });

// app.Run();
