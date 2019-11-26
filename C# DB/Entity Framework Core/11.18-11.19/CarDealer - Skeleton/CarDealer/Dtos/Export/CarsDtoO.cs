namespace CarDealer.Dtos.Export
{
    using System.Xml.Serialization;
    [XmlType("car")]
    public class CarsDtoO
    {
        public string make { get; set; }
        public string model { get; set; }
        [XmlElement("travelled-distance")]
        public long TravelledDistance { get; set; }
    }
    [XmlType("car")]
    public class BmwDtoO
    {
        [XmlAttribute("id")]
        public int CarId { get; set; }
        [XmlAttribute("model")]
        public string Model { get; set; }
        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }
    }

    [XmlType("car")]
    public class BmwDtoO2
    {
        [XmlAttribute]
        public string make { get; set; }
        [XmlAttribute("model")]
        public string Model { get; set; }
        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }
    }

    [XmlType("suplier")]
    public class SupplierDtoO
    {
        [XmlAttribute]
        public int id { get; set; }
        [XmlAttribute]
        public string name { get; set; }
        [XmlAttribute("parts-count")]
        public int partscount { get; set; }
    }
    [XmlType("sale")]
    public class SaleDtoO
    {
        public BmwDtoO2 car { get; set; }
        public decimal discount { get; set; }
        [XmlElement("customer-name")]
        public string Customer { get; set; }
        public decimal price { get; set; }
        [XmlElement("price-with-discount")]
        public decimal discPrice { get; set; }
    }
}