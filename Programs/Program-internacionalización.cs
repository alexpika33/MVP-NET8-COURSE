// using System.Globalization;
// using LocalizationDemo.Middlewares;
// using Microsoft.AspNetCore.Localization;
// using Microsoft.Extensions.Localization;

// CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
// CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US");

// var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

// var app = builder.Build();
// app.UseMiddleware<SetCultureMiddleware>();
// app.UseMiddleware<HelloWorldMiddleware>();


// var supportedCultures = new[]
// {
//     new CultureInfo("en-US"),
//     new CultureInfo("es-ES")
// };
// var locOptions = new RequestLocalizationOptions
// {
//     DefaultRequestCulture = new RequestCulture("en-US"),
//     SupportedCultures = supportedCultures,
//     SupportedUICultures = supportedCultures
// };
// var acceptHeadersProvider = locOptions.RequestCultureProviders
//     .OfType<AcceptLanguageHeaderRequestCultureProvider>()
//     .FirstOrDefault();
// locOptions.RequestCultureProviders.Remove(acceptHeadersProvider);

// // O, si estamos seguros de su posición en la colección:
// locOptions.RequestCultureProviders.RemoveAt(2);

// var queryStringProvider = locOptions.RequestCultureProviders
//                             .OfType<QueryStringRequestCultureProvider>()
//                             .FirstOrDefault();

// if (queryStringProvider != null)
// {
//     queryStringProvider.QueryStringKey = "lang";//keys especificas para setear los valores desde la query string
//     queryStringProvider.UIQueryStringKey = "ui-lang";
// }
// app.UseRequestLocalization(locOptions);

// var supportedCultures2 = new[] { "es-ES", "en-US" };
// app.UseRequestLocalization(options =>
//     options
//         .SetDefaultCulture("en-us")
//         .AddSupportedCultures(supportedCultures2)
//         .AddSupportedUICultures(supportedCultures2)
// );

// locOptions.RequestCultureProviders.Insert(0, new CustomRequestCultureProvider(ctx =>
// {
//     var host = ctx.Request.Host.Host.ToLower();
//     if (host.StartsWith("es."))
//         return Task.FromResult(new ProviderCultureResult("es-ES"));
//     return Task.FromResult((ProviderCultureResult)null);
// }));


// app.MapGet("culture/{culture}", async ctx => //cookie para la culture
// {
//     var culture = ctx.GetRouteValue("culture").ToString();
//     ctx.Response.Cookies.Append(
//         key: CookieRequestCultureProvider.DefaultCookieName,
//         value: CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
//         options: new CookieOptions() { Expires = DateTimeOffset.MaxValue }
//     );
//     await ctx.Response.WriteAsync("Culture set to: " + culture);
// });
// app.UseMiddleware<HelloWorldMiddleware>();

// // O alternativamente, usando sintaxis fluida:
// var supportedCultures1 = new[] { "es-ES", "en-US" };
// app.UseRequestLocalization(options =>
//     options
//         .SetDefaultCulture("en-US")
//         .AddSupportedCultures(supportedCultures1)
//         .AddSupportedUICultures(supportedCultures1)
// );

// app.Run();

// namespace LocalizationDemo.Middlewares
// {
//     public class HelloWorldMiddleware
//     {
//         private readonly IStringLocalizer<HelloWorldMiddleware> _loc;

//         public HelloWorldMiddleware(RequestDelegate next, IStringLocalizer<HelloWorldMiddleware> loc)
//         {
//             _loc = loc;
//         }

//         public async Task Invoke(HttpContext context)
//         {
//             var culture = CultureInfo.CurrentCulture.Name;
//             var text = _loc["Message", culture];
//             await context.Response.WriteAsync(text);
//         }
//     }
// }
