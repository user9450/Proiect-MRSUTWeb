using System;
using System.Linq;
using System.Web.Mvc;
using eUseControl.BusinessLogic;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Web.Extension;

namespace eUseControl.Web.Controllers
{
    public class HomeController : LoginController
    {
        private readonly ISession _session;
        private readonly OrderContext _context;

        public HomeController()
        {
            var bl = new BussinesLogic();
            _session = bl.GetSessionBL();
            _context = new OrderContext();
        }

        public ActionResult HomePage()
        {
            if (TempData["ErrorMessage"] != null)
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"]; // Mesajele de eroare 
            }

            var products = _context.Products.ToList();
            return View(products);
        }
    }
}