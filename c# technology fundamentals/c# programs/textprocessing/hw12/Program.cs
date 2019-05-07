using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace hw12
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"[%](?<customer>[A-Z][a-z]+)[%][^|$.%]*[<](?<product>\w+)[>][^|$.%]*\|(?<count>[0-9]+)\|[^|$.%]*?(?<price>[0-9]+\.?[0-9]+)\$";
            string input = string.Empty;
            double totalincome = 0;
            while((input=Console.ReadLine())!="end of shift")
            {
                Regex order = new Regex(regex);

                if (order.IsMatch(input))
                {
                    string customer = order.Match(input).Groups["customer"].Value;
                    string product = order.Match(input).Groups["product"].Value;
                    int count = int.Parse(order.Match(input).Groups["count"].Value);
                    double price = double.Parse((order.Match(input).Groups["price"].Value));
                    Console.WriteLine($"{customer}: {product} - {price * (double)count:F2}");
                    //Console.WriteLine(customer + "\n" + product + "\n" + count + "\n" + price);
                    totalincome += price * (double)count;
                }

            }
            Console.WriteLine($"Total income: {totalincome:F2}");
            Console.ReadKey();
        }
    }
}
