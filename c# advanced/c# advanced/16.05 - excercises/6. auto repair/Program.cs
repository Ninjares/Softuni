using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.auto_repair
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] vhcls = Console.ReadLine().Split(' ');
            Queue<string> vehicles = new Queue<string>(vhcls);
            Stack<string> served = new Stack<string>();

            string command = Console.ReadLine();
            while (command != "End")
            {
                switch (command)
                {
                    case "Service":
                        {
                            if (vehicles.Count != 0)
                            {
                                string serve = vehicles.Dequeue();
                                served.Push(serve);
                                Console.WriteLine($"Vehicle {serve} got served.");
                            }
                            break;
                        }
                    case "History":
                        {

                            List<string> printvhcl = served.ToList();
                            Console.WriteLine(string.Join(", ", printvhcl));
                            break;
                        }
                    default:
                        {
                            string[] commands = command.Split('-');
                            if (commands[0] == "CarInfo")
                            {
                                if (vehicles.Contains(commands[1])) Console.WriteLine("Still waiting for service.");
                                else if (served.Contains(commands[1])) Console.WriteLine("Served.");
                            }
                            break;
                        }

                }
            command = Console.ReadLine();
            }

            List<string> printvhcls = vehicles.ToList();
            if(printvhcls.Count!=0) Console.WriteLine("Vehicles for service: " + string.Join(", ", printvhcls));
            List<string> printserved = served.ToList();
            if(printserved.Count!=0) Console.WriteLine("Served vehicles: " + string.Join(", ", printserved));

            Console.ReadKey();
        }
    }
}
