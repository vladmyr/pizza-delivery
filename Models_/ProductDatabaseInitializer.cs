using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PizzaDelivery01.Models
{
    public class ProductDatabaseInitializer : DropCreateDatabaseAlways<ProductContext>
    {
        protected override void Seed(ProductContext context)
        {
            GetCategories().ForEach(c => context.Categories.Add(c)); 
            GetProducts().ForEach(p => context.Products.Add(p));
        }

        private static List<Category> GetCategories()
        {
            var categories = new List<Category>{
                new Category{
                    CategoryID = 1,
                    CategoryName = "default"
                },
                new Category{
                    CategoryID = 2,
                    CategoryName = "branded"
                },
                new Category{
                    CategoryID = 3,
                    CategoryName = "hot"
                }
            };
            return categories;
        }

        private static List<Product> GetProducts()
        {
            var products = new List<Product>{
                new Product{
                    ProductID = 1,
                    ProductName = "Pizza Provence",
                    Description = "Ham, Danish Blue, Mozzarella, Pepperoni, Tomatoes, Alfredo sauce",
                    Size = 30,
                    Weight = 676,
                    ImagePath = "",
                    UnitPrice = 119.99,
                    CategoryID = 1
                },
                new Product{
                    ProductID = 2,
                    ProductName = "Pizza Americana",
                    Description = "Bacon, Ham, Domino's sauce, Mozzarella, Pepperoni",
                    Size = 30,
                    Weight = 722,
                    ImagePath = "",
                    UnitPrice = 129.99,
                    CategoryID = 2
                },
                new Product{
                    ProductID = 3,
                    ProductName = "Pizza Dzhamaykan Bombastic",
                    Description = "Pineapple, Domino's sauce, Chicken, Jalapenos, Corn, Mozzarella, Pepper, Mushrooms",
                    Size = 30,
                    Weight = 0,
                    ImagePath = "",
                    UnitPrice = 29.99,
                    CategoryID = 2
                },
                new Product{
                    ProductID = 4,
                    ProductName = "Pizza Bavarian",
                    Description = "Parmesan, Barbecue sauce, Bavarian sausages, Mozzarella",
                    Size = 30,
                    Weight = 744,
                    ImagePath = "",
                    UnitPrice = 114.99,
                    CategoryID = 3
                }
                ,
                new Product{
                    ProductID = 5,
                    ProductName = "Pizza Mexicana",
                    Description = "Domino's sauce, Beef, Jalapenos, Onion, Mozzarella, Pepper",
                    Size = 30,
                    Weight = 636,
                    ImagePath = "",
                    UnitPrice = 99.99,
                    CategoryID = 3
                }
                ,
                new Product{
                    ProductID = 6,
                    ProductName = "Pizza Tony Pepperoni",
                    Description = "Domino's sauce, Mozzarella, Pepperoni",
                    Size = 30,
                    Weight = 714,
                    ImagePath = "",
                    UnitPrice = 109.99,
                    CategoryID = 3
                }
                ,
                new Product{
                    ProductID = 7,
                    ProductName = "Pizza Texas",
                    Description = "Corn, Onion, Mozzarella, Mushrooms, Bavarian sausages, Barbecue sauce",
                    Size = 30,
                    Weight = 735,
                    ImagePath = "",
                    UnitPrice = 89.99,
                    CategoryID = 3
                }
            };
            return products;
        }
    }
}