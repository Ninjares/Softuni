using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    class Vehicle
    {
        public Vehicle(int hp, double fuel)
        {
            DefaultFuelConsumption = 1.25d;
            HorsePower = hp;
            Fuel = fuel;
        }

        public double DefaultFuelConsumption { get; set; }
        public virtual double FuelConsumption { get; set; }
        public double Fuel { get; set; }
        public int HorsePower { get; set; }

        public virtual void Drive(double kilometers)
        {
            Fuel -= kilometers * DefaultFuelConsumption;
        }

    }
}
