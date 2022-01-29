using Games_Library_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        private bool checkLogin()
        {
            return HttpContext.Session.GetInt32("UserKey") !=null ;
        }
        private int getKey()
        {
            return (int)HttpContext.Session.GetInt32("UserKey");
        }
        public IActionResult List()
        {
            if (!checkLogin()) return RedirectToAction("Index", "Home");
            return View();
        }
        public IActionResult Detail(int id)
        {
            if (!checkLogin()) return RedirectToAction("Index", "Home");
            IQueryable<Game> game = context.Games.Where(g => g.GameId == id).Include(m => m.Genre).Include(m => m.Publisher).OrderBy(m => m.GameId);
            return View(game);
        }
        [HttpGet]
        public IActionResult ListGames()
        {
            if (!checkLogin()) return RedirectToAction("Index", "Home");
            List<Game> games = new List<Game>();
            foreach (Game g in (context.Games.Include(m => m.Genre).Include(m => m.Publisher).OrderBy(m => m.GameId)).ToList())
                if (g.UserId == getKey())
                    games.Add(g);
            return View(games);
        }
        [HttpPost]
        public IActionResult ListGames(string g)
        {
            if (!checkLogin()) return RedirectToAction("Index", "Home");
            if (g == null)
                return RedirectToAction("ListGames");
            else
            {
                var AllGames = context.Games.Include(m => m.Genre).Include(m => m.Publisher).OrderBy(m => m.GameId).ToList();
                List<Game> games = new List<Game>();
                foreach (var Gam in AllGames)
                {
                    if (Gam.Name.Contains(g) && Gam.UserId == getKey())
                        games.Add(Gam);
                }
                return View(games);
            }
        }
        [HttpGet]
        public IActionResult EditGame(int id)
        {
            if (!checkLogin()) return RedirectToAction("Index", "Home");
            var game = context.Games.Find(id);
            ViewBag.Action = "Edit Game " + game.Name;
            List<Genre> genres = new List<Genre>();
            foreach (var g in (context.Genres.OrderBy(g => g.Name).ToList()))
                if (g.UserId == getKey())
                    genres.Add(g);
            ViewBag.Genre = genres;

            List<Publisher> publishers = new List<Publisher>();
            foreach (var g in (context.Publishers.OrderBy(g => g.Name).ToList()))
                if (g.UserId == getKey())
                    publishers.Add(g);
            ViewBag.Publisher = publishers;
            return View(game);
        }
        [HttpPost]
        public IActionResult EditGame(Game game)
        {
            if (!checkLogin()) return RedirectToAction("Index", "Home");
            if (ModelState.IsValid)
            {
                if (game.GameId == 0)
                {
                    game.UserId = getKey();
                    context.Add(game);
                }
                else
                    context.Update(game);
                context.SaveChanges();
                return RedirectToAction("ListGames");
            }
            else
            {
                ViewBag.Action = "Edit Game " + game.Name;
                List<Genre> genres = new List<Genre>();
                foreach (var g in (context.Genres.OrderBy(g => g.Name).ToList()))
                    if (g.UserId == getKey())
                        genres.Add(g);
                ViewBag.Genre = genres;

                List<Publisher> publishers = new List<Publisher>();
                foreach (var g in (context.Publishers.OrderBy(g => g.Name).ToList()))
                    if (g.UserId == getKey())
                        publishers.Add(g);
                ViewBag.Publisher = publishers;
                return View(game);
            }
        }
        [HttpGet]
        public IActionResult DeleteGame(int id)
        {
            if (!checkLogin()) return RedirectToAction("Index", "Home");
            var game = context.Games.Find(id);
            context.Games.Remove(game);
            context.SaveChanges();
            return RedirectToAction("ListGames");
        }
        [HttpGet]
        public IActionResult AddGame()
        {
            if (!checkLogin()) return RedirectToAction("Index", "Home");
            ViewBag.Action = "Add Game";
            List<Genre> genres = new List<Genre>();
            foreach (var g in (context.Genres.OrderBy(g => g.Name).ToList()))
                if (g.UserId == getKey())
                    genres.Add(g);
            ViewBag.Genre = genres;

            List<Publisher> publishers = new List<Publisher>();
            foreach (var g in (context.Publishers.OrderBy(g => g.Name).ToList()))
                if (g.UserId == getKey())
                    publishers.Add(g);
            ViewBag.Publisher = publishers;
            return View("EditGame", new Game());
        }
        // End Game stuff
        [HttpGet]
        public IActionResult ListGenres()
        {
            if (!checkLogin()) return RedirectToAction("Index", "Home");
            List<Genre> genres = new List<Genre>();
            foreach (var g in (context.Genres.OrderBy(g => g.Name).ToList()))
                if (g.UserId == getKey())
                    genres.Add(g);
            return View(genres);
        }
        [HttpPost]
        public IActionResult ListGenres(string g)
        {
            if (!checkLogin()) return RedirectToAction("Index", "Home");
            if (g == null)
                return RedirectToAction("ListGenres");
            else
            {
                var AllGenres = (context.Genres.OrderBy(g => g.Name).ToList());
                List<Genre> genres = new List<Genre>();
                foreach (var Gen in AllGenres)
                {
                    if (Gen.Name.Contains(g) && Gen.UserId == getKey())
                        genres.Add(Gen);
                }
                return View(genres);
            }
        }
        [HttpGet]
        public IActionResult EditGenre(string id)
        {
            if (!checkLogin()) return RedirectToAction("Index", "Home");
            var genre = context.Genres.Find(id);
            ViewBag.Action = "Edit Genre " + genre.Name;
            return View(genre);
        }
        [HttpPost]
        public IActionResult EditGenre(Genre genre)
        {
            if (!checkLogin()) return RedirectToAction("Index", "Home");
            if (ModelState.IsValid)
            {
                if (genre.GenreId == null)
                {
                    genre.UserId = getKey();
                    genre.GenreId = (getKey()*10).ToString()+genre.Name.Substring(0, 2);
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
            if (!checkLogin()) return RedirectToAction("Index", "Home");
            var genre = context.Genres.Find(id);
            context.Genres.Remove(genre);
            context.SaveChanges();
            return RedirectToAction("ListGenres");
        }
        [HttpGet]
        public IActionResult AddGenre()
        {
            if (!checkLogin()) return RedirectToAction("Index", "Home");
            ViewBag.Action = "Add Genre";
            return View("EditGenre", new Genre());
        }
        // End Genre Stuff
        [HttpGet]
        public IActionResult ListPublishers()
        {
            if (!checkLogin()) return RedirectToAction("Index", "Home");
            List<Publisher> publishers = new List<Publisher>();
            foreach (var g in (context.Publishers.OrderBy(g => g.Name).ToList()))
                if (g.UserId == getKey())
                    publishers.Add(g);
            return View(publishers);
        }
        [HttpPost]
        public IActionResult ListPublishers(string g)
        {
            if (!checkLogin()) return RedirectToAction("Index", "Home");
            if (g == null)
                return RedirectToAction("ListGenres");
            else
            {
                var AllPublishers = (context.Publishers.OrderBy(g => g.Name).ToList());
                List<Publisher> publishers = new List<Publisher>();
                foreach (var Pub in AllPublishers)
                {
                    if (Pub.Name.Contains(g) && Pub.UserId == getKey())
                        publishers.Add(Pub);
                }
                return View(publishers);
            }
        }
        [HttpGet]
        public IActionResult EditPublisher(int id)
        {
            if (!checkLogin()) return RedirectToAction("Index", "Home");
            var publisher = context.Publishers.Find(id);
            ViewBag.Action = "Edit Publisher " + publisher.Name;
            return View(publisher);
        }
        [HttpPost]
        public IActionResult EditPublisher(Publisher publisher)
        {
            if (!checkLogin()) return RedirectToAction("Index", "Home");
            if (ModelState.IsValid)
            {
                if (publisher.PublisherId == 0)
                { 
                    publisher.UserId = getKey();
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
            if (!checkLogin()) return RedirectToAction("Index", "Home");
            var publisher = context.Publishers.Find(id);
            context.Publishers.Remove(publisher);
            context.SaveChanges();
            return RedirectToAction("ListPublishers");
        }
        [HttpGet]
        public IActionResult AddPublisher()
        {
            if (!checkLogin()) return RedirectToAction("Index", "Home");
            ViewBag.Action = "Add Publisher";
            return View("EditPublisher", new Publisher());
        }
        // End Publisher Stuff
    }
}
