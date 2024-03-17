using Microsoft.AspNetCore.Mvc;

public class TestController: Controller
{
    public IActionResult Index()
    {
        return Content($"What do you want to test?");
    }
    public IActionResult Hello(string id)
    {
        var name = id ?? "user";
        return Content($"Hello from ASP.NET Core MVC, {name}!");
    }
}
