using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
namespace workspace.Controllers;

[Route("")]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View(); // This assumes a view named "Index" exists
    }
}