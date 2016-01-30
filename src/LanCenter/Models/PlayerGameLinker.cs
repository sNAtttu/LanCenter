using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LanCenter.Models
{
    public class PlayerGameLinker
    {
        [ScaffoldColumn(false)]
        public int PlayerGameLinkerID { get; set; }

        public Game game  { get; set; }

        public Player player { get; set; }
        [Required]
        public int Points { get; set; }

    }
}
