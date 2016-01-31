using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using LanCenter.Models;
using System.Security.Claims;

namespace LanCenter.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/FoodOrders")]
    public class FoodOrdersController : Controller
    {
        private ApplicationDbContext _context;

        public FoodOrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FoodOrders
        [HttpGet]
        public IEnumerable<FoodOrder> GetFoodOrder()
        {
            return _context.FoodOrder;
        }

        // GET: api/FoodOrders/sNAttu
        [HttpGet("{id}", Name = "GetFoodOrder")]
        public IActionResult GetFoodOrder([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            var fo = (from g in _context.FoodOrder
                      where g.player.PlayerName == id
                      select g).ToList();

            if (fo.Count == 0)
            {
                return HttpNotFound();
            }

            return Ok(fo);
        }

        // PUT: api/FoodOrders/5
        [HttpPut("{id}")]
        public IActionResult PutFoodOrder(int id, [FromBody] FoodOrder foodOrder)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != foodOrder.FoodOrderID)
            {
                return HttpBadRequest();
            }

            _context.Entry(foodOrder).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodOrderExists(id))
                {
                    return HttpNotFound();
                }
                else
                {
                    throw;
                }
            }

            return new HttpStatusCodeResult(StatusCodes.Status204NoContent);
        }

        // POST: api/FoodOrders
        [HttpPost]
        public IActionResult PostFoodOrder([FromBody] FoodOrder foodOrder)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.FoodOrder.Add(foodOrder);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (FoodOrderExists(foodOrder.FoodOrderID))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetFoodOrder", new { id = foodOrder.FoodOrderID }, foodOrder);
        }

        // DELETE: api/FoodOrders/5
        [HttpDelete("{id}")]
        public IActionResult DeleteFoodOrder(int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            FoodOrder foodOrder = _context.FoodOrder.Single(m => m.FoodOrderID == id);
            if (foodOrder == null)
            {
                return HttpNotFound();
            }

            _context.FoodOrder.Remove(foodOrder);
            _context.SaveChanges();

            return Ok(foodOrder);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FoodOrderExists(int id)
        {
            return _context.FoodOrder.Count(e => e.FoodOrderID == id) > 0;
        }
        public Player GetPlayer()
        {
            var player = _context.Player.Where(p => p.PlayerName == User.GetUserName()).SingleOrDefault();
            if (player != null) return player;
            return null;
        }
    }
}