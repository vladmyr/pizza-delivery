using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaDelivery01.Entity
{
    public class OrderItem
    {
        public int id { get; set; }
        public int orderId { get; set; }
        public int productId { get; set; }
        public int quantity { get; set; }
    }
}