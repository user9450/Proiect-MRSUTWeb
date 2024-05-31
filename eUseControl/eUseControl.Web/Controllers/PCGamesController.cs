using eUseControl.BusinessLogic.DBModel;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace eUseControl.Web.Controllers
{
    public class PCGamesController : LoginController
    {
        private readonly ISession _session;
        private readonly OrderContext _context;

        public PCGamesController()
        {
            var bl = new BussinesLogic();
            _session = bl.GetSessionBL();
            _context = new OrderContext();
        }
        // GET: PCGames
        public ActionResult PCGames()
        {
            var products = _context.Products.ToList(); // Get products from DB
            return View(products);
        }
    }
}