using System.Linq;
using System.Web.Mvc;
using eUseControl.Domain.Entities.Orders;
using System.Data.Entity;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.Web.Attribute;

namespace eUseControl.Web.Controllers
{
    [UserMod]
    public class MyOrderController : Controller
    {
        private readonly OrderContext _db = new OrderContext();

        public ActionResult MyOrders()
        {
            var userEmail = GetCurrentUserEmail();

            var orders = _db.Orders
              .Include(o => o.OrderDetails.Select(od => od.Product))
              .Where(o => o.UserId == userEmail)
              .ToList();
            return View(orders);
        }

        private string GetCurrentUserEmail()
        {
            var authCookie = Request.Cookies["X-KEY"];
            if (authCookie != null)
            {
                string authToken = authCookie.Value;
                var currentUser = new LoginController().GetUserDetails(authToken);
                if (currentUser != null)
                {
                    return currentUser.Email;
                }
            }
            return null;
        }
    }
}