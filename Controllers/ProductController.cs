using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PizzaDelivery01.Data.Repositories;
using PizzaDelivery01.Data.Repositories.Impl;
using PizzaDelivery01.Entity.Context;
using PizzaDelivery01.Models;
using Product = PizzaDelivery01.Entity.Product;
using ProductContext = PizzaDelivery01.Entity.Context.ProductContext;

namespace PizzaDelivery01.Controllers
{
    public class ProductController : ApiController
    {
        private IProductRepository repository = new ProductRepository(new ProductContext());

        public List<Product> Get()
        {
            return repository.getAllProducts().ToList();
        }

        public Product GetProduct(int id)
        {
            return repository.getProductById(id);
        }

    }
}
