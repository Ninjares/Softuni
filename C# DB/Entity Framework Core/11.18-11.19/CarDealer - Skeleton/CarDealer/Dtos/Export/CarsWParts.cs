using System.Xml.Serialization;

namespace CarDealer.Dtos.Export
{
    [XmlType("car")]
    public class CarsWParts
    {
        [XmlAttribute]
        public string make { get; set; }
        [XmlAttribute]
        public string model { get; set; }
        [XmlAttribute("travelled-distance")]
        public long travelledDistance { get; set; }
        [XmlArray("parts")]
        public partfromcar[] parts { get; set; }
    }
    [XmlType("part")]
    public class partfromcar
    {
        [XmlAttribute]
        public string name { get; set; }
        [XmlAttribute]
        public decimal price { get; set; }
    }

    [XmlType("customer")]
    public class CustomerDtoO
    {
        [XmlAttribute("full-name")]
        public string FullName { get; set; }
        [XmlAttribute("bought-cars")]
        public int BoughtCars { get; set; }
        [XmlAttribute("spent-money")]
        public decimal SpentMoney { get; set; }
    }
}
