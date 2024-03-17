// //Middleares adicionales
// //ResponseCompressionMiddleware ; este middleware se usa para comprimir las respuestas HTTP.
// //RequestDecompressionMiddleware ; este middleware se usa para descomprimir las solicitudes HTTP.
// //RewriteMiddleware ; este middleware se usa para reescribir las URL de solicitud HTTP.
// using System.IO.Compression;
// using Microsoft.AspNetCore.ResponseCompression;
// using Microsoft.AspNetCore.Rewrite;

// var builder = WebApplication.CreateBuilder(args);
// // builder.Services.AddResponseCompression();
// builder.Services.AddResponseCompression(options =>
// {
//     options.Providers.Add<GzipCompressionProvider>();
//     options.MimeTypes = ResponseCompressionDefaults.MimeTypes;
// });
// builder.Services.Configure<GzipCompressionProviderOptions>(
//     options => options.Level = CompressionLevel.Fastest
// );
// builder.Services.AddResponseCompression(options =>
// {
//     // Ojo: por defecto, la compresión sobre HTTPS está deshabilitada
//     options.EnableForHttps = true;
// });

// builder.Services.AddRequestDecompression();

// var app = builder.Build();
// app.UseResponseCompression();
// app.UseRequestDecompression();
// var text = new string('x', 1000000);
// app.Run(async (context) =>
// {
//     context.Response.ContentType = "text/plain";
//     await context.Response.WriteAsync(text);
// });
// var options1 = new RewriteOptions()
//         .AddRewrite(@"app/(\d+)/(\d+)", "application/$2/$1", skipRemainingRules: false);


// var options = new RewriteOptions()
//     .AddRedirectToHttps(302, 5001);
// app.UseRewriter(options);

// var env = app.Environment;
// var options2 = new RewriteOptions()
//     .AddIISUrlRewrite(env.ContentRootFileProvider, "IISUrlConfig.xml");
// app.UseRewriter(options2);

// var options3 = new RewriteOptions()
//     .AddApacheModRewrite(env.ContentRootFileProvider, "ApacheRewriteConfig.txt");
// app.UseRewriter(options3);
// app.Run();