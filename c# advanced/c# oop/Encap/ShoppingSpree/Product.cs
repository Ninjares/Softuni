using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    class Product
    {
        private string name;
        private decimal cost;

        public string Name { get => name; set => name = value; }
        public decimal Cost { get => cost; set => cost = value; }

        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }

    }
}
