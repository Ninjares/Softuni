using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace waterflow
{
    class Program
    {
        struct beerkeg
        { 
            public string model;
            public float radius;
            public int height;
            public float volume;
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            beerkeg biggest;
            biggest.model = "";
            biggest.radius = 0;
            biggest.height = 0;
            while (n != 0)
            {
                beerkeg input;
                input.model = Console.ReadLine();
                input.radius = float.Parse(Console.ReadLine());
                input.height = int.Parse(Console.ReadLine());
                input.volume = (float)Math.PI * input.radius * input.radius * (float)input.height;
                biggest.volume = (float)Math.PI * biggest.radius * biggest.radius * (float)biggest.height;
                //pi*r^2*h
                if (biggest.volume < input.volume) biggest = input;
                n--;
            }
            
            Console.WriteLine(biggest.model);
           // Console.ReadKey();
        }
    }
}
