using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using BusinessLogic;
using BusinessLogic.Interfaces; // Import the BusinessLogic namespace

namespace eUseControl.Web.Controllers
{
     public class LoginController : Controller
     {
          private readonly ISession _session;

          public LoginController()
          {
               var bl = new BusinessLogic.BusinessLogic(); // Instantiate the BusinessLogic class
               _session = bl.GetSessionBL();
          }

          // GET: Login
          public ActionResult Index()
          {
               return View();
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Index(ULoginData login)
          {
               if (ModelState.IsValid)
               {
                    var data = new ULoginData
                    {
                         Credential = login.Credential,
                         Password = login.Password,
                         LoginIP = Request.UserHostAddress,
                         LoginDateTime = DateTime.Now
                    };

                    var userLogin = _session.UserLogin(data);
                    if (userLogin.Status)
                    {
                         //ADD COOOOOOKIES
                         // You can add cookies here using the Response.Cookies collection

                         return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                         ModelState.AddModelError("", userLogin.StatusMsg);
                    }
               }
               return View(login);
          }
     }
}
