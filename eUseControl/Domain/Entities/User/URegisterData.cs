using eUseControl.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.User
{
    public class URegisterData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [StringLength(30, MinimumLength = 10, ErrorMessage = "Poșta trebuie să conțină de la 10 până la 30 de caractere.")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Nume")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Numele trebuie să conțină de la 5 până la 20 de caractere.")]
        public string Nume { get; set; }

        [Required]
        [Display(Name = "Prenume")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Prenumele trebuie să conțină de la 5 până la 20 de caractere.")]
        public string Prenume { get; set; }

        [Required]
        [Display(Name = "Password")]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Parola trebuie să conțină de la 8 până la 30 de caractere.")]
        public string Password { get; set; }

        public URole Level { get; set; }

        //MAYBE SOME FIXES (?)
    }
}

