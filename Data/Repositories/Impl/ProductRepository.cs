using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using PizzaDelivery01.Entity;
using PizzaDelivery01.Entity.Context;

namespace PizzaDelivery01.Data.Repositories.Impl
{
    public class ProductRepository : IProductRepository
    {
        private ProductContext ctx;

        public ProductRepository(ProductContext ctx)
        {
            this.ctx = ctx;
        }

        public bool insertProduct(Product product)
        {
            bool result = true;
            try
            {
                ctx.Products.Add(product);
            }
            catch
            {
                result = false; 
            }
            return result;
        }

        public IQueryable<Product> getAllProducts()
        {
            return ctx.Products.AsQueryable();
        }

        public Product getProductById(int id)
        {
            return ctx.Products.Find(id);
        }

        public bool addUpdateProduct(Product product)
        {
            bool result = true;
            try
            {
                ctx.Products.AddOrUpdate(product);
                ctx.SaveChanges();
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public bool deleteProduct(int id)
        {
            bool result = true;
            try
            {
                Product product = getProductById(id);
                if (product != null)
                {
                    ctx.Products.Remove(product);
                    ctx.SaveChanges();
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public IQueryable<Order> getAllOrders()
        {
            return ctx.Orders.AsQueryable();
        }

        public Order getOrderById(int id)
        {
            return ctx.Orders.Find(id);
        }

        public Order getOrderByIdWithItems(int id)
        {
            return ctx.Orders
                .Include("OrderItems")
                .OrderBy(o => o.date)
                .SingleOrDefault(o => o.id == id);
        }

        public bool addUpdateOrder(Order order)
        {
            bool result = true;
            try
            {
                ctx.Orders.AddOrUpdate(order);
                ctx.SaveChanges();
            }
            catch(Exception ex)
            {
                result = false;
            }
            return result;
        }

        public IQueryable<OrderItem> getOrderItemsByOrderId(int id)
        {
            return ctx.OrderItems
                .Include("Orders")
                .Where(oi => oi.order.id == id)
                .AsQueryable();
        }

        public bool addUpdateOrderItem(int orderId, OrderItem orderItem)
        {
            throw new NotImplementedException();
        }
    }
}