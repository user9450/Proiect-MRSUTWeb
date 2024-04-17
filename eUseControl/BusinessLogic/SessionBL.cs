using System.Web;
using eUseControl.BusinessLogic.Core;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.User;

namespace eUseControl.BusinessLogic
{
     public class SessionBL : UseraApi, ISession
     {
          public ULoginResp UserLogin(ULoginData uLoginData)
          {
               return UserLoginAction(uLoginData);
          }

          public HttpCookie GenCookie(string loginCredential)
          {
               return Cookie(loginCredential);
          }

          public UserMinimal GetUserByCookie(string apiCookieValue)
          {
               return UserCookie(apiCookieValue);
          }
     }
}
