using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Engine
    {
        public string model;
        public int Power { get; private set; }
        public int Displacement { get; private set; }
        public string Efficiency { get; private set; } 

        public Engine(string model, int Power)
        {
            this.model = model;
            this.Power = Power;
            Displacement = 0;
            Efficiency = "n/a";
        }
        public Engine(string model, int power, int displacement, string efficiency)
        {
            this.model = model;
            Power = power;
            Displacement = displacement;
            Efficiency = efficiency;
        }

        public override string ToString()
        {
            string dis = "n/a";
            if (Displacement != 0) dis = $"{Displacement}";
            return $"{model}:\n  Power: {Power}\n  Displacement: {dis}\n  Efficiency: {Efficiency}";
        }
    }
    public class Car
    {
        public string model;
        public Engine engine;
        public int Weight { get;  private set; }
        public string Color { get; set; }

        public Car(string model, Engine engine)
        {
            this.model = model;
            this.engine = engine;
        }

        public override string ToString()
        {
            string wght = "n/a";
            if (Weight != 0) wght = $"{Weight}";
            return $"{model}:\n  {engine.ToString()}\n  Weight: {wght}\n  Color: {Color}";
        }
    }
}
