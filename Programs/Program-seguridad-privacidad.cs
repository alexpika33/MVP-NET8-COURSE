// //Seguridad y privacidad

// using Microsoft.AspNetCore.Http.Features;

// var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddHttpsRedirection(options =>
// {
//     options.RedirectStatusCode = StatusCodes.Status301MovedPermanently;
//     options.HttpsPort = 5001;
// });

// builder.Services.AddHsts(options =>
// {
//     options.Preload = true;
//     options.IncludeSubDomains = true;
//     options.MaxAge = TimeSpan.FromDays(60);
//     options.ExcludedHosts.Add("example.com");
//     options.ExcludedHosts.Add("www.example.com");
// });
// builder.Services.Configure<CookiePolicyOptions>(options =>
// {
//     // Esta lambda es ejecutada en cada petición y su
//     // resultado determinará si las cookies no esenciales
//     // requieren consentimiento del usuario. En este caso,
//     // forzamos que siempre sea necesario el consentimiento:
//     options.CheckConsentNeeded = context => true;
// });
// var app = builder.Build();
// if(!app.Environment.IsDevelopment())
// {
//     app.UseHsts();
// }
// app.UseHttpsRedirection();
// app.Use(async (ctx, next) =>
// {
//     var consentFeature = ctx.Features.Get<ITrackingConsentFeature>();
//     if (consentFeature != null && consentFeature.IsConsentNeeded && !consentFeature.HasConsent)
//     {
//         var cookieString = consentFeature.CreateConsentCookie();
//         var js = $"document.cookie='{cookieString}';this.style.display='none';";
//         var style = "display: block;  position: fixed; bottom: 0; width: 100%; padding: 5px; background-color: #ddd;";
//         await ctx.Response.WriteAsync($"<a href=\"#\" style=\"{style}\" onclick=\"{js}\">Accept cookies</a>"); 
//     }
//     await next(ctx);
// });
// app.MapGet("/set-cookies", async ctx =>
// {
//     ctx.Response.Cookies.Append("essential", "1",
//         new CookieOptions { IsEssential = true });
//     ctx.Response.Cookies.Append("no-essential", "1",
//         new CookieOptions { IsEssential = false });
//     await ctx.Response.WriteAsync("Cookies set!");
// });
// app.MapGet("/grant", async ctx =>
// {
//     var consentFeature = ctx.Features.Get<ITrackingConsentFeature>();
//     consentFeature.GrantConsent();
//     await ctx.Response.WriteAsync("Consent granted!");
// });
// app.Run();