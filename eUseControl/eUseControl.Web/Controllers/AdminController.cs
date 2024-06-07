using eUseControl.BusinessLogic.DBModel;
using eUseControl.Domain.Entities.Orders;
using eUseControl.Domain.Entities.User;
using eUseControl.Web.Attribute;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace eUseControl.Web.Controllers
{
     [AdminMod]
     public class AdminController : Controller
     {
          private readonly OrderContext _db = new OrderContext();
          private readonly UserContext _user = new UserContext();

          // Users Management
          public ActionResult Users()
          {
               var users = _user.Users.ToList();
               return View(users);
          }

          public ActionResult CreateUser()
          {
               return View();
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult CreateUser(UDbTable user)
          {
               if (ModelState.IsValid)
               {
                    _user.Users.Add(user);
                    _user.SaveChanges();
                    return RedirectToAction("Users");
               }
               return View(user);
          }

          public ActionResult EditUser(int? id)
          {
               if (id == null)
               {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
               }

               UDbTable user = _user.Users.Find(id);
               if (user == null)
               {
                    return HttpNotFound();
               }

               return View(user);
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult EditUser(UDbTable user)
          {
               if (ModelState.IsValid)
               {
                    _user.Entry(user).State = EntityState.Modified;
                    _user.SaveChanges();
                    return RedirectToAction("Users");
               }
               return View(user);
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult DeleteUser(int id)
          {
               UDbTable user = _user.Users.Find(id);
               if (user != null)
               {
                    _user.Users.Remove(user);
                    _user.SaveChanges();
               }
               return RedirectToAction("Users");
          }

          // Products Management
          public ActionResult Products()
          {
               var products = _db.Products.ToList();
               return View(products);
          }

          public ActionResult Create()
          {
               return View();
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Create(Product product)
          {
               if (ModelState.IsValid)
               {
                    _db.Products.Add(product);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
               }
               return View(product);
          }

          public ActionResult Edit(int? id)
          {
               if (id == null)
               {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
               }

               Product product = _db.Products.Find(id);
               if (product == null)
               {
                    return HttpNotFound();
               }
               return View(product);
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Edit(Product product)
          {
               if (ModelState.IsValid)
               {
                    _db.Entry(product).State = EntityState.Modified;
                    _db.SaveChanges();
                    return RedirectToAction("Index");
               }
               return View(product);
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Delete(int id)
          {
               Product product = _db.Products.Find(id);
               if (product != null)
               {
                    _db.Products.Remove(product);
                    _db.SaveChanges();
               }
               return RedirectToAction("Index");
          }

          // Orders Management
          public ActionResult Orders()
          {
               var orders = _db.Orders.Include(o => o.OrderDetails.Select(od => od.Product)).ToList();
               return View(orders);
          }

          protected override void Dispose(bool disposing)
          {
               if (disposing)
               {
                    _db.Dispose();
                    _user.Dispose();
               }
               base.Dispose(disposing);
          }
     }
}
