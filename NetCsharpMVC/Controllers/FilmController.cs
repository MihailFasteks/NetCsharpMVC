using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCsharpMVC.Models;
using System.IO;

namespace NetCsharpMVC.Controllers
{
    public class FilmController : Controller
    {
       private readonly FilmContext db;
        IWebHostEnvironment _appEnvironment;
        public FilmController(FilmContext context, IWebHostEnvironment appEnvironment)
        {
            db = context;
            _appEnvironment = appEnvironment;
        }
        //public async Task<IActionResult> Index()
        //{
        //    //var films = await db.Films.ToListAsync(); 
        //    IEnumerable<Film> films = await Task.Run(() => db.Films);
        //    ViewBag.Films = films;
        //    return View();
        //}
        public async Task<IActionResult> Index()
        {
            return View(await db.Films.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await db.Films
                .FirstOrDefaultAsync(m => m.Id == id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Director,Genr,Year, Description")] Film film, IFormFile posterFile)
        {
            if (ModelState.IsValid)
            {
                if(posterFile!=null)
                {
                    string fileName=Path.GetFileName(posterFile.FileName);
                    string uploadPath = Path.Combine(_appEnvironment.WebRootPath, "Files");
                    string filePath = Path.Combine(uploadPath, fileName);

                    
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await posterFile.CopyToAsync(stream);
                    }
                    film.Poster = "/Files/" + fileName;
                }
                db.Add(film);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(film);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await db.Films.FindAsync(id);
            if (film == null)
            {
                return NotFound();
            }
            return View(film);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Director,Genr,Year, Description")] Film film, IFormFile posterFile)
        {
            if (id != film.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingFilm = await db.Films.AsNoTracking().FirstOrDefaultAsync(f => f.Id == id);
                    if (existingFilm == null)
                    {
                        return NotFound();
                    }
                    if (posterFile != null)
                    {
                        string fileName = Path.GetFileName(posterFile.FileName);
                        string uploadPath = Path.Combine(_appEnvironment.WebRootPath, "Files");

                        if (!Directory.Exists(uploadPath))
                            Directory.CreateDirectory(uploadPath);

                        string filePath = Path.Combine(uploadPath, fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await posterFile.CopyToAsync(stream);
                        }

                        film.Poster = "/Files/" + fileName;
                    }
                    else
                    {
                        
                        film.Poster = existingFilm.Poster;
                    }

                    db.Update(film);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmExists(film.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(film);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await db.Films
                .FirstOrDefaultAsync(m => m.Id == id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var film = await db.Films.FindAsync(id);
            if (film != null)
            {
                db.Films.Remove(film);
            }

            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmExists(int id)
        {
            return db.Films.Any(e => e.Id == id);
        }
      
    }
}
