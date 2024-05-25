using System.Web.Mvc;
using System.Web.Routing;
using eUseControl.Domain.Enums;
using eUseControl.Web.Controllers;

namespace eUseControl.Web.Attribute
{
     public class AdminModAttribute : ActionFilterAttribute
     {
          public override void OnActionExecuting(ActionExecutingContext filterContext)
          {
               var authCookie = filterContext.HttpContext.Request.Cookies["X-KEY"];

               if (authCookie != null)
               {
                    string authToken = authCookie.Value;
                    var login = new LoginController();
                    var currentUser = login.GetUserDetails(authToken); // get token

                    if (currentUser == null)
                    {
                         filterContext.Result = new RedirectToRouteResult(
                             new RouteValueDictionary
                             {
                            { "controller", "Login" },
                            { "action", "LogIn" },
                            { "errorMessage", "Mai întâi loghează-te." }
                             });
                    }
                    else if (currentUser.Level == URole.User)
                    {
                         filterContext.Result = new RedirectToRouteResult(
                             new RouteValueDictionary
                             {
                            { "controller", "Login" },
                            { "action", "LogIn" },
                            { "errorMessage", "Nu ai permisiuni de a accesa pagina." }
                             });
                    }
                    else if (currentUser.Level == URole.Admin)
                    {
                         base.OnActionExecuting(filterContext);
                    }
                    else
                    {
                         filterContext.Result = new RedirectToRouteResult(
                             new RouteValueDictionary
                             {
                            { "controller", "Login" },
                            { "action", "LogIn" },
                            { "errorMessage", "Nu ai drepturi de a accesa pagina." }
                             });
                    }
               }
               else
               {
                    filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary
                        {
                        { "controller", "Login" },
                        { "action", "LogIn" },
                        { "errorMessage", "Mai întâi loghează-te." }
                        });
               }
          }
     }
}