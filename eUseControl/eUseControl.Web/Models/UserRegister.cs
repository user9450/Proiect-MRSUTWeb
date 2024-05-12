using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eUseControl.Web.Models
{
    public class UserRegister
    {
        [Required(ErrorMessage = "Numele e obligatoriu.")]
        public string Nume { get; set; }

        [Required(ErrorMessage = "Prenumele e obligatoriu.")]
        public string Prenume { get; set; }

        [Required(ErrorMessage = "Poșta e obligatorie.")]
        [EmailAddress(ErrorMessage = "Poșta nu e validă.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Parola e obligatorie")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirmarea parolei e obligatorie.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Parolele nu sunt aceleași.")]
        public string ConfirmPassword { get; set; }
    }
}
