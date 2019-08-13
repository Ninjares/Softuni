using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Guns.Contracts;

namespace ViceCity.Models.Guns
{
    public abstract class Gun : IGun
    {
        private string name;
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentException("Name cannot be null or a white space!"); //ArgumentNullException?
                else name = value;
            }
        }
        private int bulletsperbarrel;
        public int BulletsPerBarrel
        {
            get => bulletsperbarrel;
            protected set
            {
                if (value < 0) throw new ArgumentException("Bullets cannot be below zero!");
                else bulletsperbarrel = value;
            }
        }
        private int totalbullets;
        public int TotalBullets
        {
            get => totalbullets;
            protected set
            {
                if (value < 0) throw new ArgumentException("Total bullets cannot be below zero!");
                else totalbullets = value;
            }
        }

        protected Gun(string name, int bulletsPerBarrel, int totalBullets)
        {
            this.Name = name;
            this.BulletsPerBarrel = bulletsPerBarrel;
            this.TotalBullets = totalBullets;
        }

        public bool CanFire { get => TotalBullets != 0; }

        public abstract int Fire();
    }
}
