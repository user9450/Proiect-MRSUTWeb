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
    [UserMod]
    public class AccountController : LoginController
    {
        // GET: Account
        public ActionResult MyCabinet()
        {
            var authToken = Request.Cookies["X-KEY"]?.Value;
            if (authToken == null)
            {
                return RedirectToAction("LogIn", "Login");
            }

            var currentUser = GetUserDetails(authToken);

            if (currentUser == null)
            {
                return RedirectToAction("LogIn", "Login");
            }

            var model = new UserData
            {
                Nume = currentUser.Nume,
                Prenume = currentUser.Prenume,
                Email = currentUser.Email,
                Password = currentUser.Password
            };

            return View(model);
        }

        /*
        [HttpPost]
        public ActionResult UpdateUser(UserData model)
        {
            // Verifică dacă modelul este valid
            if (!ModelState.IsValid)
            {
                return View("MyCabinet", model); // afișează pagina "My Cabinet" cu erorile
            }

            // Actualizează informațiile utilizatorului în baza de date
            UpdateUserInDatabase(model); // implementează această metodă pentru a actualiza utilizatorul în baza de date

            // Redirectează către acțiunea MyCabinet pentru a afișa noile informații
            return RedirectToAction("MyCabinet");
        }
        */
    }

}