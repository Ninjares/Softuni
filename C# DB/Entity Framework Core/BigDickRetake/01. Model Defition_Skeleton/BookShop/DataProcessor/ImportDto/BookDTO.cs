using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BookShop.DataProcessor.ImportDto
{
    [XmlType("Book")]
    public class BookDTO
    {
        public string Name { get; set; }
        public int Genre { get; set; }
        public decimal Price { get; set; }
        public int Pages { get; set; }
        public string PublishedOn { get; set; }
    }
}
