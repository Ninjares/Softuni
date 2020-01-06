using System;
using System.Collections.Generic;
using System.Text;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using PlayersAndMonsters.Common;

namespace PlayersAndMonsters.Models.Players
{
    public abstract class Player : IPlayer
    {
        
        private string username;
        private int health;
        public ICardRepository CardRepository { get; }

        public string Username { get => username; private set { if (String.IsNullOrEmpty(value)) throw new ArgumentException(ExceptionMessages.NullOrEmptyUsername); else username = value; } }

        public int Health { get => health; set { if (value < 0) throw new ArgumentException(ExceptionMessages.HealthBonusBellowZero); else health = value; } }

        public bool IsDead { get => Health == 0; }

        public void TakeDamage(int damagePoints)
        {
            if (damagePoints < 0) throw new ArgumentException(ExceptionMessages.DamageBellowZero);
            else if (damagePoints>Health)
            {
                Health = 0;
            }
            else Health -= damagePoints;
        }
        public Player(ICardRepository cardRepository, string username, int health)
        {
            Username = username;
            Health = health;
            CardRepository = cardRepository;
        }
    }
}
