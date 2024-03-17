// var builder = WebApplication.CreateBuilder(args);
// //TODO: vamos por la parte de utilizacion de endpoint routing a partin de la version 6.0
// var app = builder.Build();
// var logger = app.Services.GetRequiredService<ILoggerFactory>().CreateLogger("EndpointSpy");
// app.UseDeveloperExceptionPage();//Para ver mas info de los fallos

// app.UseRouting();
// app.MapGet("/hello/{name}", (string name) => $"Hello, {name}!");
// app.MapGet("/catalog/{*data}", (string data) => "Request path: " + data);

// app.MapGet("/catalog/{family}/{subfamily}/{id}", CatalogHandlers.Search);
// app.MapGet("/catalog/browse/{currentPage=1}", CatalogHandlers.Browse);

// // app.MapGet("/product/details/{id:int}", async (HttpContext ctx, int id) =>
// // {
// //     var productRepo = ctx.RequestServices.GetRequiredService<IProductRepo>();
// //     var product =  productRepo.GetByIdAsync(id);
// //     if(product == null)
// //     {
// //         ctx.Response.StatusCode = 404;
// //     }
// //     else
// //     {
// //         await ctx.Response.WriteAsync($"Showing product {product.Name}");
// //     }
// // });
// // app.MapGet(
// //       "/catalog/{family}/{subfamily}/{id}",
// //       (string family, string subfamily, string id) =>
// //         $"You are looking for {id} in {family}>{subfamily}"
// // );

// // // En lugar de:
// // app.MapPut("/friends/{id}", async (int id, Friend friend, HttpContext ctx) => {
// //     var repo = ctx.RequestServices.GetRequiredService<IFriendRepo>();
// //     await repo.UpdateAsync(id, friend);
// // });

// // // Podemos usar:
// // app.MapPut("/friends/{id}", async (int id, Friend friend, IFriendRepo repo) => {
// //     await repo.UpdateAsync(id, friend);
// // });
// app.Use(async (ctx, next) =>
// {
//     var endpoint = ctx.GetEndpoint();
//     if (endpoint != null)
//     {
//         var description = endpoint.ToString();
//         logger.LogInformation(description);
//     }
//     else
//     {
//         logger.LogWarning($"{ctx.Request.Path}: No endpoint found!");
//     }
//     await next(ctx);
// });

// // app.UseEndpoints(endpoints =>
// // {
// //     endpoints.MapGet("/", async context =>
// //     {
// //         await context.Response.WriteAsync("Hello World!");
// //     });
// // });

// app.UseEndpoints(endpoints =>
// {
//     endpoints.MapGet("/", async ctx =>
//     {
//         await ctx.Response.WriteAsync("Hello world!");
//     });
//     endpoints.MapGet("/one", async ctx =>
//     {
//         await ctx.Response.WriteAsync("One!");
//     });
//     // endpoints.MapGet("/another/test", async ctx =>
//     // {
//     //     await ctx.Response.WriteAsync("Test");
//     // })
//     // .RequireAuthorization()
//     // .RequireHost("localhost")
//     // .WithDisplayName("This is a test")
//     // .WithMetadata(
//     //     new MyArbitraryMetadataObject(), 3, "Hello", new AnotherMetadataObject()
//     // );
// });

// // app.UseEndpoints(endpoints =>
// // {
// //     endpoints.MapGet("/", async context => {  });
// //     endpoints.MapGet("/login", async context => {  });
// //     endpoints.MapPost("/dologin", async context => {});
// //     endpoints.MapFallback(async ctx=>
// //     {
// //         // Para peticiones que no encajen en ninguno de los anteriores:
// //         await ctx.Response.WriteAsync("This is the default endpoint");
// //     });
// // });
// app.Run();