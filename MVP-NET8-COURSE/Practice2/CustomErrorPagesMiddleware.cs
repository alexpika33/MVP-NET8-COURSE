using Microsoft.AspNetCore.Diagnostics;

public class CustomErrorPagesMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public CustomErrorPagesMiddleware(RequestDelegate next, ILogger<CustomErrorPagesMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Path == "/error/show/500")
        {
            _logger.LogError("Error 500");
            var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
            var exceptionName = exceptionHandlerFeature.Error.GetType().Name;
            await SendHtmlPage(context,
                statusCode: 500,
                title: $"Server error",
                description: $"We have detected a server error {exceptionName}"
            );
        }
        else if (context.Request.Path == "/error/show/404")
        {
                        _logger.LogError("Error 400");

            var statusCodeFeature = context.Features.Get<IStatusCodeReExecuteFeature>();
            var path = statusCodeFeature.OriginalPath;
            await SendHtmlPage(context,
                statusCode: 404,
                title: "Not found",
                description: $"No content found at '{path}'"
            );
        }
        else
        {
            await _next(context);
        }
    }

    private async Task SendHtmlPage(HttpContext context, int statusCode,
                                    string title, string description)
    {
        var content = $@"
                <!DOCTYPE html>
                <html>
                <head>
                    <meta charset='utf-8' />
                    <title>{title}</title>
                    <link href='/styles/calculator.css' rel='stylesheet' />
                </head>
                <body>
                    <h1>
                        <span class='statusCode'>{statusCode}</span> {title}
                    </h1>
                    <p>{description}.</p>
                    <p><a href='javascript:history.back()'>Go back</a>.</p>
                </body>
                </html>
        ";
        context.Response.Clear();
        context.Response.StatusCode = statusCode;
        context.Response.ContentType = "text/html";
        await context.Response.WriteAsync(content);
    }
}
