namespace Microsoft.AspNetCore.Builder
{
    public static class SimpleProfilerExtensions
    {
        public static IApplicationBuilder UseSimpleProfiler(this IApplicationBuilder app)
        {
            app.UseMiddleware<SimpleProfilerMiddleware>();
            return app;
        }
    }
}
