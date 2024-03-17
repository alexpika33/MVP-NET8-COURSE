// //Middleware request timeouts
// using Microsoft.AspNetCore.Http.Timeouts;

// var builder = WebApplication.CreateBuilder(args);
// // builder.Services.AddRequestTimeouts();
// // builder.Services.AddRequestTimeouts(opt =>
// // {
// //     opt.DefaultPolicy = new RequestTimeoutPolicy()
// //     {
// //         Timeout = TimeSpan.FromSeconds(1),
// //         TimeoutStatusCode = 666,
// //         WriteTimeoutResponse = async ctx => await ctx.Response.WriteAsync("Timeout!")
// //     };
// // });
// builder.Services.AddRequestTimeouts(opt =>
// {
//     opt.AddPolicy("Standard", TimeSpan.FromSeconds(5));
//     opt.AddPolicy("Special", new RequestTimeoutPolicy()
//     {
//         Timeout = TimeSpan.FromSeconds(3),
//         TimeoutStatusCode = 666,
//         WriteTimeoutResponse = async ctx => await ctx.Response.WriteAsync("Timeout!")
//     });
// });

// var app = builder.Build();
// app.UseRequestTimeouts();
// app.MapGet("/timeout", async (HttpContext context) =>
// {
//     // ...
// }).WithRequestTimeout("Standard");
// // app.MapGet("/timeout", async (HttpContext context) =>
// // {
// //     await Task.Delay(TimeSpan.FromSeconds(10), context.RequestAborted);
// //     return Results.Content("Done!");
// // }).WithRequestTimeout(TimeSpan.FromSeconds(1));
// app.MapGet("/timeout", async (HttpContext context) =>
// {
//     try
//     {
//         await Task.Delay(TimeSpan.FromSeconds(10), context.RequestAborted);
//         return Results.Content("Done!");
//     }
//     catch (OperationCanceledException)
//     {
//         return Results.Content("Timeout!");
//     }
// }).WithRequestTimeout(TimeSpan.FromSeconds(1));
// app.Run();