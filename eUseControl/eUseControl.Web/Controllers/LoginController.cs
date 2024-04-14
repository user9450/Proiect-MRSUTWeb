using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using BusinessLogic;
using BusinessLogic.Interfaces;
using eUseControl.Web.Models;
namespace eUseControl.Web.Controllers

{
     public class LoginController : Controller
     {
          private readonly ISession _session;

          public LoginController()
          {
               var bl = new BusinessLogic.BusinessLogic();
               _session = bl.GetSessionBL();
          }

          // Aquire login
          public ActionResult Index()
          {
               return View();
               //return null();
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Index(UserLogin login)
          {
               if (ModelState.IsValid)
               {
                    ULoginData data = new ULoginData
                    {
                         Credential = login.Credentials,
                         Password = login.Password,
                         LoginIP = Request.UserHostAddress,
                         LoginDateTime = DateTime.Now
                    };

                    var userLogin = _session.UserLogin(data);
                    if (userLogin)
                    {
                      
                         return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        //ModelState.AddModelError("", userLogin); wip
                        return null;
                    }
               }

            //return View();
            return null;

          }
     }
}
