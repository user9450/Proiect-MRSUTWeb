using System.Linq;
using System.Web.Mvc;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.Domain.Entities.User;
using eUseControl.Web.Attribute;
using eUseControl.Web.Models;

namespace eUseControl.Web.Controllers
{
    public class AccountController : LoginController
    {
        private readonly UserContext _context;

        public AccountController()
        {
            _context = new UserContext();
        }

        public ActionResult MyCabinet()
        {
            var authToken = Request.Cookies["X-KEY"]?.Value;
            if (authToken == null)
            {
                TempData["ErrorMessage"] = "[!] Nu sunteți logat pentru a accesa cabinetul.";
                return RedirectToAction("HomePage", "Home");
            }

            var currentUser = GetUserDetails(authToken);
            if (currentUser == null)
            {
                TempData["ErrorMessage"] = "[!] Nu am putut găsi detaliile utilizatorului.";
                return RedirectToAction("HomePage", "Home");
            }

            // Afisarea informatie despre User
            var model = new UserData
            {
                Nume = currentUser.Nume,
                Prenume = currentUser.Prenume,
                Email = currentUser.Email,
                Password = currentUser.Password
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateUser(UserData model)
        {
            if (!ModelState.IsValid)
            {
                return View("MyCabinet", model);
            }

            UpdateUserInDatabase(model);

            return RedirectToAction("MyCabinet");
        }

        private void UpdateUserInDatabase(UserData model)
        {
            var user = _context.Users.SingleOrDefault(u => u.Email == model.Email);
            if (user != null)
            {
                user.Nume = model.Nume;
                user.Prenume = model.Prenume;
                user.Password = model.Password;

                _context.SaveChanges();
            }
            else
            {
                ModelState.AddModelError("", "User not found.");
            }
        }
    }
}
