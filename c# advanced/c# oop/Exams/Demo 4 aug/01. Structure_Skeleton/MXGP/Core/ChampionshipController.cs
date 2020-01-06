using MXGP.Models.Motorcycles;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Races;
using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders;
using MXGP.Models.Riders.Contracts;
using MXGP.Repositories;
using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MXGP.Core.Contracts;

namespace MXGP.Core
{
    public class ChampionshipController:IChampionshipController
    {
        private IRepository<IRider> riders = new RiderRepository();
        private IRepository<IMotorcycle> motorcycles = new MotorcycleRepository();
        private IRepository<IRace> races = new RaceRepository();
        public string CreateRider(string name)
        {
            if (riders.GetByName(name) != null) throw new ArgumentException($"Rider {name} is already created.");
            else
            {
                riders.Add(new Rider(name));
                return $"Rider {name} is created.";
            }
        }
        public string CreateMotorcycle(string type, string model, int hp)
        {
            if (motorcycles.GetByName(model) != null) throw new ArgumentException($"Motorcycle {model} is already created.");
            IMotorcycle motorcycle = null;
            if (type == "Power") motorcycle = new PowerMotorcycle(model, hp);
            else if (type == "Speed") motorcycle = new SpeedMotorcycle(model, hp);
            motorcycles.Add(motorcycle);
            return $"{motorcycle.GetType().Name} {model} is created.";

        }
        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            IRider rider = riders.GetByName(riderName);
            IMotorcycle motorcycle = motorcycles.GetByName(motorcycleModel);
            if (rider == null) throw new InvalidOperationException($"Rider {riderName} could not be found.");
            if (motorcycleModel == null) throw new InvalidOperationException($"Motorcycle {motorcycleModel} could not be found.");
            rider.AddMotorcycle(motorcycle);
            return $"Rider {rider.Name} received motorcycle {motorcycle.Model}.";
        }
        public string AddRiderToRace(string raceName, string riderName)
        {
            IRider rider = riders.GetByName(riderName);
            IRace race = races.GetByName(raceName);
            if (rider == null) throw new InvalidOperationException($"Rider {riderName} could not be found.");
            if (race == null) throw new InvalidOperationException($"Race {raceName} could not be found.");
            race.AddRider(rider);
            return $"Rider {rider.Name} added in {race.Name} race.";
        }
        public string CreateRace(string name, int laps)
        {
            if (races.GetByName(name) != null) throw new InvalidOperationException($"Race {name} is already created.");
            races.Add(new Race(name, laps));
            return $"Race {name} is created.";
        }
        public string StartRace(string raceName)
        {
            IRace race = null;
            if (races.GetByName(raceName) == null) throw new InvalidOperationException($"Race {raceName} could not be found.");
            else race = races.GetByName(raceName);
            if (race.Riders.Count < 3) throw new InvalidOperationException($"Race {race.Name} cannot start with less than 3 participants.");
            StringBuilder sb = new StringBuilder();
            IRider[] first3 = race.Riders.OrderByDescending(x => x.Motorcycle.CalculateRacePoints(race.Laps)).ToArray();
            sb.AppendLine($"Rider {first3[0].Name} wins {race.Name} race.");
            sb.AppendLine($"Rider {first3[1].Name} is second in {race.Name} race.");
            sb.AppendLine($"Rider {first3[2].Name} is third in {race.Name} race.");
            races.Remove(race);
            return sb.ToString().TrimEnd();
        }
    }
}
