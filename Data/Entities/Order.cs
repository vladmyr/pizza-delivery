using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaDelivery01.Entity
{
    public class Order
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public long date { get; set; }
        public bool isCompleted { get; set; }
        public List<OrderItem> lstOrderItem { get; set; }
    }
}