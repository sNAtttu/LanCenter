using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using LanCenter.Models;

namespace LanCenter.Controllers
{
    public class LeaderboardsController : Controller
    {
        private ApplicationDbContext _context;

        public LeaderboardsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Leaderboards
        public IActionResult Index()
        {
            var applicationDbContext = _context.Leaderboard.Include(l => l.Game);
            var games = _context.Game.Select(g => g).ToDictionary(g => g.GameID, g => g.Title);
            var players = _context.Player.Select(p => p).ToDictionary(p => p.PlayerName, p => p.Points);

            foreach(var leaderBoard in applicationDbContext)
            {
                leaderBoard.Title = games.Where(g => g.Key == leaderBoard.GameID).Select(g => g.Value).Single();
            }

            return View(applicationDbContext.ToList());
        }

        // GET: Leaderboards/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Leaderboard leaderboard = _context.Leaderboard.Single(m => m.LeaderboardID == id);
            if (leaderboard == null)
            {
                return HttpNotFound();
            }

            return View(leaderboard);
        }

        // GET: Leaderboards/Create
        public IActionResult Create()
        {
            ViewData["GameID"] = new SelectList(_context.Game, "GameID", "Game");
            return View();
        }

        // POST: Leaderboards/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Leaderboard leaderboard)
        {
            if (ModelState.IsValid)
            {
                _context.Leaderboard.Add(leaderboard);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["GameID"] = new SelectList(_context.Game, "GameID", "Game", leaderboard.GameID);
            return View(leaderboard);
        }

        // GET: Leaderboards/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Leaderboard leaderboard = _context.Leaderboard.Single(m => m.LeaderboardID == id);
            if (leaderboard == null)
            {
                return HttpNotFound();
            }
            ViewData["GameID"] = new SelectList(_context.Game, "GameID", "Game", leaderboard.GameID);
            return View(leaderboard);
        }

        // POST: Leaderboards/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Leaderboard leaderboard)
        {
            if (ModelState.IsValid)
            {
                _context.Update(leaderboard);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["GameID"] = new SelectList(_context.Game, "GameID", "Game", leaderboard.GameID);
            return View(leaderboard);
        }

        // GET: Leaderboards/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Leaderboard leaderboard = _context.Leaderboard.Single(m => m.LeaderboardID == id);
            if (leaderboard == null)
            {
                return HttpNotFound();
            }

            return View(leaderboard);
        }

        // POST: Leaderboards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Leaderboard leaderboard = _context.Leaderboard.Single(m => m.LeaderboardID == id);
            _context.Leaderboard.Remove(leaderboard);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
