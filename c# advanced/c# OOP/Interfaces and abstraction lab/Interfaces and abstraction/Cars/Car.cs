using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public abstract class Car //so you don't duplicate fields and functions
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public string Drive()
        {
            return "Engine start";
        }
        public string Stop()
        {
            return "Breaaak!";
        }
    }
    public interface ICar
    {
        string Model { get; set; }
        string Color { get; set; } //remove setters, check presentation
        string Drive();
        string Stop();
    }

    public interface IElectricCar:ICar
    {
        int Battery { get; set; }
    }

    public class Seat: Car, ICar
    {
        

        public Seat(string model, string color)
        {
            Model = model;
            Color = color;
        }

        public override string ToString()
        {
            return $"{Color} Seat {Model}";
        }
    }
    public class Tesla: Car, IElectricCar
    {
        public int Battery { get; set; }
        
        public Tesla(string model, string color, int battery)
        {
            Model = model;
            Color = color;
            Battery = battery;
        }

        public override string ToString()
        {
            return $"{Color} Tesla {Model} with {Battery} Batteries";
        }
    }
}
