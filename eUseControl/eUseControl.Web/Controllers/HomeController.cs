using System;
using System.Linq;
using System.Web.Mvc;
using eUseControl.BusinessLogic;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Web.Extension;

namespace eUseControl.Web.Controllers
{
    public class HomeController : Controller
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
            var products = _context.Products.ToList(); // Get products from DB
            return View(products); // Trimite produsele la View
        }
    }
}