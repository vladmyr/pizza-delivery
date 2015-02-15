using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using PizzaDelivery01.Data.Repositories;
using PizzaDelivery01.Data.Repositories.Impl;
using PizzaDelivery01.Entity;
using PizzaDelivery01.Entity.Context;

namespace PizzaDelivery01.Administration {
    public partial class ProductManagement : System.Web.UI.Page {
        private IProductRepository repository;

        protected void Page_Load(object sender, EventArgs e) {
            repository = new ProductRepository(new ProductContext());
        }

        public Product getProductById([QueryString("id")] int? productId)
        {
            Product product = null;
            if (productId.HasValue && productId > 0)
            {
                try
                {
                    product = repository.getProductById((int) productId);
                }
                catch
                {
                    product = null;
                }
            }
            return product;
        }
    }
}