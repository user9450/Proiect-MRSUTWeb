using Domain.Entities.User;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Web;
using System.Web.Mvc;

namespace eUseControl.Web.Controllers
{
    public class UserRegistrationController : Controller
    {
        private readonly ISession _session;

        public UserRegistrationController()
        {
            var bl = new BussinesLogic();
            _session = bl.GetSessionBL();
        }

        // GET: Register
        public ActionResult RegisterPage()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterUser(URegisterData register)
        {
            if (ModelState.IsValid)
            {
                URegisterData data = new URegisterData
                {
                    Nume = register.Nume,
                    Prenume = register.Prenume,
                    Email = register.Email,
                    Password = register.Password
                };

                var userRegister = _session.UserRegister(data);
                if (userRegister == null)
                {
                    throw new AuthenticationException("ERROR. No registration response!");
                }

                if (userRegister.Status)
                {
                    return RedirectToAction("LogIn", "Login");
                }
                else
                {
                    ModelState.AddModelError("", userRegister.StatusMsg);
                    return View("RegisterPage", register);
                }
            }

            return RedirectToAction("HomePage", "Home");
        }
    }
}