namespace ProductShop
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using ProductShop.Data;
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using System.Xml.Serialization;

    public class StartUp
    {
        static XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });
        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.AddProfile(new ProductShopProfile()));
            using(var db = new ProductShopContext())
            {
                Console.WriteLine(GetUsersWithProducts(db));
            }
        }

        public static void DBinitialize(ProductShopContext db)
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            Console.WriteLine(ImportUsers(db, File.ReadAllText(@".\..\..\..\Datasets\users.xml")));
            Console.WriteLine(ImportProducts(db, File.ReadAllText(@".\..\..\..\Datasets\products.xml")));
            Console.WriteLine(ImportCategories(db, File.ReadAllText(@".\..\..\..\Datasets\categories.xml")));
            Console.WriteLine(ImportCategoryProducts(db, File.ReadAllText(@".\..\..\..\Datasets\categories-products.xml")));
        }

        public static string ImportUsers(ProductShopContext db, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(Dtos.Import.User[]), new XmlRootAttribute("Users"));
            Dtos.Import.User[] userDtos = (Dtos.Import.User[])serializer.Deserialize(new StringReader(inputXml));
            Models.User[] UsersToDb = Mapper.Map<Models.User[]>(userDtos);
            db.Users.AddRange(UsersToDb);
            db.SaveChanges();
            return $"Successfully imported {db.Users.Count()}";
        }

        public static string ImportProducts(ProductShopContext db, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(Dtos.Import.Product[]), new XmlRootAttribute("Products"));
            Dtos.Import.Product[] productDtos = (Dtos.Import.Product[])serializer.Deserialize(new StringReader(inputXml));
            Models.Product[] productsToDB = Mapper.Map<Models.Product[]>(productDtos);
            db.Products.AddRange(productsToDB);
            db.SaveChanges();
            return $"Successfully imported {db.Products.Count()}";
        }

        public static string ImportCategories(ProductShopContext db, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(Dtos.Import.Category[]), new XmlRootAttribute("Categories"));
            var categoryDtos = (Dtos.Import.Category[])serializer.Deserialize(new StringReader(inputXml));
            var categoriesToDb = Mapper.Map<Models.Category[]>(categoryDtos.Where(x => x.Name!=null));
            db.Categories.AddRange(categoriesToDb);
            db.SaveChanges();
            return $"Successfully imported {db.Categories.Count()}";
        }

        public static string ImportCategoryProducts(ProductShopContext db, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(Dtos.Import.CategoryProduct[]), new XmlRootAttribute("CategoryProducts"));
            var dtos = (Dtos.Import.CategoryProduct[])serializer.Deserialize(new StringReader(inputXml));
            var todb = Mapper.Map<Models.CategoryProduct[]>(dtos.Where(x => db.Categories.Any(c => c.Id == x.CategoryId)&&db.Products.Any(p => p.Id == x.ProductId)));
            db.CategoryProducts.AddRange(todb);
            db.SaveChanges();
            return $"Successfully imported {db.CategoryProducts.Count()}";
        }

        public static string GetProductsInRange(ProductShopContext db)
        {
            var products = db.Products.Where(x => x.Price >= 500 && x.Price <= 1000).OrderBy(x => x.Price).Take(10).ProjectTo<Dtos.Export.Product>().ToArray();
            var serializer = new XmlSerializer(typeof(Dtos.Export.Product[]), new XmlRootAttribute("Products"));
            using(TextWriter textWriter = new StringWriter())
            {
                serializer.Serialize(textWriter, products, namespaces);
                return textWriter.ToString();
            }
        }

        public static string GetSoldProducts(ProductShopContext db)
        {
            var users = db.Users.Where(x => x.ProductsSold.Count > 0).OrderBy(x => x.LastName).ThenBy(x => x.FirstName).Take(5).Select(x => new Dtos.Export.SoldProducts
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                soldProducts = x.ProductsSold.Select(p => new Dtos.Export.SoldPDto
                {
                    Name = p.Name,
                    Price = p.Price
                }).ToArray()
            }).ToArray();
            var serializer = new XmlSerializer(typeof(Dtos.Export.SoldProducts[]), new XmlRootAttribute("Users"));
            using (TextWriter textWriter = new StringWriter())
            {
                serializer.Serialize(textWriter, users, namespaces);
                return textWriter.ToString();
            }

        }

        public static string GetCategoriesByProductsCount(ProductShopContext db)
        {
            var cats = db.Categories.Select(x => new Dtos.Export.CategoryDto
            {
                Name = x.Name,
                Count = x.CategoryProducts.Count,
                AvgPrice = x.CategoryProducts.Average(cp => cp.Product.Price),
                TotalRevenue = x.CategoryProducts.Sum(cp => cp.Product.Price)
            })
                .OrderByDescending(x => x.Count).ThenBy(x => x.TotalRevenue).ToArray();
            var serializer = new XmlSerializer(typeof(Dtos.Export.CategoryDto[]), new XmlRootAttribute("Categories"));
            using (TextWriter textWriter = new StringWriter())
            {
                serializer.Serialize(textWriter, cats, namespaces);
                return textWriter.ToString();
            }

        }

        public static string GetUsersWithProducts(ProductShopContext db)
        {
            var usrs = db.Users.Where(x => x.ProductsSold.Count != 0).OrderByDescending(x => x.ProductsSold.Count)
                .ProjectTo<Dtos.Export.UserDto>();
            var serializer = new XmlSerializer(typeof(Dtos.Export.Users), new XmlRootAttribute("Users"));
            using (TextWriter textWriter = new StringWriter())
            {
                serializer.Serialize(textWriter, new Dtos.Export.Users() { count = usrs.Count(), users = usrs.Take(10).ToArray() }, namespaces);
                return textWriter.ToString();
            }
        }
    }
}