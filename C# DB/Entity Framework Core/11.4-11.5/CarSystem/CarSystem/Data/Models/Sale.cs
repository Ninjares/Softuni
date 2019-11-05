using System;
using System.Collections.Generic;
using System.Text;

namespace CarSystem.Data.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public int AddressId { get; set; }
        public int CustomerId { get; set; }
        public int CarId { get; set; } //One To One

        public Address Address { get; set; }
        public Customer Customer { get; set; }
        public Car Car { get; set; }
    }
}
