// //VARIABLES DE SESION
// // using Microsoft.AspNetCore.Session;
// // para guardar datos de la sesion utiliza caché
// var builder = WebApplication.CreateBuilder(args);

//  builder.Services.AddDistributedMemoryCache();// para guardar datos de la sesion utiliza caché , el mejor seria el de redis pero harian falta otros paquetes
//  //AddStackExchangeRedisCache para usar el de redis
//  builder.Services.AddSession();


// var app = builder.Build();

// app.UseSession();
// // app.UseSession(new SessionOptions()
// // {
// //     Cookie =
// //     {
// //         Name = ".MySession",
// //         HttpOnly = true,
// //     },
// //     IdleTimeout = TimeSpan.FromMinutes(15)
// // });
// //a las variables se accede a traves de httpContext.Session de tipo ISession
// app.MapGet("visits", (HttpContext ctx) => // esto es de forma SINCRONA
// {
//     var newCount = ctx.Session.GetInt32("count").GetValueOrDefault() + 1;
//     ctx.Session.SetInt32("count", newCount);
//     return $"Your visits: {newCount}";
// });

// app.MapGet("visits1", async (HttpContext context) => //asincrona
// {
//     await context.Session.LoadAsync();
//     var newCount = context.Session.GetInt32("count").GetValueOrDefault() + 1;
//         return $"Your visits: {newCount}";

// });

// app.MapGet("reset",(HttpContext ctx) =>
// {
//     ctx.Session.Clear();
//     return "Reseted";
// });

// app.Run();
