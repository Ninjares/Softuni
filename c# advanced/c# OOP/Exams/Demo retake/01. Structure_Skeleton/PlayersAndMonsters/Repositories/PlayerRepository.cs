using System;
using System.Collections.Generic;
using System.Text;
using PlayersAndMonsters.Repositories.Contracts;
using PlayersAndMonsters.Common;
using PlayersAndMonsters.Models.Players.Contracts;
using System.Linq;

namespace PlayersAndMonsters.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private List<IPlayer> players = new List<IPlayer>();
        public int Count => players.Count;

        public IReadOnlyCollection<IPlayer> Players => players.AsReadOnly();

        public void Add(IPlayer player)
        {
            if (player == null) throw new ArgumentException(ExceptionMessages.PRNullPlayer);
            else if (players.Any(x => x.Username == player.Username)) throw new ArgumentException(String.Format(ExceptionMessages.PRexists, player.Username));
            else players.Add(player);
        }

        public IPlayer Find(string username)
        {
            return players.FirstOrDefault(x => x.Username == username);
        }

        public bool Remove(IPlayer player)
        {
            if(player == null) throw new ArgumentException(ExceptionMessages.PRNullPlayer);
            if (Find(player.Username) == player)
            {
                players.Remove(player);
                return !players.Contains(player);
            }
            else return false;
        }
    }
}
