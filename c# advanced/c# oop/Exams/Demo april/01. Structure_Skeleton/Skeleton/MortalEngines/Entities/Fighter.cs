using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Fighter : BaseMachine, IFighter
    {
        private const double InitialHP = 200;
        public Fighter(string name, double attackPoints, double defensePoints) : base(name, attackPoints, defensePoints, InitialHP)
        {
            AggressiveMode = false;
            ToggleAggressiveMode();
        }

        
        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            if (AggressiveMode == true)
            {
                AggressiveMode = false;
                AttackPoints -= 50;
                DefensePoints += 25;
            }
            else if(AggressiveMode == false)
            {
                AggressiveMode = true;
                AttackPoints += 50;
                DefensePoints -= 25;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            string onoff;
            if (AggressiveMode) onoff = "ON"; else onoff = "OFF";
            sb.AppendLine($" *Aggressive: {onoff}");
            return sb.ToString().Trim();
        }
    }
}
