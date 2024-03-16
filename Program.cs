//Middlewares de logging http
using Microsoft.AspNetCore.HttpLogging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
      logging.RequestBodyLogLimit = 4096;
      logging.ResponseBodyLogLimit = 4096;
      logging.RequestHeaders.Add("My-Custom-Request-Header");
logging.ResponseHeaders.Add("My-Custom-Response-Header");//encabezados personalizados que son enviados en la traza del registro
     // Usar "logging" para personalizar
          // el comportamiento del middleware
});
// builder.Services.AddW3CLogging(options =>
// {
//       options.FileName = "MyLog";
//       // Los archivos se llamarán MyLog{yyyy}{mm}{dd}.{counter}.txt
//       // Por ejemplo: MyLog20221206.0000.txt
// });
builder.Services.AddW3CLogging(options =>
{
      options.FileName = "MyLog";
      options.LogDirectory = "LogFiles";
      options.FlushInterval = TimeSpan.FromSeconds(5);
      options.FileSizeLimit = 20 * 1024 * 1024; // 20 Mb
      options.LoggingFields = W3CLoggingFields.All;
});
var app = builder.Build();
app.UseHttpLogging();
app.UseW3CLogging();
app.MapGet("/", () => "Hello World!");
app.Run();