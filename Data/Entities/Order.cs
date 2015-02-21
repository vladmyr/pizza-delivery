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

        public virtual ICollection<OrderItem> OrderItems { get; set; }

        public string getFormattedDate(string format)
        {
            return ((new DateTime(1970,1,1)).Add(TimeSpan.FromMilliseconds(date))).ToString(format);
        }

        public string getFormattedStatus()
        {
            return isCompleted ? "Completed" : "Pending";
        }
    }
}