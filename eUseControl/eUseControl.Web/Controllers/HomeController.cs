using eUseControl.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eUseControl.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            return View();
        }
    }
}

/*
UserData u = new UserData();
u.Username = "Customer";
u.Products = new List<string> { "Product #1", "Product #2", "Product #3", "Product #4" };

    return View(u);
*/