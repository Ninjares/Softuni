using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crossroads_10
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> cars = new Queue<string>();
            int greenlightdur = int.Parse(Console.ReadLine());
            int freewindowdur = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();
            bool crash = false;

            while (input != "END")
            {
                if (input != "green")
                {
                    cars.Enqueue(input);
                    input = Console.ReadLine();
                    continue;
                }
                int currentGLD = greenlightdur;
                while (currentGLD>0&&cars.Count>0)
                {
                    string carName = cars.Dequeue();
                    int carLength = carName.Length;
                    if(carLength - greenlightdur >= 0)
                    {
                        currentGLD -= carLength;
                    }
                    else
                    {
                        currentGLD += freewindowdur;
                        if (carLength > currentGLD)
                        {
                            crash = true;
                        }
                        
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
