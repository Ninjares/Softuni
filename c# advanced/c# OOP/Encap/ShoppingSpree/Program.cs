using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] peoples = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            string[] productss = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, Product> products = new Dictionary<string, Product>();
            Dictionary<string, Person> people = new Dictionary<string, Person>();
            foreach(string person in peoples)
            {
                string[] data = person.Split('=');
                string name = data[0];
                decimal money = decimal.Parse(data[1]);
                people.Add(name, new Person(name, money));
            }
            foreach (string product in productss)
            {
                string[] data = product.Split('=');
                string name = data[0];
                decimal money = decimal.Parse(data[1]);
                products.Add(name, new Product(name, money));
            }
            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] nameproduct = input.Split();
                Console.WriteLine(people[nameproduct[0]].Buy(products[nameproduct[1]]));
                input = Console.ReadLine();
            }
            foreach (var person1 in people)
            {
                Console.WriteLine(person1.Value);
            }
        }
    }
}
