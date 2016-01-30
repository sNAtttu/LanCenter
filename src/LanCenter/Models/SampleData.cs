using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace LanCenter.Models
{
    public static class SampleData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Game.Any())
            {
                var d3 = context.Game.Add(
                    new Game { FoundFromSteam = true, Genre = "ARPG", Title = "Diablo 3" }).Entity;
                var chivalry = context.Game.Add(
                    new Game { FoundFromSteam = true, Genre = "Action", Title = "Chivalry: Medieval Warfare" }).Entity;
                var bf4 = context.Game.Add(
                    new Game { FoundFromSteam = false, Genre = "Multiplayer FPS", Title = "Battlefield 4" }).Entity;
                var sc2 = context.Game.Add(
                    new Game { FoundFromSteam = false, Genre = "RTS", Title = "StarCraft 2" }).Entity;

                var player1 = context.Player.Add(
                    new Player { PlayerName = "Santeri" }).Entity;
                var player2 = context.Player.Add(
                    new Player { PlayerName = "Risto" }).Entity;
                var player3 = context.Player.Add(
                    new Player { PlayerName = "Tincho" }).Entity;
                var player4 = context.Player.Add(
                    new Player { PlayerName = "Joakim" }).Entity;

                var linkTable = context.PlayerGameLinker.Add(
                    new PlayerGameLinker {player = player1, game = d3, Points = 4000 }).Entity;
                var linkTable1 = context.PlayerGameLinker.Add(
                    new PlayerGameLinker { player = player2, game = d3, Points = 2000 }).Entity;
                var linkTable2 = context.PlayerGameLinker.Add(
                    new PlayerGameLinker { player = player3, game = d3, Points = 3000 }).Entity;
                var linkTable3 = context.PlayerGameLinker.Add(
                    new PlayerGameLinker { player = player4, game = d3, Points = 0 }).Entity;
                var linkTable4 = context.PlayerGameLinker.Add(
                    new PlayerGameLinker { player = player1, game = sc2, Points = 4003 }).Entity;
                var linkTable5 = context.PlayerGameLinker.Add(
                    new PlayerGameLinker { player = player2, game = sc2, Points = 4002 }).Entity;
                var linkTable6 = context.PlayerGameLinker.Add(
                    new PlayerGameLinker { player = player3, game = sc2, Points = 400 }).Entity;


                context.SaveChanges();
            }
        }
    }
}