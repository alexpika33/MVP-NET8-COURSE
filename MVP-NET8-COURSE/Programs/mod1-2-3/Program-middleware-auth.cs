// //middlewares de autenticación
// using System.Security.Claims;
// using Microsoft.AspNetCore.Authentication;
// using Microsoft.AspNetCore.Authentication.Cookies;

// var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddAuthentication()
// .AddCookie();

// // builder.Services.AddAuthentication()
// //     // No hace falta instalar nada, está incluido en Microsoft.AspNetCore.App:
// //     .AddCookie()
// //     // Requiere el paquete Microsoft.AspNetCore.Authentication.Google:
// //     .AddGoogle(googleOptions =>
// //     {
// //         googleOptions.ClientId = config["Authentication:Google:ClientId"];
// //         googleOptions.ClientSecret = config["Authentication:Google:ClientSecret"];
// //     })
// //     // Requiere el paquete Microsoft.AspNetCore.Authentication.Facebook:
// //     .AddFacebook(facebookOptions =>
// //     {
// //         facebookOptions.AppId = config["Authentication:Facebook:AppId"];
// //         facebookOptions.AppSecret = config["Authentication:Facebook:AppSecret"];
// //     });

// // builder.Services
// //     .AddAuthentication("Cookies");
// //     // O bien:
// //     // .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme);
// //     .AddCookie(...)
// //     .AddFacebook(...)
// //     ...

// builder.Services
//        .AddAuthentication()
//        .AddCookie(opt =>
//        {
//            opt.Cookie.Name = "Auth";
//            opt.Cookie.HttpOnly = true;
//            opt.ExpireTimeSpan = TimeSpan.FromDays(30);
//            opt.LoginPath = "/users/login";
//            opt.AccessDeniedPath = "/users/denied";
//        });

//        builder.Services.AddAuthentication(opt =>
// {
//         // Esquema por defecto para autenticar usuarios automáticamente:
//         opt.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;

//         // Definimos el esquema por defecto para "Sign In", por lo que
//         // ya no sería necesario especificarlo en SignInAsync():
//         opt.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

//         // ... // Otras configuraciones por defecto
// })
// .AddCookie();

// // builder.Services // asi especificamos un esquema para todas las operaciones 
// //        .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
// //        .AddCookie(opt => { ... });
// // ...
// // }


// var app = builder.Build();

// app.UseAuthentication();// Esto deberá estar antes de los middlewares que queremos proteger
// //Si el sistema detecta que se configuro en el builder el servicio de autenticación , se añæde automaticamente el middleware
// app.MapGet("login/{name}/{email}", async (HttpContext ctx, string name, string email) =>
// {
//     var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
//     identity.AddClaim(new Claim(ClaimTypes.Name, name));
//     identity.AddClaim(new Claim(ClaimTypes.Email, email));
//     identity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
//     identity.AddClaim(new Claim(ClaimTypes.Role, "Superadmin"));
//     identity.AddClaim(new Claim("MyCustomClaim", "Value"));
//     var principal = new ClaimsPrincipal(identity);

// // El CookieAuthenticationDefaults.AuthenticationScheme proporciona un nombre al esquema de autenticacion, pero podemos usar uno personalizado de la siguiente manera

// /* // Configuración de servicios
// builder.Services
//         .AddAuthentication()
//         .AddCookie("MyApp", opt => { ... });
// ...


// // Login del usuario
// var identity = new ClaimsIdentity("MyApp");
// ...
// await ctx.SignInAsync("MyApp", principal);
// */
//     await ctx.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal); // Esto solo mantienen la cookie con la sesion activa
//     await ctx.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,principal,new AuthenticationProperties() {IsPersistent = true}); // Esto lo hace entre sesiones
//     //Esto genera la cookie , si lo vemos en la network en set-cookie en los headers de la peticion
//     return "Logged in!";
// });

// app.MapGet("/login", (HttpContext ctx) =>
// {
//     if (!ctx.User.Identity.IsAuthenticated)
//     {
//         return "Not logged in!";
//     }

//     var name = ctx.User.Identity.Name;
//     var email = ctx.User.Claims
//                        .FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
//     var roles = string.Join(", ", ctx.User.Claims
//                     .Where(c => c.Type == ClaimTypes.Role)
//                     .Select(c => c.Value)
//     );
//     return $"Logged in {name}, email: {email}, roles: {roles}";
// });

// app.MapGet("logout", async (HttpContext ctx) =>
// {
//     await ctx.SignOutAsync(); /// asi se elimina la cookie
//     return $"Logged out!";
// });
// app.Run();