using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using LanCenter.Models;

namespace LanCenter.Controllers
{
    public class PlayerGameLinkersController : Controller
    {
        private ApplicationDbContext _context;

        public PlayerGameLinkersController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: PlayerGameLinkers
        public IActionResult Index()
        {
            return View(_context.PlayerGameLinker.ToList());
        }

        // GET: PlayerGameLinkers/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            PlayerGameLinker playerGameLinker = _context.PlayerGameLinker.Single(m => m.PlayerGameLinkerID == id);
            if (playerGameLinker == null)
            {
                return HttpNotFound();
            }

            return View(playerGameLinker);
        }

        // GET: PlayerGameLinkers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlayerGameLinkers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PlayerGameLinker playerGameLinker)
        {
            if (ModelState.IsValid)
            {
                _context.PlayerGameLinker.Add(playerGameLinker);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(playerGameLinker);
        }

        // GET: PlayerGameLinkers/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            PlayerGameLinker playerGameLinker = _context.PlayerGameLinker.Single(m => m.PlayerGameLinkerID == id);
            if (playerGameLinker == null)
            {
                return HttpNotFound();
            }
            return View(playerGameLinker);
        }

        // POST: PlayerGameLinkers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PlayerGameLinker playerGameLinker)
        {
            if (ModelState.IsValid)
            {
                _context.Update(playerGameLinker);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(playerGameLinker);
        }

        // GET: PlayerGameLinkers/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            PlayerGameLinker playerGameLinker = _context.PlayerGameLinker.Single(m => m.PlayerGameLinkerID == id);
            if (playerGameLinker == null)
            {
                return HttpNotFound();
            }

            return View(playerGameLinker);
        }

        // POST: PlayerGameLinkers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            PlayerGameLinker playerGameLinker = _context.PlayerGameLinker.Single(m => m.PlayerGameLinkerID == id);
            _context.PlayerGameLinker.Remove(playerGameLinker);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
