namespace CarDealer
{
    using System.IO;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CarDealer.Data;
    using System.Xml.Serialization;
    using System.Xml;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;


    using Dtos.Import;
    using Dtos.Export;
    using Models;
    public class StartUp
    {
        static XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("","") });

        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.AddProfile(new CarDealerProfile()));

            using (var db = new CarDealerContext())
            {
                ResetDb(db);
                Console.WriteLine(GetCarsWithDistance(db));
                Console.WriteLine(GetCarsFromMakeBmw(db));
                Console.WriteLine(GetLocalSuppliers(db));
                Console.WriteLine(GetCarsWithTheirListOfParts(db));
                Console.WriteLine(GetTotalSalesByCustomer(db));
                Console.WriteLine(GetSalesWithAppliedDiscount(db));
            }
        }

        public static void ResetDb(CarDealerContext db)
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            Console.WriteLine(ImportSuppliers(db, File.ReadAllText(@".\..\..\..\Datasets\suppliers.xml")));
            Console.WriteLine(ImportParts(db, File.ReadAllText(@".\..\..\..\Datasets\parts.xml")));
            Console.WriteLine(ImportCars(db, File.ReadAllText(@".\..\..\..\Datasets\cars.xml")));
            Console.WriteLine(ImportCustomers(db, File.ReadAllText(@".\..\..\..\Datasets\customers.xml")));
            Console.WriteLine(ImportSales(db, File.ReadAllText(@".\..\..\..\Datasets\sales.xml")));
        }
        public static string ImportSuppliers(CarDealerContext db, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(SupplierDtoI[]), new XmlRootAttribute("Suppliers"));
            SupplierDtoI[] suppliers = (SupplierDtoI[])serializer.Deserialize(new StringReader(inputXml));
            db.Suppliers.AddRange(Mapper.Map<Supplier[]>(suppliers));
            db.SaveChanges();
            return $"Successfully imported {db.Suppliers.Count()}";
        }
        public static string ImportParts(CarDealerContext db, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(PartDtoI[]), new XmlRootAttribute("Parts"));
            PartDtoI[] parts = (PartDtoI[])serializer.Deserialize(new StringReader(inputXml));
            db.Parts.AddRange(Mapper.Map<Part[]>(parts.Where(x => db.Suppliers.Any(d => d.Id == x.supplierId))));
            db.SaveChanges();
            return $"Successfully imported {db.Parts.Count()}";
        }
        public static string ImportCars(CarDealerContext db, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(CarDtoI[]), new XmlRootAttribute("Cars"));
            CarDtoI[] cars = (CarDtoI[])serializer.Deserialize(new StringReader(inputXml));
            List<PartCar> partsCar = new List<PartCar>();
            foreach (var car in cars)
            {
                var cartoadd = Mapper.Map<Car>(car);
                db.Cars.Add(cartoadd);
                foreach (var partId in car.parts.Where(x => db.Parts.Any(d => d.Id == x.id)).GroupBy(x => x.id).Select(y => y.First()))
                    partsCar.Add(new PartCar() { Car = cartoadd, PartId = partId.id });
                
            }
            db.PartCars.AddRange(partsCar);
            db.SaveChanges();
            return $"Successfully imported {db.Cars.Count()}";
        }
        public static string ImportCustomers(CarDealerContext db, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(CustomerDtoI[]), new XmlRootAttribute("Customers"));
            CustomerDtoI[] customers = (CustomerDtoI[])serializer.Deserialize(new StringReader(inputXml));
            db.Customers.AddRange(Mapper.Map<Customer[]>(customers));
            db.SaveChanges();
            return $"Successfully imported {db.Customers.Count()}";
        }
        public static string ImportSales(CarDealerContext db, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(SalesDtoI[]), new XmlRootAttribute("Sales"));
            SalesDtoI[] salesDtos = (SalesDtoI[])serializer.Deserialize(new StringReader(inputXml));
            db.Sales.AddRange(salesDtos.Where(x => db.Cars.Any(c => c.Id == x.carId))
                .Select(x => new Sale()
                {
                    CarId = x.carId,
                    CustomerId = x.customerId,
                    Discount = x.discount
                }));
            db.SaveChanges();
            return $"Successfully imported {db.Sales.Count()}";
        }

        public static string GetCarsWithDistance(CarDealerContext db)
        {
            var cars = db.Cars.Where(x => x.TravelledDistance > 2000000).OrderBy(x => x.Make).ThenBy(x => x.Model).Take(10)
                .Select(x => new CarsDtoO
                {
                    make = x.Make,
                    model = x.Model,
                    TravelledDistance = x.TravelledDistance
                }).ToArray();
            var serializer = new XmlSerializer(typeof(CarsDtoO[]), new XmlRootAttribute("cars"));
            using(TextWriter tw = new StringWriter())
            {
                serializer.Serialize(tw, cars, namespaces);
                return tw.ToString();
            }
        }

        public static string GetCarsFromMakeBmw(CarDealerContext db)
        {
            var cars = db.Cars.Where(x => x.Make == "BMW").Select(x => new BmwDtoO
            {
                CarId = x.Id,
                Model = x.Model,
                TravelledDistance = x.TravelledDistance
            }).OrderBy(x => x.Model).ThenByDescending(x => x.TravelledDistance).ToArray();
            var seralizer = new XmlSerializer(typeof(BmwDtoO[]), new XmlRootAttribute("cars"));
            using(TextWriter tw = new StringWriter())
            {
                seralizer.Serialize(tw, cars, namespaces);
                return tw.ToString();
            }
        }

        public static string GetLocalSuppliers(CarDealerContext db)
        {
            var sups = db.Suppliers.Where(x => x.IsImporter == false).Select(x => new SupplierDtoO
            {
                id = x.Id,
                name = x.Name,
                partscount = x.Parts.Count
            }).ToArray();
            var serializer = new XmlSerializer(typeof(SupplierDtoO[]), new XmlRootAttribute("suppliers"));
            using(TextWriter tw = new StringWriter())
            {
                serializer.Serialize(tw, sups, namespaces);
                return tw.ToString();
            }
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext db)
        {
            var cars = db.Cars.OrderByDescending(x => x.TravelledDistance).ThenBy(x => x.Model).Take(5)
            .Select(x => new CarsWParts
            {
                make = x.Make,
                model = x.Model,
                travelledDistance = x.TravelledDistance,
                parts = x.PartCars.Select(p => new partfromcar
                {
                    name = p.Part.Name,
                    price = p.Part.Price
                }).OrderByDescending(p => p.price).ToArray()
            }).ToArray();
            var serializer = new XmlSerializer(typeof(CarsWParts[]), new XmlRootAttribute("cars"));
            using(TextWriter tw = new StringWriter())
            {
                serializer.Serialize(tw, cars, namespaces);
                return tw.ToString();
            }
            
        }

        public static string GetTotalSalesByCustomer(CarDealerContext db)
        {
            var customers = db.Customers.Where(x => x.Sales.Count > 0).ProjectTo<CustomerDtoO>().OrderByDescending(x => x.SpentMoney).ToArray();
            var serializer = new XmlSerializer(typeof(CustomerDtoO[]), new XmlRootAttribute("customers"));
            using(var tw = new StringWriter())
            {
                serializer.Serialize(tw, customers, namespaces);
                return tw.ToString();
            }
        }
        public static string GetSalesWithAppliedDiscount(CarDealerContext db)
        {
            var sales = db.Sales.Select(x => new SaleDtoO
            {
                car = new BmwDtoO2()
                {
                    make = x.Car.Make,
                    Model = x.Car.Model,
                    TravelledDistance = x.Car.TravelledDistance
                },
                discount = x.Discount,
                Customer = x.Customer.Name,
                price = x.Car.PartCars.Sum(p => p.Part.Price),
                discPrice = x.Car.PartCars.Sum(p => p.Part.Price) * (100 - x.Discount) / 100
            }).ToArray();
            var serializer = new XmlSerializer(typeof(SaleDtoO[]), new XmlRootAttribute("sales"));
            using(var tw = new StringWriter())
            {
                serializer.Serialize(tw, sales, namespaces);
                return tw.ToString();
            }

        }
    }
}