using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Tank : BaseMachine, ITank
    {
        private const double InitialHP = 100;
        public Tank(string name, double attackPoints, double defensePoints):base(name, attackPoints, defensePoints, InitialHP)
        {
            DefenseMode = false;
            ToggleDefenseMode();
        }
        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (DefenseMode == false)
            {
                DefenseMode = true;
                AttackPoints -= 40;
                DefensePoints += 30;
            }
            else if (DefenseMode == true)
            {
                DefenseMode = false;
                AttackPoints += 40;
                DefensePoints -= 30;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            string onoroff;
            if (DefenseMode) onoroff = "ON"; else onoroff = "OFF";
            sb.AppendLine($" *Defense: {onoroff}");
            return sb.ToString().Trim();
        }
    }
}
