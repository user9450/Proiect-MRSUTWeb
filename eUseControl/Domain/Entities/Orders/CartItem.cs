using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.Domain.Entities.Orders
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public int Quantity { get; set; }
        public string CartId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
