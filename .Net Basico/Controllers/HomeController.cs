using Microsoft.AspNetCore.Mvc;

public class HomeController: Controller
{
    public IActionResult Index()
    {
        return Content("Welcome to my home page!");
    }
}