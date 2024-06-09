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
     public class NintendoGamesController : Controller
     {
          private readonly ISession _session;
          private readonly OrderContext _context;

          public NintendoGamesController()
          {
               var bl = new BussinesLogic();
               _session = bl.GetSessionBL();
               _context = new OrderContext();
          }

          public ActionResult NintendoGames()
          {
               var products = _context.Products.ToList();
               return View(products);
          }
     }
}