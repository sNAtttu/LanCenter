using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LanCenter.Models
{
    public class FoodOrder
    {
        [ScaffoldColumn(false)]
        public int FoodOrderID { get; set; }
        public Player player { get; set; }
        [Display(Name ="Suomalainen kotiruoka")]
        public string FoodName { get; set; }
    }
}
