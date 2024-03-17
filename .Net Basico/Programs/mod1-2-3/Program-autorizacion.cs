// //Autorización en ASP.NET Core
// using Microsoft.AspNetCore.Authentication.Cookies;
// using Microsoft.AspNetCore.Authorization;

// var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddAuthorization();
// builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//     .AddCookie(opt =>
//     {
//         opt.Cookie.Name = "Auth";
//         opt.Cookie.HttpOnly = true;
//         opt.ExpireTimeSpan = TimeSpan.FromDays(30);
//         opt.LoginPath = "/users/login";
//         opt.AccessDeniedPath = "/users/denied";
//     });

// builder.Services.AddAuthorization(options => //Aqui definimos politicas personalizadas
// {
//     options.AddPolicy("SpecialUser",
//         policy => policy.RequireClaim("UserType", "1", "2")
//     );
//     options.AddPolicy("CoolPeople", policy =>
//     policy
//         .RequireAuthenticatedUser()
//         .RequireAssertion(ctx => ctx.User.Identity.Name.ToLower().Contains("x"))
// );

// });



// var app = builder.Build();

// app.UseAuthentication(); //No seria necesario esto pq se configura cuando se añade arriba, se detecta solo
// app.UseAuthorization();

// app.MapGet("/reallyprivate", ()=> "Secret content!")
//          .RequireAuthorization("SpecialUser", "CoolPeople");
// // app.MapGet("/manage", (ManageHandlers.GetHomePageAsync))
// //    .RequireAuthorization(p => p.RequireClaim("admin");

// app.MapGet("/private", () => "Secret content!")
//    .RequireAuthorization();
// app.MapGet("/onlyforadmins", () => "Supersecret content!")
//     .RequireAuthorization(
//         new AuthorizeAttribute { Roles = "Admin,Superadmin" }
//     );

// app.Run();