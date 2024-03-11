using BusinessLogic.Core;
using BusinessLogic.Interfaces;
using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
     public class SessionBL : UseraApi, ISession
     {
          public bool UserLogin(ULoginData data)
          {
               throw new NotImplementedException();
          }
     }
}
