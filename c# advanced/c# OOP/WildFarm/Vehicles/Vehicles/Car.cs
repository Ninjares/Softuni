using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    class Car:Vehicle
    {
        public Car(double fuel, double fuelConsumption, double tankCapacity) : base(fuel, fuelConsumption, tankCapacity)
        {

        }

        public void Drive(double km)
        {
            if (fuelQuantity - FuelConsumption * km < 0) throw new Exception(String.Format(Exception_message.RefuelNeeded, nameof(Car)));
            else { fuelQuantity -= FuelConsumption * km; Console.WriteLine($"Car travelled {km} km"); }
        }

        
        public double Fuel { get => fuelQuantity; }
        private double FuelConsumption { get => fuelConsumption + 0.9; }

        public override string ToString()
        {
            return $"{nameof(Car)}: {Fuel:F2}";
        }
    }
}
