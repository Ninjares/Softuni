using System.Xml.Serialization;

namespace CarDealer.Dtos.Import
{
    [XmlType("Car")]
    public class CarDtoI
    {
        public string model { get; set; }
        public string make { get; set; }
        public long TraveledDistance { get; set; }
        [XmlArray("parts")]
        public PartIdDto[] parts { get; set; }
    }
    [XmlType("partId")]
    public class PartIdDto
    {
        [XmlAttribute("id")]
        public int id { get; set; }
    }
}
