using System;
using System.Linq;
using System.Web.Mvc;
using eUseControl.BusinessLogic;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Web.Extension;

namespace eUseControl.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISession _session;

        public HomeController()
        {
            var bl = new BussinesLogic();
            _session = bl.GetSessionBL();
        }

        public ActionResult HomePage()
        {
            return View();
        }
    }
}