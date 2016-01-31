using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LanCenter.Models
{
    public class Game
    {
        [ScaffoldColumn(false)]
        public int GameID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Genre { get; set; }
        [Display(Name = "Steam")]
        public bool FoundFromSteam { get; set; }
        public virtual ICollection<Game> Games { get; set; }
    }
}
