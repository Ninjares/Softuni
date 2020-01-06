namespace BookShop.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using BookShop.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        static XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var export = context.Authors.OrderByDescending(x => x.AuthorsBooks.Count).ThenBy(a => a.FirstName + " " + a.LastName).Select(a => new
            {
                AuthorName = a.FirstName + " " + a.LastName,
                Books = a.AuthorsBooks.OrderByDescending(x => x.Book.Price).Select(b => new
                {
                    BookName = b.Book.Name,
                    BookPrice = b.Book.Price.ToString("F2")
                })
            }) ;
            return JsonConvert.SerializeObject(export, Formatting.Indented).TrimEnd();
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            var serializer = new XmlSerializer(typeof(BookEDTO[]), new XmlRootAttribute("Books"));
            var booksToSerialize = context.Books.Where(x => x.PublishedOn.CompareTo(date) <= 0 && (int)x.Genre == 3)

                .OrderByDescending(x => x.Pages).ThenByDescending(x => x.PublishedOn)
                .Take(10)
                .Select(x => new BookEDTO
                {
                    Pages = x.Pages,
                    Name = x.Name,
                    Date = x.PublishedOn.ToString("d", CultureInfo.InvariantCulture)
                }).ToArray() ;
            using (TextWriter tw = new StringWriter())
            {
                serializer.Serialize(tw, booksToSerialize, namespaces);
                return tw.ToString();
            }
        }
    }
}