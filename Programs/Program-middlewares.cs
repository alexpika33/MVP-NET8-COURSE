// //ESTO ES PARA MIDDLEWARES PERSONALIZADOS
// using System.Diagnostics;
// var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddTransient<SimpleProfilerMiddleware>();
// var app = builder.Build();

// // var logger = app.Services
// //                 .GetRequiredService<ILoggerFactory>()
// //                 .CreateLogger("Profiler");


// // app.Use(async (context, next) =>
// // {
// //     var watch = Stopwatch.StartNew();
// //     await next(context);
// //     var path = context.Request.Path;
// //     var statusCode = context.Response.StatusCode;
// //     logger.LogDebug($"Path='{path}', status={statusCode}, time={watch.Elapsed}"); //Al principio no me funcionaba pq no estaba bien configurado el nivel de log en el appsettings
// // });
// // app.UseFileServer(enableDirectoryBrowsing: true);

// // app.Run(async ctx =>
// // {
// //     await ctx.Response.WriteAsync("Hello World!");
// // });

// //En el caso de tener que pasar mas parametros al middleare le pasamos los objetos con los parametros que queramos en el UseMiddleware y ademas los añædimos en el constructor del middleware
// app.UseMiddleware<MyCustomMiddleware>();

// //En el siguiente se le crean en el constructor directamente, sin pasarlos por aquí
// app.UseMiddleware<SimpleProfilerMiddleware>();
// app.UseSimpleProfiler();//Esto es lo mismo que lo anterior solo que atraves de su extension

// //Aqui depende de la ruta que coja se pueden configurar diferentes middlewares
// app.Map("/SignalR", (IApplicationBuilder signalrBranch) =>
// {
//     // signalrBranch.UseCors(…);
//     // signalrBranch.UseSignalR(…);
// });

// app.Map("/API", (IApplicationBuilder apiBranch) =>
// {
//     // apiBranch.UseCors(…);
//     // apiBranch.UseLogging(…);
//     // apiBranch.UseNancy(…);
// });

// app.MapWhen(
//     ctx => ctx.Request.Path.StartsWithSegments("/API"),
//     branch =>
//     {
//         // Añadir middlewares para esta rama, por ejemplo:
//         // branch.UseCors();
//     }
// );
// app.MapWhen(
//     ctx => ctx.Request.Cookies.ContainsKey("auth"),
//     branch => {
//         // Añadir middlewares a esta rama del pipeline
//     }
// );


// app.Run();