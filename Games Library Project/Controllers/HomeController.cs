using Games_Library_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Games_Library_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private GameContext context;
        public HomeController(ILogger<HomeController> logger, GameContext ctx)
        {
            _logger = logger;
            context = ctx;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User use)
        {
            if (ModelState.IsValid)
            {

                var users = context.Users.ToList();
                foreach (var u in users)
                    if (use.UserName == u.UserName && use.Password.Equals(u.Password))
                    {
                        HttpContext.Session.SetInt32("UserKey", u.UserId);
                        return RedirectToAction("List", "Games");
                    }
            }
            return View("Index");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
