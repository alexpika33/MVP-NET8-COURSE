//En versiones anteriores a ASP.NET Core anteriores a  las 6, aqui se configuran servicios y pipeline
public class Startup1
{
    public void ConfigureServices(IServiceCollection services)
    {
        // Registro de servicios en el IoC
        services.AddControllersWithViews();
        // services.AddSingleton<IMyClass, MyClass>();
        // ...
    }

    public void Configure(IApplicationBuilder app)
    {
        // Configuración del pipeline
        app.UseDeveloperExceptionPage();
        app.UseStaticFiles();
        app.UseAuthentication();
        // ...
   }
}
