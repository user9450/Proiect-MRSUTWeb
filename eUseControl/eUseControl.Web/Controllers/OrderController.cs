using Domain.Entities.Orders;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eUseControl.Web.Attribute;

namespace eUseControl.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderContext _context;

        public OrderController()
        {
            _context = new OrderContext();
        }

        public ActionResult Index()
        {
            var authToken = Request.Cookies["X-KEY"]?.Value;
            if (authToken == null)
            {
                TempData["ErrorMessage"] = "[!] Nu sunteți logat pentru vizualiza coșul cu produse.";
                return RedirectToAction("HomePage", "Home");
            }

            var cart = GetCartItems();
            return View(cart);
        }

        public ActionResult AddToCart(int productId)
        {
            var authToken = Request.Cookies["X-KEY"]?.Value;
            if (authToken == null)
            {
                TempData["ErrorMessage"] = "[!] Nu sunteți logat pentru a adauga produsul în coș.";
                return RedirectToAction("HomePage", "Home");
            }

            var product = _context.Products.Find(productId);
            if (product == null)
            {
                return HttpNotFound();
            }
            string cartId = GetCartId();

            var cartItem = _context.CartItems.SingleOrDefault(c => c.Product.ProductId == productId && c.CartId == cartId);

            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    Product = product,
                    Quantity = 1,
                    CartId = GetCartId()
                };
                _context.CartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity++;
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Buy()
        {
            var cartItems = GetCartItems();
            if (!cartItems.Any())
            {
                return RedirectToAction("Index");
            }

            var order = new Order
            {
                UserId = "User123", // Trebuie înlocuit
                OrderDate = DateTime.Now,
                OrderDetails = cartItems.Select(c => new OrderDetail
                {
                    ProductId = c.Product.ProductId,
                    Quantity = c.Quantity,
                    UnitPrice = c.Product.Price
                }).ToList()
            };

            _context.Orders.Add(order);
            _context.CartItems.RemoveRange(cartItems);
            _context.SaveChanges();

            return RedirectToAction("ThankYou");
        }

        public ActionResult ThankYou()
        {
            return View();
        }

        // USELESS SHIT
        public ActionResult ViewOrders()
        {
            var orders = _context.Orders
                .Include(o => o.OrderDetails.Select(od => od.Product))
                .ToList();
            return View(orders);
        }

        private string GetCartId()
        {
            if (Session["CartId"] == null)
            {
                Session["CartId"] = Guid.NewGuid().ToString();
            }
            return Session["CartId"].ToString();
        }

        private List<CartItem> GetCartItems()
        {
            var cartId = GetCartId();
            return _context.CartItems.Where(c => c.CartId == cartId).Include(c => c.Product).ToList();
        }
    }
}