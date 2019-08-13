using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Rifle:Gun
    {
        private const int initialBulletsPerBarrel = 50;
        private const int initialTotalBullets = 500;
        private const int bulletsToFire = 5;
        public Rifle(string name) : base(name, initialBulletsPerBarrel, initialTotalBullets)
        {

        }
        public override int Fire()
        {
            if (BulletsPerBarrel == 0)
            {
                Reload();
                return bulletsToFire;
            }
            else return bulletsToFire;
            
        }
        protected void Reload()
        {
            int amounttoreload = initialBulletsPerBarrel - BulletsPerBarrel;
            if (amounttoreload <= TotalBullets)
            {
                BulletsPerBarrel = initialBulletsPerBarrel;
                TotalBullets -= amounttoreload;
            }
            else
            {
                BulletsPerBarrel += TotalBullets;
                TotalBullets = 0;
            }

        }
    }
}
