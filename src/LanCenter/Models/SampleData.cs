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
                var samplePlayer = context.Player.Add(
                    new Player { PlayerName = "Santoro", Points = 9001 }).Entity;

                context.Leaderboard.AddRange(
                    new Leaderboard()
                    {
                        Game = d3
                    }, 
                    new Leaderboard()
                    {
                        Game = chivalry
                    }, 
                    new Leaderboard()
                    {
                        Game = bf4
                    }
                );
                context.SaveChanges();
            }
        }
    }
}