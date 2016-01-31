using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using LanCenter.Models;
using System.Security.Claims;

namespace LanCenter.Controllers
{
    public class FoodOrdersController : Controller
    {
        private ApplicationDbContext _context;

        public FoodOrdersController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: FoodOrders
        public IActionResult Index()
        {
            var players = _context.Player.ToList();
            var foodOrders = _context.FoodOrder.ToList();
            foreach(var order in foodOrders)
            {
                order.player = players.First(p => p.PlayerID == order.player.PlayerID);
            }
            return View(foodOrders);
        }

        // GET: FoodOrders/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            FoodOrder foodOrder = _context.FoodOrder.Single(m => m.FoodOrderID == id);
            if (foodOrder == null)
            {
                return HttpNotFound();
            }

            return View(foodOrder);
        }

        // GET: FoodOrders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FoodOrders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FoodOrder foodOrder)
        {
            if (ModelState.IsValid)
            {
                var player = _context.Player.Where(p => p.PlayerName == User.GetUserName()).SingleOrDefault();
                foodOrder.player = player;
                _context.FoodOrder.Add(foodOrder);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(foodOrder);
        }

        // GET: FoodOrders/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            FoodOrder foodOrder = _context.FoodOrder.Single(m => m.FoodOrderID == id);
            if (foodOrder == null)
            {
                return HttpNotFound();
            }
            return View(foodOrder);
        }

        // POST: FoodOrders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(FoodOrder foodOrder)
        {
            if (ModelState.IsValid)
            {
                foodOrder.player = _context.Player.Where(p => p.PlayerName == User.GetUserName()).SingleOrDefault();
                _context.Update(foodOrder);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(foodOrder);
        }

        // GET: FoodOrders/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            FoodOrder foodOrder = _context.FoodOrder.Single(m => m.FoodOrderID == id);
            if (foodOrder == null)
            {
                return HttpNotFound();
            }

            return View(foodOrder);
        }

        // POST: FoodOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            FoodOrder foodOrder = _context.FoodOrder.Single(m => m.FoodOrderID == id);
            _context.FoodOrder.Remove(foodOrder);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
