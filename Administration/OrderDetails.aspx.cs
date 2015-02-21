using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PizzaDelivery01.Data.Repositories;
using PizzaDelivery01.Data.Repositories.Impl;
using PizzaDelivery01.Entity;
using PizzaDelivery01.Entity.Context;

namespace PizzaDelivery01.Administration {
    public partial class OrderDetails : System.Web.UI.Page {
        private IProductRepository repository;
        private int orderId;
        private Order order;

        protected void Page_Load(object sender, EventArgs e) {
            repository = new ProductRepository(new ProductContext());
            try {
                orderId = Convert.ToInt32(Request.QueryString["id"]);
            } catch {
                orderId = 0;
            }
            if (orderId != 0)
            {
                try
                {
                    order = repository.getOrderByIdWithItems(orderId);
                }
                catch
                {
                    order = new Order();
                    orderId = 0;
                }
            }
        }

        public int getOrderId()
        {
            return orderId;
        }

        public Order getOrderById()
        {           
            return order;
        }

        public IQueryable<OrderItem> getOrderItemsByOrderId()
        {
            return repository.getOrderItemsByOrderId(orderId);
        }

        public Product getProductById(int id)
        {
            Product product = repository.getProductById(id);
            if (product == null)
            {
                product = new Product();
            }
            return product;
        }

        protected void statusCompleted_Click(object sender, EventArgs e)
        {
            if (orderId != 0 && !order.isCompleted)
            {
                order.isCompleted = true;
                repository.addUpdateOrder(order);
                Response.Redirect("/Administration/OrderDetails?id=" + orderId);
            }
        }
    }
}