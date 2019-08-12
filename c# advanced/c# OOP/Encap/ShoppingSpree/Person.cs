using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ShoppingSpree
{
    class Person
    {
        private string name;
        private decimal money;

        public List<Product> bag;
        public string Name
        {
            get => name;
            set
            {
                if (value == null || value.Trim() == "")
                {
                    Console.WriteLine("Name cannot be empty");
                    Environment.Exit(0);
                }
                else name = value;
            }
        }
        public decimal Money { get => money;
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Money cannot be negative");
                    Environment.Exit(0);
                }
                else money = value;
            }
        }

        public override string ToString()
        {
            string stuffbought = "";
            if (bag.Count == 0)
            {
                stuffbought = "Nothing bought";
            }
            else stuffbought = string.Join(", ", bag.Select(x => x.Name));
            return $"{Name} - {stuffbought}";
        }

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            bag = new List<Product>();
        }

        public string Buy(Product product)
        {
            if (Money < product.Cost)
            {
                return $"{Name} can't afford {product.Name}";
            }
            else
            {
                bag.Add(product);
                Money = Money - product.Cost;
                return $"{Name} bought {product.Name}";
            }
        }
    }
}
