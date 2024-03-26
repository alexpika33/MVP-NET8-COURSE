using Microsoft.AspNetCore.Mvc;
public class BlogController: Controller
{
    private readonly IBlogServices _blogServices;

    public BlogController(IBlogServices blogServices)
    {
        _blogServices = blogServices;
    }

    // Implementar métodos de acción aquí
    public IActionResult Index()
    {
    var posts = _blogServices.GetLatestPosts(10); // 10 posts más recientes
    // return View("Index", posts);
    //Nota: acabamos de presentar una nueva convención: si el nombre de la vista que deseamos retornar al usuario coincide con el nombre de la acción en la que nos encontramos, no será necesario indicarlo de forma explícita.
    return View(posts); // "Index" por defecto
    }

    public IActionResult Archive(int year, int month)
    {
        var posts = _blogServices.GetPostsByDate(year, month);
        return View(posts);
    }

    public IActionResult Save(Product product)
    {
    //    ...
    return RedirectToAction("Index");
    }

    [Route("blog/{slug}")]
    public IActionResult ViewPost(string slug)
    {
        var post = _blogServices.GetPost(slug);
        if (post == null)
            return NotFound();
        else
            return View(post);
    }


}

