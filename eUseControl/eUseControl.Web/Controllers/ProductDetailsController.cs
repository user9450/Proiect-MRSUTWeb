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
    public class ProductDetailsController : Controller
    {
          private readonly ISession _session;
          private readonly OrderContext _context;

          public ProductDetailsController()
          {
               var bl = new BussinesLogic();
               _session = bl.GetSessionBL();
               _context = new OrderContext();
          }
          public ActionResult ProductDetails(int productId)
          {
               var product = _context.Products.Find(productId);
               if (product == null)
               {
                    return HttpNotFound();
               }
               return View(product);
          }
     }
}