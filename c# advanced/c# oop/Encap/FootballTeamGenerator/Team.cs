using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FootballTeamGenerator
{
    class Team
    {
        private string name;
        public string Name { get => name; set { if (value == null || value.Trim() == "") Console.WriteLine("A name should not be empty"); else name = value; } }

        private Dictionary<string, Player> players;

        public int PlayerCount { get => players.Count; }
        public Team(string name)
        {
            Name = name;
            players = new Dictionary<string, Player>();
        }

        public int Rating {
            get
            {
                if (players.Count == 0) return 0;
                else return (int)Math.Round(players.Values.Average(x => x.Skill));
            }
        }

        public void AddPlayer(Player player)
        {
            if (!players.ContainsKey(player.Name))
                players.Add(player.Name, player);
        }
        public void RemovePlayer(string name)
        {
            if (players.ContainsKey(name)) players.Remove(name);
            else throw new Exception($"Player {name} is not in {Name} team.");
        }
    }
}
