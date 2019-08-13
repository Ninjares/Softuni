using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Pilot : IPilot
    {
        
        private string name;
        public string Name { get => name; private set { if (String.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("Pilot name cannot be null or empty string."); else name = value;  } }

        private List<IMachine> machines = new List<IMachine>();

        public Pilot(string name)
        {
            Name = name;
        }
        public void AddMachine(IMachine machine)
        {
            if (machine == null) throw new NullReferenceException("Null machine cannot be added to the pilot.");
            else machines.Add(machine);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Name} - {machines.Count} machines");
            foreach (IMachine machine in machines)
            {
                sb.AppendLine(machine.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
