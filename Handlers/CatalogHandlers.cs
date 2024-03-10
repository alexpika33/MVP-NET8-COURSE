public class CatalogHandlers
{
    public static async Task Search(HttpContext httpContext, string family, string subfamily, string id)
    {
        httpContext.Response.StatusCode = 201;
        var response = $"You are looking for {id} in {family}>{subfamily}";
        await httpContext.Response.WriteAsync(response);
    }
     public static async Task Browse(HttpContext ctx, int currentPage)
    {
            await ctx.Response.WriteAsync($"Browsing products, page {currentPage}");
    }
}