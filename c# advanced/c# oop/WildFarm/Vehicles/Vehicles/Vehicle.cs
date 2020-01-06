using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    abstract class Vehicle
    {
        protected double fuelQuantity;
        protected double fuelConsumption;
        protected double tankCapacity;

        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            if (fuelQuantity <= tankCapacity) this.fuelConsumption = fuelConsumption; else fuelQuantity = 0;
            this.fuelQuantity = fuelQuantity;
            this.tankCapacity = tankCapacity;
        }
        public virtual void Refuel(double fuel)
        {
            if (fuel <= 0) throw new Exception("Fuel must be a positive number");
            else if (fuelQuantity + fuel > tankCapacity) throw new Exception($"Cannot fit {fuel} fuel in the tank");
            else fuelQuantity += fuel;
        }
    }
}
