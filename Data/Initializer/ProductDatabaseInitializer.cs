using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PizzaDelivery01.Entity;
using PizzaDelivery01.Entity.Context;

namespace PizzaDelivery01.Data.Initializer
{
    public class ProductDatabaseInitializer : DropCreateDatabaseIfModelChanges<ProductContext>
    {
        protected override void Seed(ProductContext context)
        {
            GetProducts().ForEach(c => context.Products.Add(c));
        }

        private static List<Product> GetProducts()
        {
            var products = new List<Product>{
                new Product{
                    id = 1,
                    name = "Pizza Provence",
                    description = "Ham, Danish Blue, Mozzarella, Pepperoni, Tomatoes, Alfredo sauce",
                    size = 30,
                    weight = 676,
                    price = 119.99,
                    imagePath = ""
                },
                new Product{
                    id = 2,
                    name = "Pizza Americana",
                    description = "Bacon, Ham, Domino's sauce, Mozzarella, Pepperoni",
                    size = 30,
                    weight = 722,
                    price = 129.99,
                    imagePath = "",
                },
                new Product{
                    id = 3,
                    name = "Pizza Dzhamaykan Bombastic",
                    description = "Pineapple, Domino's sauce, Chicken, Jalapenos, Corn, Mozzarella, Pepper, Mushrooms",
                    size = 30,
                    weight = 690,
                    imagePath = "",
                    price = 99.99
                },
                new Product{
                    id = 4,
                    name = "Pizza Bavarian",
                    description = "Parmesan, Barbecue sauce, Bavarian sausages, Mozzarella",
                    size = 30,
                    weight = 744,
                    imagePath = "",
                    price = 114.99
                }
                ,
                new Product{
                    id = 5,
                    name = "Pizza Mexicana",
                    description = "Domino's sauce, Beef, Jalapenos, Onion, Mozzarella, Pepper",
                    size = 30,
                    weight = 636,
                    imagePath = "",
                    price = 99.99
                }
                ,
                new Product{
                    id = 6,
                    name = "Pizza Tony Pepperoni",
                    description = "Domino's sauce, Mozzarella, Pepperoni",
                    size = 30,
                    weight = 714,
                    imagePath = "",
                    price = 109.99
                }
                ,
                new Product{
                    id = 7,
                    name = "Pizza Texas",
                    description = "Corn, Onion, Mozzarella, Mushrooms, Bavarian sausages, Barbecue sauce",
                    size = 30,
                    weight = 735,
                    imagePath = "",
                    price = 89.99
                }
            };
            return products;
        }
    }
}