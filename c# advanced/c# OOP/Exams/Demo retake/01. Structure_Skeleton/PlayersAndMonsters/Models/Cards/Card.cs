using System;
using System.Collections.Generic;
using System.Text;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Common;

namespace PlayersAndMonsters.Models.Cards
{
    public abstract class Card : ICard
    {
        private string name;
        private int dmg;
        private int hp;
        public string Name { get => name; private set { if (String.IsNullOrEmpty(value)) throw new ArgumentException(ExceptionMessages.CardNullOrEmpty); else name = value; } }

        public int DamagePoints { get => dmg; set { if (value < 0) throw new ArgumentException(ExceptionMessages.CardDmgBellow0); else dmg = value; } }

        public int HealthPoints { get => hp; private set { if (value< 0) throw new ArgumentException(ExceptionMessages.CardHpBellow0); else hp = value; } }
        
        protected Card(string name, int damagePoints, int healthPoints)
        {
            Name = name;
            DamagePoints = damagePoints;
            HealthPoints = healthPoints;
        }

    }
}
