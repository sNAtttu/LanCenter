using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LanCenter.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Käyttäjänimi")]
        public string Username { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Laita kunnon sähköposti siihen....")]
        [Display(Name = "Sähköposti")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Salasanan pitää olla ainakin {2} merkkiä.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Salasana")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Vahvista salasana")]
        [Compare("Password", ErrorMessage = "Salasanat eivät ole samat -__-")]
        public string ConfirmPassword { get; set; }
    }
}
