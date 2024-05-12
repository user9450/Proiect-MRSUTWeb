using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eUseControl.Web.Models
{
    public class UserRegister
    {
        public string Nume { get; set; }

        public string Prenume { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
