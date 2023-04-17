using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IS4439_Assignment.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IS4439_Assignment.Controllers
{
    public class AlbumController : Controller
    {
        public IActionResult Index()
        {
            DB db = DB.Retrieve();
            ViewBag.Albums = db.albums.OrderBy(a => a.Title);
            return View();
        }

        public IActionResult LogIn()
        {
            return View();
        }

        public IActionResult CreateAlbum()
        {
            return View();
        }

        [Route("Album/SelectedAlbum/{title}")]
        public IActionResult SelectedAlbum(string title)
        {

            DB db = DB.Retrieve();
            Album album = db.GetAlbum(title);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        public IActionResult AlbumsOfGenre(Genre genre)
        {

            DB db = DB.Retrieve();
            List<Album> albums_of_genre = db.GetAlbumsOfGenre(genre.ToString());
            if (albums_of_genre.Count == 0)
            {
                ViewBag.Message = "This genre has no albums.";
                return View("NotFound");
            }
            ViewBag.Albums = albums_of_genre.OrderBy(a => a.Title); ;
            return View("Index");

        }

        [Route("Album/AlbumsOfExplicit/{flag}")]
        public IActionResult AlbumsOfExplicit(bool flag)
        {

            DB db = DB.Retrieve();
            List<Album> albums_of_explicit = db.GetAlbumsOfExplicit(flag);
            if (albums_of_explicit.Count == 0)
            {
                ViewBag.Message = "No albums found.";
                return View("NotFound");
            }
            ViewBag.Albums = albums_of_explicit.OrderBy(a => a.Title); ;
            return View("Index");

        }

        [HttpPost]
        public IActionResult CreateAlbum(Album album)
        {
            if (ModelState.IsValid)
            {
                DB.AddAlbum(album);
                return View(album);
            }
            else
                return View();

        }

        [HttpPost]
        public IActionResult LogIn(LogInViewModel user)
        {
            if (user.Email == "admin1@gmail.com" && user.Password == "pass")
            {
                return View("CreateAlbum");
            }
            else
            {
                ViewBag.message = "Incorrect email or password";
                return View();
            }

        }
    }
}
