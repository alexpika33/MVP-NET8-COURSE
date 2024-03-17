//En versiones anteriores a ASP.NET Core anteriores a  las 6, aqui iria la configuracion solo del Host y servidor
public class Program1
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args)
            .Build()
            .Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup1>();
            });
}
