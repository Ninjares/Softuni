using System;
using System.Collections.Generic;
using System.Text;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players
{
    class Advanced : Player
    {
        private const int StartingHP = 250;
        public Advanced(ICardRepository cardRepository, string username) : base(cardRepository, username, StartingHP)
        {

        }
    }
}
