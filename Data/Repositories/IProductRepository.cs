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
        bool addUpdateProduct(Product product);
        bool deleteProduct(int id);

        IQueryable<Order> getAllOrders();
        Order getOrderById(int id);
        Order getOrderByIdWithItems(int id);
        bool addUpdateOrder(Order order);

        IQueryable<OrderItem> getOrderItemsByOrderId(int id);
        bool addUpdateOrderItem(int orderId, OrderItem orderItem);
    }
}
