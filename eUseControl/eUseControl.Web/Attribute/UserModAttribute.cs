using eUseControl.Domain.Enums;
using eUseControl.Web.Controllers;
using System.Web.Mvc;
using System.Web.Routing;

namespace eUseControl.Web.Attribute
{
     public class UserModAttribute : ActionFilterAttribute
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
                         filterContext.Controller.TempData["ErrorMessage"] = "Mai întâi loghează-te.";
                         filterContext.Result = new RedirectToRouteResult(
                             new RouteValueDictionary
                             {
                            { "controller", "Home" },
                            { "action", "HomePage" }
                             });
                    }
                    else if (currentUser.Level != URole.User && currentUser.Level != URole.Admin)
                    {
                         filterContext.Controller.TempData["ErrorMessage"] = "Nu ai permisiuni de a accesa pagina.";
                         filterContext.Result = new RedirectToRouteResult(
                             new RouteValueDictionary
                             {
                            { "controller", "Home" },
                            { "action", "HomePage" }
                             });
                    }
               }
               else
               {
                    filterContext.Controller.TempData["ErrorMessage"] = "Mai întâi loghează-te.";
                    filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary
                        {
                        { "controller", "Home" },
                        { "action", "HomePage" }
                        });
               }
          }
     }
}
