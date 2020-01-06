namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Common;
    using MortalEngines.Entities;
    using MortalEngines.Entities.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class MachinesManager : IMachinesManager
    {
        private IList<IPilot> pilots = new List<IPilot>();
        private IList<IMachine> machines = new List<IMachine>();
        public string HirePilot(string name)
        {
            if (pilots.Any(x => x.Name == name)) return $"Pilot {name} is hired already";
            pilots.Add(new Pilot(name));
            return $"Pilot {name} hired";
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (machines.Any(x => x.Name == name)) return $"Machine {name} is manufactured already";
            else
            {
                ITank tank = new Tank(name, attackPoints, defensePoints);
                machines.Add(tank);
                return $"Tank {tank.Name} manufactured - attack: {tank.AttackPoints:F2}; defense: {tank.DefensePoints:F2}";
            }
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (machines.Any(x => x.Name == name)) return $"Machine {name} is manufactured already";
            else
            {
                IFighter fighter = new Fighter(name, attackPoints, defensePoints);
                machines.Add(fighter);
                return $"Fighter {fighter.Name} manufactured - attack: {fighter.AttackPoints:F2}; defense: {fighter.DefensePoints:F2}; aggressive: ON";
            }
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            if (!pilots.Any(x => x.Name == selectedPilotName)) return $"Pilot {selectedPilotName} could not be found";
            if (!machines.Any(x => x.Name == selectedMachineName)) return $"Machine {selectedMachineName} could not be found";
            IMachine machine = machines.FirstOrDefault(x => x.Name == selectedMachineName);
            if (machine.Pilot != null) return $"Machine {machine.Name} is already occupied";
            IPilot pilot = pilots.FirstOrDefault(x => x.Name == selectedPilotName);
            machine.Pilot = pilot;
            pilot.AddMachine(machine);
            return $"Pilot {pilot.Name} engaged machine {machine.Name}";
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            IMachine attackingMachine = machines.FirstOrDefault(x => x.Name == attackingMachineName);
            IMachine defendingMachine = machines.FirstOrDefault(x => x.Name == defendingMachineName);
            if (attackingMachine == null) return $"Machine {attackingMachineName} could not be found";
            if (defendingMachine == null) return $"Machine {defendingMachineName} could not be found";
            if (attackingMachine.HealthPoints <= 0) return $"Dead machine {attackingMachine.Name} cannot attack or be attacked";
            if (defendingMachine.HealthPoints == 0) return $"Dead machine {defendingMachine.Name} cannot attack or be attacked";
            attackingMachine.Attack(defendingMachine);
            return $"Machine {defendingMachine.Name} was attacked by machine {attackingMachine.Name} - current health: {defendingMachine.HealthPoints:F2}";
        }

        public string PilotReport(string pilotReporting)
        {
            return pilots.FirstOrDefault(x => x.Name == pilotReporting).Report();
        }

        public string MachineReport(string machineName)
        {
            return machines.FirstOrDefault(x => x.Name == machineName).ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            IFighter fighter = (IFighter) machines.FirstOrDefault(x => x.Name == fighterName);
            if (fighter == null) return $"Machine {fighterName} could not be found";
            else
            {
                fighter.ToggleAggressiveMode();
                return $"Fighter {fighter.Name} toggled aggressive mode";
            }
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            ITank tank = (ITank)machines.FirstOrDefault(x => x.Name == tankName);
            if (tank == null) return $"Machine {tankName} could not be found";
            else
            {
                tank.ToggleDefenseMode();
                return $"Tank {tank.Name} toggled defense mode";
            }
        }
    }
}