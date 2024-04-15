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
          public ULoginResp UserLogin(ULoginData uLoginData)
          {
               return UserLoginAction(uLoginData);
          }

          public HtttpCookie GenCookie(string loginCredential)
          {
               return Cookie(loginCredential);
          }

          public UserMinimal GetUserByCookie(string apiCookieValue)
          {
               return UserCookie(apiCookieValue);
          }
     }
}
