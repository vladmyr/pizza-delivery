using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PizzaDelivery01.Mappers;

namespace PizzaDelivery01.Entity.Context
{
    public class ProductContext : DbContext
    {
        public ProductContext()
            : base("PizzaDelivery")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductMapper());
            modelBuilder.Configurations.Add(new OrderMapper());
            modelBuilder.Configurations.Add(new OrderItemMapper());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}