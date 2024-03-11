﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.User
{
     public class ULoginData
     {
          public string Credential { get; set; }
          public string Password { get; set; }
          public string LoginIP { get; set; }
          public DateTime LoginDateTime { get; set; }

     }
}
