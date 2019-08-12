using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    class Truck:Vehicle
    {
        public Truck(double fuel, double fuelConsumption, double tankCapacity) : base(fuel, fuelConsumption, tankCapacity)
        {

        }

        public void Drive(double km)
        {
            if (fuelQuantity - FuelConsumption * km < 0) throw new Exception(String.Format(Exception_message.RefuelNeeded, nameof(Truck)));
            else { fuelQuantity -= FuelConsumption * km; Console.WriteLine($"Truck travelled {km} km"); }
        }

        public override void Refuel(double fuel)
        {
            if (fuel <= 0) throw new Exception("Fuel must be a positive number");
            else if (fuelQuantity + fuel > tankCapacity) throw new Exception($"Cannot fit {fuel} fuel in the tank");
            else fuelQuantity += fuel*0.95;
        }
        public double Fuel { get => fuelQuantity; }
        private double FuelConsumption { get => fuelConsumption + 1.6; }
        public override string ToString()
        {
            return $"{nameof(Truck)}: {Fuel:F2}";
        }
    }
}
