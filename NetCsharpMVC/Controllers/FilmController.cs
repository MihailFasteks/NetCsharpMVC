using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCsharpMVC.Models;

namespace NetCsharpMVC.Controllers
{
    public class FilmController : Controller
    {
        FilmContext db;
        public FilmController(FilmContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            //var films = await db.Films.ToListAsync(); 
            IEnumerable<Film> films = await Task.Run(() => db.Films);
            ViewBag.Films = films;
            return View();
        }
    }
}
