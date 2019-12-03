namespace ProductShop.Dtos.Export
{
    using System.Xml.Serialization;
    [XmlRoot("Products")]
    [XmlType("Product")]
    public class Product
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("price")]
        public decimal Price { get; set; }
        [XmlElement("buyer")]
        public string BuyerFullName { get; set; }
    }
}
