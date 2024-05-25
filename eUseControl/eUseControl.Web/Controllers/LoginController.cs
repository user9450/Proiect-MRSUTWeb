using System;
using System.Security.Authentication;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using eUseControl.BusinessLogic;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.User;
using eUseControl.Web.Attribute;
using eUseControl.Web.Models;

namespace eUseControl.Web.Controllers

{
    public class LoginController : Controller
    {
        private readonly ISession _session;
        public LoginController()
        {
            var bl = new BussinesLogic();
            _session = bl.GetSessionBL();
        }

        public ActionResult LogIn(string errorMessage = null)
        {
            if (!string.IsNullOrEmpty(errorMessage))
            {
                ModelState.AddModelError("", errorMessage);
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogInUser(UserLogin login)
        {
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<UserLogin, ULoginData>());
                var mapper = config.CreateMapper();
                var data = mapper.Map<ULoginData>(login);

                var userLogin = _session.UserLogin(data);

                if (userLogin == null)
                {
                    throw new AuthenticationException("ERROR. No login response!");
                }

                if (userLogin.Status)
                {
                    // Generarea cookie pentru sesiunea actuală
                    HttpCookie cookie = _session.GenCookie(login.Email);
                    ControllerContext.HttpContext.Response.Cookies.Add(cookie);

                    return RedirectToAction("HomePage", "Home");
                }
                else
                {
                    // Autentificare nereusita
                    ModelState.AddModelError("", userLogin.StatusMsg);
                    return View("LogIn", login); ;
                }
            }

            return RedirectToAction("HomePage", "Home");
        }

        public UserMinimal GetUserDetails(string authToken)
        {
            return _session.GetUserByCookie(authToken);
        }

        [UserMod]
        public ActionResult Logout()
        {
            if (Request.Cookies["X-KEY"] != null)
            {
                var c = new HttpCookie("X-KEY");
                c.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(c);
            }

            Session.Abandon();

            return RedirectToAction("LogIn", "Login");
        }
    }
}
