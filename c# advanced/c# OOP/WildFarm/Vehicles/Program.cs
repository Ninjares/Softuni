using System;

namespace Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] cah = Console.ReadLine().Split();
            string[] truch = Console.ReadLine().Split();
            string[] buss = Console.ReadLine().Split();
            Car car = new Car(double.Parse(cah[1]), double.Parse(cah[2]), double.Parse(cah[3]));
            Truck truck = new Truck(double.Parse(truch[1]), double.Parse(truch[2]), double.Parse(truch[3]));
            Bus bus = new Bus(double.Parse(buss[1]), double.Parse(buss[2]), double.Parse(buss[3]));
            int n = int.Parse(Console.ReadLine());
            while (n != 0)
            {
                try
                {
                    string[] command = Console.ReadLine().Split();
                    switch (command[0])
                    {
                        case "Drive":
                            {
                                if (command[1] == "Car") car.Drive(double.Parse(command[2]));
                                else if (command[1] == "Truck") truck.Drive(double.Parse(command[2]));
                                else if (command[1] == "Bus") bus.Drive(double.Parse(command[2]));
                                break;
                            }
                        case "Refuel":
                            {
                                if (command[1] == "Car") car.Refuel(double.Parse(command[2]));
                                else if (command[1] == "Truck") truck.Refuel(double.Parse(command[2]));
                                else if (command[1] == "Bus") bus.Refuel(double.Parse(command[2]));
                                break;
                            }
                        case "DriveEmpty":
                            {
                                bus.DriveEmpty(double.Parse(command[2]));
                                break;
                            }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                n--;
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
