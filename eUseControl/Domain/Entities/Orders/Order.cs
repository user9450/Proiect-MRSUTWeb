using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Orders;

namespace eUseControl.Domain.Entities.Orders
{
    public class Order
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public string UserAddress { get; set; }
        public string UserIndex { get; set; }
        public int UserPhoneNumber {  get; set; }  
     }
}
