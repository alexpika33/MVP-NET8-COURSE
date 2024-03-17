// //Rate limitin
// //Esto se usa para limitar la cantidad de solicitudes que un cliente puede hacer a un servidor en un período de tiempo determinado.
// using System.Threading.RateLimiting;
// using Microsoft.AspNetCore.RateLimiting;

// var builder =   WebApplication.CreateBuilder(args);
// builder.Services.AddRateLimiter(o => o
//     .AddConcurrencyLimiter(
//         policyName: "OnlyOne",
//         configureOptions: opt =>
//         {
//             opt.PermitLimit = 1;
//             opt.QueueLimit = 0;
//             opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
//         }
//     )
//       .AddFixedWindowLimiter(
//         policyName: "TwoEach5Secs",
//         configureOptions: opt =>
//         {
//             opt.PermitLimit = 2;
//             opt.Window = TimeSpan.FromSeconds(5);
//             opt.QueueLimit = 5;
//             opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
//         }
//     )
//     .AddPolicy(
//         policyName: "partitioned",
//         partitioner: ctx =>
//         {
//             var customer = ctx.Request.RouteValues["customerId"]?.ToString();
//             return RateLimitPartition.GetFixedWindowLimiter(
//                 partitionKey: customer,
//                 factory: key => new FixedWindowRateLimiterOptions()
//                 {
//                     PermitLimit = 2,
//                     Window = TimeSpan.FromMinutes(1),
//                     QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
//                     QueueLimit = 0
//                 }
//             );
//         }
//     )
//     .OnRejected = (context, cancellationToken) =>
//     {
//         context.HttpContext.Response.StatusCode = StatusCodes.Status429TooManyRequests;
//         return ValueTask.CompletedTask;
//     }
//     );
// var app = builder.Build();
// app.UseRateLimiter();
// app.MapGet("/", () => Results.Ok(DateTime.Now))
//     .RequireRateLimiting("OnlyOne");
// app.MapGet("/test", () => "Hello World!")
//    .RequireRateLimiting("TwoEach5Secs");
// app.MapGet("/get/{customerId}", (int customerId) => $"Hello customer {customerId}!")
//    .RequireRateLimiting("partitioned");

//    var api = app.MapGroup("/api")
//              .RequireRateLimiting("OnlyOne");

// // Este endpoint se verá afectado por el rate limit del grupo:
// api.MapGet("/", () => "Limited");

// // Este endpoint, aunque pertenece al grupo, deshabilita el rate limit:
// api.MapGet("/unlimited", () => "Unlimited").DisableRateLimiting();
// app.Run();