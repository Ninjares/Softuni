using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    class Coffee:HotBeverage
    {
        private const double CofffeeMilliliters = 50;
        private const decimal CoffeePrice = 3.50m;
        public double Caffeine { get; set; }

        public Coffee(string name, double caffeine) : base(name, CoffeePrice, CofffeeMilliliters)
        {
            Caffeine = caffeine;
        }
    }
}
