using System;
using eUseControl.Domain.Enums;

namespace eUseControl.Domain.Entities.User
{
     public class UserMinimal
     {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Password { get; set; }
        public URole Level { get; set; }
     }
}
