using System;
using System.Linq;

namespace Raw_Data
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Car[] cars = new Car[n];
            for(int i=0; i<n; i++)
            {
                string[] input = Console.ReadLine().Split();
                cars[i] = new Car(input[0],
                    new Engine(int.Parse(input[1]), int.Parse(input[2])),
                    new Cargo(int.Parse(input[3]), input[4]),
                    new Tire(int.Parse(input[6]), double.Parse(input[5])),
                    new Tire(int.Parse(input[8]), double.Parse(input[7])),
                    new Tire(int.Parse(input[10]), double.Parse(input[9])),
                    new Tire(int.Parse(input[12]), double.Parse(input[11]))
                    );
            }
            string cargotype = Console.ReadLine();
            if(cargotype == "fragile")
            foreach(Car car in cars.Where(x => x.cargo.Type == cargotype&&x.TirePressBellow(1)))
            {
                Console.WriteLine($"{car.model}");
            }
            else if(cargotype == "flamable")
                foreach(Car car in cars.Where(x => x.engine.Power > 250))
                {
                    Console.WriteLine($"{car.model}");
                }
        }
    }
}
