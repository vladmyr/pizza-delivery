using System;
using System.Collections.Specialized;
using System.Web.UI.WebControls;
using PizzaDelivery01.Data.Repositories;
using PizzaDelivery01.Data.Repositories.Impl;
using PizzaDelivery01.Entity;
using PizzaDelivery01.Entity.Context;

namespace PizzaDelivery01.Administration {
    public partial class ProductManagement : System.Web.UI.Page {
        private IProductRepository repository;
        private int productId;

        protected void Page_Load(object sender, EventArgs e) {
            repository = new ProductRepository(new ProductContext());
            try {
                productId = Convert.ToInt32(Request.QueryString["id"]);
            } catch {
                productId = 0;
            }
        }

        public Product getProductById() {
            Product product = new Product();
            if (productId != 0) {
                try {
                    product = repository.getProductById(productId);
                } catch {
                    product = new Product();
                    productId = 0;
                }
            }
            return product;
        }

        public void createUpdateProduct_Click(object sender, EventArgs eventArgs)
        {
            try
            {
                Product product = getProductById();
                product.name = (productForm.Row.FindControl("productName") as TextBox).Text;
                product.description = (productForm.Row.FindControl("productDescription") as TextBox).Text;
                product.size = Convert.ToInt32((productForm.Row.FindControl("productSize") as TextBox).Text);
                product.weight = Convert.ToInt32((productForm.Row.FindControl("productWeight") as TextBox).Text);
                product.price = Math.Floor(Convert.ToDouble((productForm.Row.FindControl("productPrice") as TextBox).Text) * 100) / 100;

                repository.addUpdateProduct(product);

                if (product.id == 0)
                {
                    SuccessText.Text = "New product was seccessfully added to database";
                }
                else
                {
                    SuccessText.Text = "New product was seccessfully updated in database";
                }
                SuccessMessage.Visible = true;
            }
            catch
            {
                FailureText.Text = "Invalid login attempt";
                ErrorMessage.Visible = true;
            }
        }

        public void deleteProduct_Click(object sender, EventArgs eventArgs)
        {
            if (productId != 0)
            {
                if (repository.deleteProduct(productId))
                {
                    SuccessText.Text = "Product was seccessfully deleted from database";
                    SuccessMessage.Visible = true;
                    //Response.Redirect("/Administration/Products");
                }
                else
                {
                    FailureText.Text = "An error occured while deleting product from database";
                    ErrorMessage.Visible = true;
                }
            }
        }
    }
}