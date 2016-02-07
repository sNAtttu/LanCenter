using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LanCenter.ViewModels.Account
{
    public class LoginViewModel
    {
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Käyttäjänimi")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Salasana")]
        public string Password { get; set; }

        [Display(Name = "Muista minut?")]
        public bool RememberMe { get; set; }
    }
}
