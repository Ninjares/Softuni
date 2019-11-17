using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var db = new ProductShopContext())
            {
                //db.Database.EnsureDeleted();
                //db.Database.EnsureCreated();
                //ImportUsers(db, File.ReadAllText(@"./../../../Datasets/users.json"));
                //ImportProducts(db, File.ReadAllText(@"./../../../Datasets/products.json"));
                //ImportCategories(db, File.ReadAllText(@"./../../../Datasets/categories.json"));
                //ImportCategoryProducts(db, File.ReadAllText(@"./../../../Datasets/categories-products.json"));
            }   
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            User[] users = JsonConvert.DeserializeObject<User[]>(inputJson);
            context.Users.AddRange(users);
            context.SaveChanges();
            return $"Successfully imported {users.Length}";
        }

        public static string ImportProducts(ProductShopContext db, string inputJson)
        {
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(inputJson);
            db.Products.AddRange(products);
            db.SaveChanges();
            return $"Successfully imported {db.Products.Count()}";
        }

        public static string ImportCategories(ProductShopContext db, string inputJson)
        {
            Category[] categories = JsonConvert.DeserializeObject<Category[]>(inputJson);
            db.Categories.AddRange(categories.Where(x => x.Name!=null));
            db.SaveChanges();
            return $"Successfully imported {db.Categories.Count()}";
        }

        public static string ImportCategoryProducts(ProductShopContext db, string inputJson)
        {
            CategoryProduct[] categoryProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);
            db.CategoryProducts.AddRange(categoryProducts);
            db.SaveChanges();
            return $"Successfully imported {categoryProducts.Length}";
        }


        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products.Where(x => x.Price > 500 && x.Price < 1000).OrderBy(x => x.Price)
                                            .Select(x => new { name = x.Name, price = x.Price, seller = x.Seller.FirstName+" "+x.Seller.LastName });
            return JsonConvert.SerializeObject(products, Formatting.Indented);

        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users.Where(x => x.ProductsSold.Any(p => p.BuyerId != null)).OrderBy(x => x.LastName).ThenBy(x => x.FirstName)
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    soldProducts = x.ProductsSold.Where(p => p.BuyerId!=null)
                            .Select(p => new
                            {
                                name = p.Name,
                                price = p.Price,
                                buyerFirstName = p.Buyer.FirstName,
                                buyerLastName = p.Buyer.LastName
                            }).ToArray()
                }).ToArray();
            return JsonConvert.SerializeObject(users, Formatting.Indented);
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories.OrderByDescending(x => x.CategoryProducts.Count).Select(c => new
            {
                category = c.Name,
                productsCount = c.CategoryProducts.Count,
                averagePrice = $"{c.CategoryProducts.Average(x => x.Product.Price):F2}",
                totalRevenue = $"{c.CategoryProducts.Sum(x => x.Product.Price):F2}"
            }).ToArray();
            return JsonConvert.SerializeObject(categories, Formatting.Indented);
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var data = new
            {
                usersCount = context.Users.Where(x => x.ProductsSold.Any(p => p.BuyerId != null)).Count(),
                users = context.Users.Where(x => x.ProductsSold.Any(p => p.BuyerId != null)).Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = new
                    {
                        count = u.ProductsSold.Where(p => p.BuyerId != null).Count(),
                        products = u.ProductsSold.Where(p => p.BuyerId != null).Select(p => new
                        {
                            name = p.Name,
                            price = p.Price
                        })
                    }
                }).OrderByDescending(x => x.soldProducts.count)
            };
            return JsonConvert.SerializeObject(data, Formatting.Indented, 
                new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}