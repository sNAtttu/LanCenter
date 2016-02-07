using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LanCenter.ViewModels.Manage
{
    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Nykyinen")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Salasanan pitää olla vähintään {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Uusi")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Vahvista")]
        [Compare("NewPassword", ErrorMessage = "Salasanat eivät mätsää -____-")]
        public string ConfirmPassword { get; set; }
    }
}
