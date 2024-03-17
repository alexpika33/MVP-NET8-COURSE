// //*******CACHÉ*************
// // using Microsoft.Extensions.Caching.SqlServer; // habria que añadir este paquete al projecto


// var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddMemoryCache();
// builder.Services.AddResponseCaching();
// builder.Services.AddOutputCache();

// // builder.Services.AddDistributedSqlServerCache(options =>  //Esto es para usar la cache distribuida en sql server , ademas debemos usar el usign de arriba
// // {
// //     options.ConnectionString = @"Data Source=(localdb)\v11.0;Initial Catalog=DistCache;"
// //                                +"Integrated Security=True;";
// //     options.SchemaName = "dbo";
// //     options.TableName = "TestCache";
// // });
// // if(builder.Environment.IsDevelopment())
// // {
// //     builder.Services.AddDistributedMemoryCache(); //settear cache local si es desarrollo
// // }
// // else
// // {
// //     builder.Services.AddDistributedSqlServerCache(options => ... );
// // }


// //Politicas globales
// builder.Services.AddOutputCache(opt =>
// {
//     // Definimos la política "calc":
//     opt.AddPolicy("calc",
//         p => p.Expire(TimeSpan.FromMinutes(5)).SetVaryByQuery("a", "b")
//     );
// });

// //Politicas generales a todos los endpoints
// builder.Services.AddOutputCache(opt =>
// {
//     // Por defecto, todo se cacheará durante 5 segundos:
//     opt.AddBasePolicy(p => p.Expire(TimeSpan.FromSeconds(5)));
// });

// builder.Services.AddOutputCache(opt =>
// {
//     opt.AddBasePolicy(builder =>
//         builder.Expire(TimeSpan.FromDays(1))
//                .With(c => c.HttpContext.Request.Path.StartsWithSegments("/static"))
//     );
//     opt.AddBasePolicy(builder =>
//         builder.NoCache()
//                .With(c => c.HttpContext.Request.Path.StartsWithSegments("/api"))
//     );
// });

// var app = builder.Build();
// app.UseOutputCache();
// app.MapGet("/sum2",
//     (int a, int b) => $"{a + b} -> {DateTime.Now.ToLongTimeString()}"
// ).CacheOutput("calc");

// app.MapGet("/mul",
//     (int a, int b) => $"{a * b} -> {DateTime.Now.ToLongTimeString()}"
// ).CacheOutput("calc");
// app.MapGet("/cached", () => DateTime.Now)
//    .CacheOutput(p => p.Expire(TimeSpan.FromSeconds(5)));

// app.MapGet("/notcached", () => DateTime.Now);
// app.MapGet("/notcached2", () => DateTime.Now)
//    .CacheOutput(p=>p.NoCache());
// app.MapGet("/sum",
//     (int a, int b) => $"{a+b} -> {DateTime.Now.ToLongTimeString()}"
// ).CacheOutput(
//     p => p.Expire(TimeSpan.FromMinutes(10))
//           .SetVaryByQuery("a", "b")
// );
// app.MapGet("/secret", ()=>
// {
//     // Obtener de algún sitio la clave secreta del usuario actual
//     var secret = "Secret key: " + Guid.NewGuid();
//     return secret;
// }
// ).CacheOutput(
//     p => p.Expire(TimeSpan.FromMinutes(10))
//           .SetVaryByHeader("authorization")
// );
// // .CacheOutput(p => p.SetVaryByHost(enabled: false)); //Esto es para que no se compartan los datos cacheados entre distintos nombres de host
// app.MapGet("/cached3", () => DateTime.Now)
//    .CacheOutput(p =>
//         p.Expire(TimeSpan.FromSeconds(10))
//         .With(ctx => DateTime.Now.Second % 2 == 0) /// el WITH es para condicion personalizada
//     );
// app.UseResponseCaching();
// app.MapGet("/", async (context) =>
// {
//     context.Response.Headers["Cache-Control"] = "public, max-age=5";
//     context.Response.ContentType = "text/html";
//     await context.Response.WriteAsync(
//         DateTime.Now.ToString("T")
//         + " <a href='/'>Reload</a>");
// });
// app.UseMiddleware<CounterMiddleware>();
// app.Run();