using Microsoft.AspNetCore.Mvc;

namespace NetCsharpMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
