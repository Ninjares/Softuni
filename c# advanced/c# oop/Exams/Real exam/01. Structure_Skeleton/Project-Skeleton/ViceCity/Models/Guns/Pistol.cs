using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Pistol : Gun
    {
        private const int initialBulletsPerBarrel = 10;
        private const int initialTotalBullets = 100;
        private const int bulletsToFire = 1;
        public Pistol(string name):base(name, initialBulletsPerBarrel, initialTotalBullets)
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
