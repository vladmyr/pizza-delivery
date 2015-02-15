using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PizzaDelivery01.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext()
            : base("PizzaDelivery")
        {

        }
        public DbSet<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
    }
}