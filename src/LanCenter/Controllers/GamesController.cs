using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using LanCenter.Models;
using System.Security.Claims;

namespace LanCenter.Controllers
{
    public class GamesController : Controller
    {
        private ApplicationDbContext _context;

        public GamesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Games
        public IActionResult Index()
        {
            return View(_context.Game.ToList());
        }

        // GET: Games/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Game game = _context.Game.Single(m => m.GameID == id);
            if (game == null)
            {
                return HttpNotFound();
            }

            return View(game);
        }

        // GET: Games/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Games/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Game.Add(game);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(game);
        }

        // GET: Games/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Game game = _context.Game.Single(m => m.GameID == id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Update(game);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(game);
        }

        // GET: Games/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Game game = _context.Game.Single(m => m.GameID == id);
            if (game == null)
            {
                return HttpNotFound();
            }

            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Game game = _context.Game.Single(m => m.GameID == id);
            _context.Game.Remove(game);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET
        // Mark game as owned
        public IActionResult MarkOwned(int id)
        {
            Game game = _context.Game.SingleOrDefault(g => g.GameID == id);
            Player player = _context.Player.SingleOrDefault(p => p.PlayerName == User.GetUserName());
            if(player != null && game != null)
            {
                _context.PlayerGameLinker.Add(new PlayerGameLinker { game = game, player = player, Points = 0 });
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        // GET
        // Mark game as owned
        public IActionResult MarkNotOwned(int id)
        {
            Game game = _context.Game.SingleOrDefault(g => g.GameID == id);
            Player player = _context.Player.SingleOrDefault(p => p.PlayerName == User.GetUserName());
            if (player != null && game != null)
            {
                PlayerGameLinker linkToDelete = _context.PlayerGameLinker.Where(p => p.player.PlayerID == player.PlayerID &&
                p.game.GameID == id).Single();
                _context.PlayerGameLinker.Remove(linkToDelete);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
