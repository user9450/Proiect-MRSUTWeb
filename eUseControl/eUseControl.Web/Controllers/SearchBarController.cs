using eUseControl.BusinessLogic.DBModel;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eUseControl.Domain.Entities.Orders;

namespace eUseControl.Web.Controllers
{
    public class SearchBarController : Controller
    {
          private readonly ISession _session;
          private readonly OrderContext _context;

          public SearchBarController()
        {
             var bl = new BussinesLogic();
             _session = bl.GetSessionBL();
             _context = new OrderContext();
        }
          public ActionResult Search(string query)
          {
               if (string.IsNullOrEmpty(query))
               {
                    return View("SearchResults", new List<Product>());
               }

               var products = _context.Products
                                      .Where(p => p.Name.Contains(query))
                                      .ToList();

               return View("SearchResults", products);
          }

     }
}