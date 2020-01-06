using System;
using System.Collections.Generic;
using System.Text;

namespace Raw_Data
{
    public class Engine
    {
        public int Speed { get; set; }
        public int Power { get; set; }

        public Engine(int Speed, int Power)
        {
            this.Speed = Speed;
            this.Power = Power;
        }

    }

    public class Cargo
    {
        public int Weight { get; set; }
        public string Type { get; set; }

        public Cargo(int Weight, string Type)
        {
            this.Weight = Weight;
            this.Type = Type;
        }

    }

    public class Tire
    {
        public int TireAge { get; private set; }
        public double TirePressure { get; private set; }

        public Tire(int TireAge, double TirePressure)
        {
            this.TireAge = TireAge;
            this.TirePressure = TirePressure;
        }
    }


    public class Car
    {
        public string model;

        public Engine engine;

        public Cargo cargo;

        public Tire[] tires;

        public Car(string model, Engine engine, Cargo cargo, Tire tire1, Tire tire2, Tire tire3, Tire tire4)
        {
            this.model = model;
            this.engine = engine;
            this.cargo = cargo;
            this.tires = new Tire[4];
            tires[0] = tire1;
            tires[1] = tire2;
            tires[2] = tire3;
            tires[3] = tire4;
        }

        public bool TirePressBellow(double pressure)
        {
            bool bellow = false;
            foreach (Tire tire in tires) if (tire.TirePressure < pressure) bellow = true;
            return bellow;
        }
    }
}
