using LanCenter.Models;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanCenter.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/GamesCustomController")]
    public class GamesCustomController : Controller
    {
        private ApplicationDbContext _context;

        public GamesCustomController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/GamesCustomController
        [HttpGet]
        public IEnumerable<Game> GetCustomGames()
        {
            return _context.Game.ToList();
        }

        // GET: api/GamesCustomController/Diablo 3
        [HttpGet("{gameName}", Name = "GetPlayersByGame")]
        public IActionResult GetPlayersByGame([FromRoute] string gameName)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            var players = (from p in _context.Player
                           join pl in _context.PlayerGameLinker on p.PlayerID equals pl.player.PlayerID
                           join g in _context.Game on pl.game.GameID equals g.GameID
                           where g.Title == gameName
                           select p).ToList();

            if (players.Count <= 0)
            {
                return HttpNotFound();
            }

            return Ok(players);
        }


    }
}
