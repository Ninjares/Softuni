using System;
using System.Collections.Generic;
using System.Text;
using MortalEngines.Entities.Contracts;
using MortalEngines.Common;
using System.Linq;

namespace MortalEngines.Entities
{
    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;
        private IList<string> targets;
        public string Name { get => name; private set { if (String.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("Machine name cannot be null or empty."); else name = value; } }

        public IPilot Pilot { get => pilot; set { if (value==null) throw new NullReferenceException("Pilot cannot be null."); else pilot = value; } }
        public double HealthPoints { get; set; }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public IList<string> Targets => targets;

        public void Attack(IMachine target)  
        {
            if (target == null) throw new NullReferenceException("Target cannot be null");
            double diff = this.AttackPoints - target.DefensePoints; //what if attackpoints > defensepoints?
            
            if (diff > target.HealthPoints) target.HealthPoints = 0;
            else
            {
                target.HealthPoints -= diff;
            }
            if (!targets.Contains(target.Name)) targets.Add(target.Name);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- {this.Name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Health: {this.HealthPoints:F2}");
            sb.AppendLine($" *Attack: {this.AttackPoints:F2}");
            sb.AppendLine($" *Defense: {this.DefensePoints:F2}");
            string targetstoadd;
            if (targets.Count == 0) targetstoadd = "None";
            else targetstoadd = String.Join(",", targets);
            sb.AppendLine($" *Targets: {targetstoadd}");
            return sb.ToString().Trim();
        }

        protected BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
            targets = new List<string>();
        }
    }
}
