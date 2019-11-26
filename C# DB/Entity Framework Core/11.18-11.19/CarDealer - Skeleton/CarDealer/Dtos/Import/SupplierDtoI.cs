using System.Xml.Serialization;

namespace CarDealer.Dtos.Import
{
    [XmlType("Supplier")]
    public class SupplierDtoI
    {
        [XmlElement]
        public string name { get; set; }
        [XmlElement]
        public bool isImporter { get; set; }
    }
}
