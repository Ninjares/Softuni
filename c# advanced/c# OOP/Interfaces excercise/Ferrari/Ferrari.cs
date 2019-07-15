using System;
using System.Collections.Generic;
using System.Text;

namespace Ferrari
{
    class Ferrari:Car
    {
        private const string model = "488-Spider";
        public string Driver { get; set; }

        public string Model { get => model; }
        public Ferrari(string driver)
        {
            Driver = driver;
        }

        public void Brakes()
        {
            Console.Write("Brakes!");
        }
        public void Gas()
        {
            Console.Write("Gas!");
        }
    }
}
