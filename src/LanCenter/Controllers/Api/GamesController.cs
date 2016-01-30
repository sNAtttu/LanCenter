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
    [Route("api/Games")]
    public class GamesController : Controller
    {
        private ApplicationDbContext _context;

        public GamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Games
        [HttpGet]
        public IEnumerable<Game> GetGame()
        {
            return _context.Game;
        }

        // GET: api/Games/sNAttu
        [HttpGet("{id}", Name = "GetGame")]
        public IActionResult GetGame([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }
            var games = (from g in _context.Game
                         join p in _context.PlayerGameLinker on g.GameID equals p.game.GameID
                         where p.player.PlayerName == id
                         select g).ToList();

            if (games == null)
            {
                return HttpNotFound();
            }

            return Ok(games);
        }

        // PUT: api/Games/5
        [HttpPut("{id}")]
        public IActionResult PutGame(int id, [FromBody] Game game)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != game.GameID)
            {
                return HttpBadRequest();
            }

            _context.Entry(game).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(id))
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

        // POST: api/Games
        [HttpPost]
        public IActionResult PostGame([FromBody] Game game)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }
            _context.Game.Add(game);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GameExists(game.GameID))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetGame", new { id = game.GameID }, game);
        }

        // DELETE: api/Games/5
        [HttpDelete("{id}")]
        public IActionResult DeleteGame(int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Game game = _context.Game.Single(m => m.GameID == id);
            if (game == null)
            {
                return HttpNotFound();
            }

            _context.Game.Remove(game);
            _context.SaveChanges();

            return Ok(game);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GameExists(int id)
        {
            return _context.Game.Count(e => e.GameID == id) > 0;
        }
        public Player GetPlayer()
        {
            var player = _context.Player.Where(p => p.PlayerName == User.GetUserName()).SingleOrDefault();
            if (player != null) return player;
            return null;
        }
    }
}