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
            var games = (context.Games.Include(m => m.Genre).Include(m => m.Publisher).OrderBy(m => m.GameId)).ToList();
            return View(games);
        }
        public IActionResult Detail(int id)
        {
            IQueryable<Game> game = context.Games.Where(g => g.GameId == id).Include(m => m.Genre).Include(m => m.Publisher).OrderBy(m => m.GameId);
            return View(game);
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
                context.Games.Update(game);
                context.SaveChanges();
                return Detail(game.GameId);
            }
            else
            {
                ViewBag.Action = "Edit Game " + game.Name;
                ViewBag.Genre = context.Genres.OrderBy(g => g.Name).ToList();
                ViewBag.Publisher = context.Publishers.OrderBy(p => p.Name).ToList();
                return View(game);
            }
        }
    }
}
