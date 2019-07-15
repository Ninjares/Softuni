using System;

namespace Ferrari
{
    class Program
    {
        static void Main(string[] args)
        {
            Ferrari car = new Ferrari(Console.ReadLine());
            Console.Write(car.Model+"/");
            car.Brakes();
            Console.Write("/");
            car.Gas();
            Console.WriteLine($"/{car.Driver}");
        }
    }
}
