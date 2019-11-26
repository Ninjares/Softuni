using System;
using System.Xml.Serialization;

namespace CarDealer.Dtos.Import
{
    [XmlType("Customer")]
    public class CustomerDtoI
    {
        public string name { get; set; }
        public DateTime birthDate { get; set; }
        public bool isYoungDriver { get; set; }
    }
}
