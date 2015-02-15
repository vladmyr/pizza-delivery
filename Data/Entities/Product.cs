using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaDelivery01.Entity
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int size { get; set; }
        public int weight { get; set; }
        public double price { get; set; }
        public string imagePath { get; set; }
    }
}