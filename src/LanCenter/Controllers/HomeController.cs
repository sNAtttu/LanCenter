using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Session;
using Microsoft.AspNet.Http;
using LanCenter.Models;

namespace LanCenter.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var player = _context.Player.Where(p => p.PlayerName == User.GetUserName()).SingleOrDefault();
            if (player != null && player.IsLoggedIn == false)
            {
                player.IsLoggedIn = true;
                _context.SaveChanges();

                var games = (from g in _context.Game
                             join p in _context.PlayerGameLinker on g.GameID equals p.game.GameID
                             where p.player.PlayerID == player.PlayerID
                             select g).ToList();

            }

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
