using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Car> cars = new Dictionary<string, Car>();
            while (n != 0)
            {
                string[] stats = Console.ReadLine().Split();
                cars.Add(stats[0], new Car(stats[0], double.Parse(stats[1]), double.Parse(stats[2])));
                n--;
            }
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] commands = input.Split();
                if (commands[0] == "Drive")
                {
                    cars[commands[1]].Drive(double.Parse(commands[2]));
                }
                input = Console.ReadLine();
            }
            foreach(var car in cars)
            {
                Console.WriteLine($"{car.Value.Model} {car.Value.FuelAmount:F2} {car.Value.Travelleddistance}");
            }
        }
    }
}
