using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var db = new CarDealerContext())
            {
                Console.WriteLine(GetSalesWithAppliedDiscount(db));

            }
        }


        public static void ReinitializeDb(CarDealerContext db)
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            Console.WriteLine(ImportSuppliers(db, File.ReadAllText(@"./../../../Datasets/suppliers.json")));
            Console.WriteLine(ImportParts(db, File.ReadAllText(@"./../../../Datasets/parts.json")));
            Console.WriteLine(ImportCars(db, File.ReadAllText(@"./../../../Datasets/cars.json")));
            Console.WriteLine(ImportCustomers(db, File.ReadAllText(@"./../../../Datasets/customers.json")));
            Console.WriteLine(ImportSales(db, File.ReadAllText(@"./../../../Datasets/sales.json")));
        }
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            Supplier[] suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson);
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();
            return $"Successfully imported {context.Suppliers.Count()}.";
        }

        public static string ImportParts(CarDealerContext db, string inputJson)
        {
            Part[] parts = JsonConvert.DeserializeObject<Part[]>(inputJson);
            db.Parts.AddRange(parts.Where(x => db.Suppliers.Select(s => s.Id).Contains(x.SupplierId)));
            db.SaveChanges();
            return $"Successfully imported {db.Parts.Count()}.";
        }

        public static string ImportCars(CarDealerContext db, string inputJson)
        {
            ImportCarClass[] importCars = JsonConvert.DeserializeObject<ImportCarClass[]>(inputJson);
            List<Car> carstoAdd = new List<Car>();
            List<PartCar> partCars = new List<PartCar>();
            foreach (ImportCarClass car in importCars)
            {
                var cartoadd = new Car()
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance
                };

                foreach (var part in car.PartsId.Distinct())
                {
                    var carPart = new PartCar()
                    {
                        PartId = part,
                        Car = cartoadd
                    };
                    partCars.Add(carPart);
                }
                carstoAdd.Add(cartoadd);
            }
            db.Cars.AddRange(carstoAdd);
            db.PartCars.AddRange(partCars);
            db.SaveChanges();
            return $"Successfully imported {db.Cars.Count()}.";
        }

        public static string ImportCustomers(CarDealerContext db, string inputJson)
        {
            Customer[] customers = JsonConvert.DeserializeObject<Customer[]>(inputJson);
            db.Customers.AddRange(customers);
            db.SaveChanges();
            return $"Successfully imported {db.Customers.Count()}.";
        }

        public static string ImportSales(CarDealerContext db, string inputJson)
        {
            Sale[] sales = JsonConvert.DeserializeObject<Sale[]>(inputJson);
            db.Sales.AddRange(sales);
            db.SaveChanges();
            return $"Successfully imported {db.Sales.Count()}.";
        }

        public static string GetOrderedCustomers(CarDealerContext db)
        {
            return JsonConvert.SerializeObject(
                db.Customers.OrderBy(x => x.BirthDate.Year).ThenBy(x => x.BirthDate.Month).ThenBy(x => x.BirthDate.Day)
                .ThenBy(x => !x.IsYoungDriver).Select(x => new
                {
                    x.Name,
                    BirthDate = x.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture), //is this ordering properly?
                    x.IsYoungDriver
                }),
                Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        }

        public static string GetCarsFromMakeToyota(CarDealerContext db)
        {
            return JsonConvert.SerializeObject(
                db.Cars.Where(x => x.Make == "Toyota").OrderBy(x => x.Model).ThenByDescending(x => x.TravelledDistance)
                .Select(x => new
                {
                    x.Id,
                    x.Make,
                    x.Model,
                    x.TravelledDistance
                }),
                Formatting.Indented);
        }

        public static string GetLocalSuppliers(CarDealerContext db)
        {
            return JsonConvert.SerializeObject(
                db.Suppliers.Where(x => !x.IsImporter).Select(x => new
                {
                    x.Id,
                    x.Name,
                    PartsCount = x.Parts.Count
                })
                , Formatting.Indented);
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext db)
        {
            return JsonConvert.SerializeObject(
                db.Cars.Select(c => new 
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        c.TravelledDistance,
                    },
                    parts = c.PartCars.Select(p => new
                    {
                        p.Part.Name,
                        Price = $"{p.Part.Price:F2}"
                    })
                }),
                Formatting.Indented);
        }

        public static string GetTotalSalesByCustomer(CarDealerContext db)
        {
            var tojson =
                db.Customers.Where(x => x.Sales.Count > 0)
                .Select(x => new
                {
                    fullName = x.Name,
                    boughtCars = x.Sales.Count,
                    spentMoney = x.Sales.Sum(s => s.Car.PartCars.Sum(p => p.Part.Price))
                }).OrderByDescending(x => x.spentMoney).ThenByDescending(x => x.boughtCars).ToList();

            return JsonConvert.SerializeObject(tojson, Formatting.Indented);
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext db)
        {
            return JsonConvert.SerializeObject(
                db.Sales.Take(10).Select(x => new
                {
                    car = new
                    {
                        x.Car.Make,
                        x.Car.Model,
                        x.Car.TravelledDistance
                    },
                    customerName = x.Customer.Name,
                    Discount = x.Discount.ToString("F2"),
                    price = x.Car.PartCars.Sum(p => p.Part.Price).ToString("F2"),
                    priceWithDiscount = $"{x.Car.PartCars.Sum(p => p.Part.Price) * (100-x.Discount)/100:F2}"

                })
                , Formatting.Indented); ;
        }
    }
}