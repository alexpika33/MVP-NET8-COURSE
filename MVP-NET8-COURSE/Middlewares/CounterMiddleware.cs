using Microsoft.Extensions.Caching.Memory;

public class CounterMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IMemoryCache _cache;
    public CounterMiddleware(RequestDelegate next, IMemoryCache cache)
    {
        _next = next;
        _cache = cache;
    }

    public async Task Invoke(HttpContext context)
    {
        await _next(context); // Pasamos el control al siguiente middleware

        var count = _cache.Get<int>("visits") + 1;
        _cache.Set("visits", count);
        await context.Response.WriteAsync($"\nTotal visits: {count}");
    }
}
