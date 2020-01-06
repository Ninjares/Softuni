using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    class Player
    {
        
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public double Skill { get => ((Endurance + Sprint + Dribble + Passing + Shooting) / 5.0); }
        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            this.Endurance = endurance;
            this.Dribble = dribble;
            this.Sprint = sprint;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public string Name { get => name; set { if (value == null || value.Trim() == "") throw new Exception("A name should not be empty"); else name = value; } }
        public int Endurance { get => endurance; set { if (value < 0 || value > 100) throw new Exception($"{nameof(Endurance)} should be between 0 and 100."); else endurance = value; } }
        public int Sprint { get => sprint; set { if (value < 0 || value > 100) throw new Exception($"{nameof(Sprint)} should be between 0 and 100."); else sprint = value; } }
        public int Dribble { get => dribble; set { if (value < 0 || value > 100) throw new Exception("Dribble should be between 0 and 100."); else dribble = value; } }
        public int Passing { get => passing; set { if (value < 0 || value > 100) throw new Exception("Passing should be between 0 and 100."); else passing = value; } }
        public int Shooting { get => shooting; set { if (value < 0 || value > 100) throw new Exception("Shooting should be between 0 and 100."); else shooting = value; } }
        
    }
}
