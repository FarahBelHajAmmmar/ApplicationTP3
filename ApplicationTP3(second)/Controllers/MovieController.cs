using ApplicationTP3_second_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace ApplicationTP3_second_.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment webHostEnvironment;
        public MovieController(ApplicationDbContext db,IWebHostEnvironment webHost)
        {
            _db = db;
            webHostEnvironment = webHost;

        }
        public IActionResult Index()
        {
            var movies = _db.Movies.ToList();
            return View(movies);
        }

        public IActionResult Create()
            
        {
            
            return View();
        }
        private string UploadedFile(Movies movie)
        {
            string uniquefilename = null;
            if (movie.FrontImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniquefilename = Guid.NewGuid().ToString() + "_" + movie.FrontImage.FileName;
                string filepath = Path.Combine(uploadsFolder, uniquefilename);
                using (var fileStream = new FileStream(filepath, FileMode.Create))
                {
                    movie.FrontImage.CopyTo(fileStream);
                }
            }
            return uniquefilename;
        }
        [HttpPost]
        public IActionResult Create (Movies m)
        {
            String uniquefilename = UploadedFile(m);
            m.ImageURL = uniquefilename;
            _db.Attach(m);
            _db.Entry(m).State = EntityState.Added;
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
