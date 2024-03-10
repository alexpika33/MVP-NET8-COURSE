// var builder = WebApplication.CreateBuilder(args);


// var app = builder.Build();

// // app.MapGet("/api/calculator/add", (int a, int b) => a + b)
// //    .RequireAuthorization()
// //    .RequireCors("default");
// // app.MapGet("/api/calculator/sub", (int a, int b) => a - b)
// //    .RequireAuthorization()
// //    .RequireCors("default");
// // app.MapGet("/api/calculator/mul", (int a, int b) => a * b)
// //    .RequireAuthorization()
// //    .RequireCors("default");
// // ...
// var calculatorApi = app.MapGroup("/api/calculator")
//     .RequireAuthorization()
//     .RequireCors("default");

// calculatorApi.MapGet("add/{a}/{b}", (int a, int b) => a + b);
// calculatorApi.MapGet("sub/{a}/{b}", (int a, int b) => a - b);
// calculatorApi.MapGet("mul/{a}/{b}", (int a, int b) => a * b);

// app.MapGet("/hello/{name}", (string name) => $"Hello, {name}")
//     .AddEndpointFilter(async (context, next) =>
//     {
//         var name = context.HttpContext.GetRouteValue("name")?.ToString();
//         if ("albert".Equals(name, StringComparison.OrdinalIgnoreCase))
//             return Results.BadRequest("No Alberts allowed!");

//         return await next(context);
//     });


// var calculatorApi2 = app.MapGroup("/api/calculator")
//     .AddEndpointFilter<MiniProfiler>()
//     .RequireAuthorization()
//     .RequireCors("default");

