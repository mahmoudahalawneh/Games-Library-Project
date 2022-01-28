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
            Console.WriteLine("Here");
            var game = context.Games.Find(id);
            return View(game);
        }
    }
}
