using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string name;
        private int lifePoints;
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("Player's name cannot be null or a whitespace!");
                else name = value;
            }
        }
        public int LifePoints
        {
            get => lifePoints;
            private set
            {
                if (value < 0) throw new ArgumentException("Player life points cannot be below zero!");
                else lifePoints = value;
            }
        }
        public IRepository<IGun> GunRepository { get; private set; }
        protected Player(string name, int lifePoints)
        {
            this.Name = name;
            this.LifePoints = lifePoints;
            GunRepository = new GunRepository();
        }

        public bool IsAlive { get => LifePoints != 0; }
        public void TakeLifePoints(int points)
        {
            if (points >= LifePoints) LifePoints = 0;
            else LifePoints -= points;
        }
    }
}
