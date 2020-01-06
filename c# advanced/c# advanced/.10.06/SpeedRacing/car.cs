using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    class Car
    {
        public string Model;
        public double FuelAmount;
        public double FuelConsumptionPerKilometer;
        public double Travelleddistance;

        public Car(string Model, double FuelAmount, double FuelConsumptionPerKilometer)
        {
            this.Model = Model;
            this.FuelAmount = FuelAmount;
            this.FuelConsumptionPerKilometer = FuelConsumptionPerKilometer;
            this.Travelleddistance = 0;
        }

        public void Drive(double distance )
        {
            double requiredfuel = distance * this.FuelConsumptionPerKilometer;
            if (requiredfuel > FuelAmount) Console.WriteLine("Insufficient fuel for the drive");
            else
            {
                FuelAmount -= requiredfuel;
                Travelleddistance += distance;
            }
        }
    }
}
