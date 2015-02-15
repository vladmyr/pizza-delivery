using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaDelivery01.Entity;

namespace PizzaDelivery01.Data.Repositories
{
    public interface IProductRepository
    {
        //CRUD Product
        bool insertProduct(Product product);
        IQueryable<Product> getAllProducts();
        Product getProductById(int id);
        bool updateProduct(Product product);
        bool deleteProduct(int id);
    }
}
