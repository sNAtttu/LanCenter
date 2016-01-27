using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LanCenter.Models
{
    public class Player
    {
        [ScaffoldColumn(false)]
        public int PlayerID { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string PlayerName { get; set; }
        public int Points { get; set; }
    }
}
