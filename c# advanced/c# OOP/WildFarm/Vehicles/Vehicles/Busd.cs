using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    class Bus:Vehicle
    {
        public Bus(double fuel, double fuelConsumption, double tankCapacity) : base(fuel, fuelConsumption, tankCapacity)
        {

        }
        public void Drive(double km)
        {
            if (fuelQuantity - FuelConsumption(true) * km < 0) throw new Exception(String.Format(Exception_message.RefuelNeeded, nameof(Bus)));
            else { fuelQuantity -= FuelConsumption(true) * km; Console.WriteLine($"Bus travelled {km} km"); }
        }

        public void DriveEmpty(double km)
        {
            if (fuelQuantity - FuelConsumption(false) * km < 0) throw new Exception(String.Format(Exception_message.RefuelNeeded, nameof(Bus)));
            else { fuelQuantity -= FuelConsumption(false) * km; Console.WriteLine($"Bus travelled {km} km"); }
        }

        private double FuelConsumption(bool people)
        {
            if (people)
                return fuelConsumption + 1.4;
            else return fuelConsumption;
        }

        public override string ToString()
        {
            return $"{nameof(Bus)}: {fuelQuantity:F2}";
        }
    }
}
