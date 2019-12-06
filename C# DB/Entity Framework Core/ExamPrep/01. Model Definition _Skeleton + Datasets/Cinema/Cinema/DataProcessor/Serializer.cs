namespace Cinema.DataProcessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using System.Xml.Serialization;
    using Cinema.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;

    public class Serializer
    {
        static XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            return JsonConvert.SerializeObject(
                context.Movies.Where(m => m.Rating >= rating && m.Projections.Any(p => p.Tickets.Count > 0))
                .OrderByDescending(m => m.Rating).ThenByDescending(m => m.Projections.Sum(p => p.Tickets.Sum(t => t.Price)))
                .Select(x => new
                {
                    MovieName = x.Title,
                    Rating = x.Rating.ToString("F2"),
                    TotalIncomes = x.Projections.Sum(p => p.Tickets.Sum(t => t.Price)).ToString("F2"),
                    Customers = x.Projections.SelectMany(p => p.Tickets).Select(t => new
                    {
                        FirstName = t.Customer.FirstName,
                        LastName = t.Customer.LastName,
                        Balance = $"{t.Customer.Balance:F2}"
                    })
                    .OrderByDescending(c => c.Balance).ThenBy(c => c.FirstName).ThenBy(c => c.LastName)
                    .ToArray()
                }).Take(10).ToArray(), Newtonsoft.Json.Formatting.Indented);
        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            var customerData = context.Customers.Where(x => x.Age >= age).Select(x => new CustomerXMLDTO
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                SpentMoney = $"{x.Tickets.Sum(t => t.Price):F2}",
                SpentTime = new TimeSpan(x.Tickets.Sum(t => t.Projection.Movie.Duration.Ticks)).ToString(@"hh\:mm\:ss")
            }).OrderByDescending(x => decimal.Parse(x.SpentMoney)).Take(10).ToArray();
            var serializer = new XmlSerializer(typeof(CustomerXMLDTO[]), new XmlRootAttribute("Customers"));
            using(TextWriter tw = new StringWriter())
            {
                serializer.Serialize(tw, customerData, namespaces);
                return tw.ToString();
            }
        }
    }
}