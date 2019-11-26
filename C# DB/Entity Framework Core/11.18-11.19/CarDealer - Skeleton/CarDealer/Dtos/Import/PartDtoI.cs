using System.Xml.Serialization;

namespace CarDealer.Dtos.Import
{
    [XmlType("Part")]
    public class PartDtoI
    {
        public string name { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set;}
        public int supplierId { get; set; }
    }
}
