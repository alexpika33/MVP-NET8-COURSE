// var builder = WebApplication.CreateBuilder(args);
// // builder.Services.AddCors(options => {
// //  options.AddPolicy("OnlyGetAndPostsFromMySites", builder =>
// //     {
// //         builder
// //             .WithMethods("GET", "POST")
// //             .WithOrigins("https://www.mysite.com", "https://www.myothersite.com");
// //     });
// //     });

// builder.Services.AddCors(options =>
// {
//     options.DefaultPolicyName = "OnlyGetAndPostsFromMySites";
//     options.AddPolicy("OnlyGetAndPostsFromMySites", builder =>
//     {
//         builder
//             .WithMethods("GET", "POST")
//             .WithOrigins("www.mysite.com", "www.myothersite.com");
//     });
// });

// //     builder.Services.AddCors(options =>
// // {
// //     options.AddPolicy("TheDoorIsOpened", builder =>
// //     {
// //         builder
// //             .AllowAnyHeader() //con esto estariamos permitiendo cualquier header
// //             .AllowAnyMethod() //con esto estariamos permitiendo cualquier metodo
// //             .AllowAnyOrigin(); //con esto estariamos permitiendo cualquier origen
// //     });
// // });
// var app = builder.Build();
// // app.UseCors("OnlyGetAndPostsFromMySites");
// app.UseCors(); // tiene el default anteiror pq lo configuramos arriba
// app.MapGet("/test", (HttpContext ctx) =>
// {
//     // TODO
// })
// .RequireCors("OnlyGetAndPostsFromMySites");
// app.Run();