using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LanCenter.Models
{
    public class Leaderboard
    {
        [ScaffoldColumn(false)]
        public int LeaderboardID { get; set; }
        [Required]
        [ScaffoldColumn(false)]
        public int GameID { get; set; }
        [Required]
        [ScaffoldColumn(false)]
        public int PlayerID { get; set; }
        public string Title { get; set; }
        public string PlayerName { get; set; }
        public int PlayerPoints { get; set; }
        public virtual ICollection<Leaderboard> Leaderboards { get; set; }
        public virtual Game Game { get; set; }
    }
}
