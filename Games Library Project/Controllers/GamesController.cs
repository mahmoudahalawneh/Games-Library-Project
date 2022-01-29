using Games_Library_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Games_Library_Project.Controllers
{
    public class GamesController : Controller
    {
        private GameContext context { get; set; }
        public GamesController(GameContext ctx)
        {
            context = ctx;
        }
        public IActionResult List()
        {
            return View();
        }
        public IActionResult Detail(int id)
        {
            IQueryable<Game> game = context.Games.Where(g => g.GameId == id).Include(m => m.Genre).Include(m => m.Publisher).OrderBy(m => m.GameId);
            return View(game);
        }
        public IActionResult ListGames()
        {
            var games = (context.Games.Include(m => m.Genre).Include(m => m.Publisher).OrderBy(m => m.GameId)).ToList();
            return View(games);
        }
        [HttpGet]
        public IActionResult EditGame(int id)
        {
            var game = context.Games.Find(id);
            ViewBag.Action = "Edit Game " + game.Name;
            ViewBag.Genre = context.Genres.OrderBy(g => g.Name).ToList();
            ViewBag.Publisher = context.Publishers.OrderBy(p => p.Name).ToList();
            return View(game);
        }
        [HttpPost]
        public IActionResult EditGame(Game game)
        {
            if (ModelState.IsValid)
            {
                if (game.GameId == 0)
                    context.Add(game);
                else 
                    context.Update(game);
                context.SaveChanges();
                return RedirectToAction("ListGames");
            }
            else
            {
                ViewBag.Action = "Edit Game " + game.Name;
                ViewBag.Genre = context.Genres.OrderBy(g => g.Name).ToList();
                ViewBag.Publisher = context.Publishers.OrderBy(p => p.Name).ToList();
                return View(game);
            }
        }
        [HttpGet]
        public IActionResult DeleteGame(int id)
        {
            var game = context.Games.Find(id);
            context.Games.Remove(game);
            context.SaveChanges();
            return RedirectToAction("ListGames");
        }
        [HttpGet]
        public IActionResult AddGame()
        {
            ViewBag.Action = "Add Game";
            ViewBag.Genre = context.Genres.OrderBy(g => g.Name).ToList();
            ViewBag.Publisher = context.Publishers.OrderBy(p => p.Name).ToList();
            return View("EditGame", new Game());
        }
        // End Game stuff

        public IActionResult ListGenres()
        {
            var genres = (context.Genres.OrderBy(g => g.Name).ToList());
            return View(genres);
        }
        [HttpGet]
        public IActionResult EditGenre(string id)
        {
            var genre = context.Genres.Find(id);
            ViewBag.Action = "Edit Genre " + genre.Name;
            return View(genre);
        }
        [HttpPost]
        public IActionResult EditGenre(Genre genre)
        {
            if (ModelState.IsValid)
            {
                if (genre.GenreId == null)
                {
                    genre.GenreId = genre.Name.Substring(0, 2);
                    context.Add(genre);
                }
                else
                    context.Update(genre);
                context.SaveChanges();
                return RedirectToAction("ListGenres");
            }
            else
            {
                ViewBag.Action = "Edit Genre " + genre.Name;
                return View(genre);
            }
        }
        [HttpGet]
        public IActionResult DeleteGenre(string id)
        {
            var genre = context.Genres.Find(id);
            context.Genres.Remove(genre);
            context.SaveChanges();
            return RedirectToAction("ListGenres");
        }
        [HttpGet]
        public IActionResult AddGenre()
        {
            ViewBag.Action = "Add Genre";
            return View("EditGenre", new Genre());
        }
        // End Genre Stuff
        public IActionResult ListPublishers()
        {
            var publishers = (context.Publishers.OrderBy(g => g.Name).ToList());
            return View(publishers);
        }
        [HttpGet]
        public IActionResult EditPublisher(int id)
        {
            var publisher = context.Publishers.Find(id);
            ViewBag.Action = "Edit Publisher " + publisher.Name;
            return View(publisher);
        }
        [HttpPost]
        public IActionResult EditPublisher(Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                if (publisher.PublisherId == 0)
                {
                    context.Add(publisher);
                }
                else
                    context.Update(publisher);
                context.SaveChanges();
                return RedirectToAction("ListPublishers");
            }
            else
            {
                ViewBag.Action = "Edit Publisher " + publisher.Name;
                return View(publisher);
            }
        }
        [HttpGet]
        public IActionResult DeletePublisher(int id)
        {
            var publisher = context.Publishers.Find(id);
            context.Publishers.Remove(publisher);
            context.SaveChanges();
            return RedirectToAction("ListPublishers");
        }
        [HttpGet]
        public IActionResult AddPublisher()
        {
            ViewBag.Action = "Add Publisher";
            return View("EditPublisher", new Publisher());
        }
        // End Publisher Stuff
    }
}
