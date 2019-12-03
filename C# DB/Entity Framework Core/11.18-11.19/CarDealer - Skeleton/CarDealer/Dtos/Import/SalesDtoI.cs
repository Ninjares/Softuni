using System.Xml.Serialization;

namespace CarDealer.Dtos.Import
{
    [XmlType("Sale")]
    public class SalesDtoI
    {
        public int carId { get; set; }
        public int customerId { get; set; }
        public decimal discount { get; set; }
    }
}
