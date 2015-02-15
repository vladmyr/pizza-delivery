using System;
using System.Collections.Generic;
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

        public bool updateProduct(Product product)
        {
            bool result = true;
            try
            {
                ctx.Entry(getProductById(product.id)).CurrentValues.SetValues(product);
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
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public bool saveAll()
        {
            return ctx.SaveChanges() > 0;
        }
    }
}