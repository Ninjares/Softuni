using System;
using System.Collections.Generic;
using System.Text;
using INStock.Contracts;

namespace INStock
{
    public class Product : IProduct
    {
        public string Label { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
        public Product()
        {

        }
        public Product(string label, decimal price, int quantity)
        {
            Label = label;
            Price = price;
            Quantity = quantity;
        }
        public int CompareTo(IProduct other)
        {
            throw new NotImplementedException();
        }
    }
}
