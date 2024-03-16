// using Lab02.Handlers;

// var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddDistributedMemoryCache();
// builder.Services.AddSession();
// builder.Services.AddAuthorization();
// builder.Services
//     .AddAuthentication()
//     .AddCookie(opt =>
//     {
//         opt.LoginPath = "/login";
//     });
// var app = builder.Build();
// app.UseSession();

// app.MapGet("/login", LoginHandlers.GetLoginPageAsync);
// app.MapPost("/login", LoginHandlers.DoLoginAsync);
// app.MapGet("/logout", LoginHandlers.DoLogoutAsync);

// app.MapGet("/home", HomeHandlers.GetHomePageAsync)
//             .RequireAuthorization();


// app.Run();