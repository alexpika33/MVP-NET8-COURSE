// //THIS IS FOR PRACTICA 1
// var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddTransient<IOperationFormatter, OperationFormatter>();
// builder.Services.AddTransient<IAdder, BasicCalculator>();

// var app = builder.Build();
// // app.Run(async (context) =>
// // {
// //     var msg = $"Current environment: {app.Environment.EnvironmentName}";
// //     await context.Response.WriteAsync(msg);
// // });

// // if (app.Environment.IsDevelopment())
// // {
// //     app.Run(async (context) =>
// //     {
// //         await context.Response.WriteAsync("Development environment");
// //     });
// // }
// // else
// // {
// //     app.Run(async (context) =>
// //     {
// //         await context.Response.WriteAsync("No development environment");
// //     });
// // }

// app.Use(async (ctx, next) =>
// {
//     if (ctx.Request.Path == "/hello-world")
//     {
//         // Procesa la petición y no permite la ejecución de middlewares posteriores
//         await ctx.Response.WriteAsync("Hello, world!");
//     }
//     else
//     {
//         // Pasa el control al siguiente middleware
//         await next(ctx);
//     }
// });
// app.Use(async (ctx, next) =>
// {
//     if (ctx.Request.Path.ToString().StartsWith("/hello"))
//     {
//         // Procesa la petición y no permite la ejecución de otros middlewares
//         await ctx.Response.WriteAsync("Hello, user!");
//     }
//     else
//     {
//         // Pasa la petición al siguiente middleware
//         await next(ctx);
//     }
// });

// app.Run(async (context) =>
// {
//     if (context.Request.Path == "/add")
//     {
//         int a = 0, b = 0;
//         int.TryParse(context.Request.Query["a"], out a);
//         int.TryParse(context.Request.Query["b"], out b);

//         var adder = context.RequestServices.GetService<IAdder>();
//         await context.Response.WriteAsync(adder.Add(a, b));
//     }
//     else
//     {
//         await context.Response.WriteAsync($"Try again!");
//     }
// });

// // Request Info middleware
// // app.Run(async ctx =>
// // {
// //     await ctx.Response.WriteAsync($"Path requested: {ctx.Request.Path}");
// // });




// app.Run();
