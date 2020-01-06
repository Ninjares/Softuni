using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ViceCity.Core.Contracts;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Players;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories;
using ViceCity.Repositories.Contracts;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Neghbourhoods;

namespace ViceCity.Core
{
    public class Controller : IController
    {
        private List<IPlayer> civilians = new List<IPlayer>();
        private IPlayer mainPlayer = new MainPlayer();
        private Queue<IGun> guns = new Queue<IGun>();
        public string AddGun(string type, string name)
        {
            
            IGun gun = null;
            switch (type)
            {
                case "Pistol":
                    {
                        gun = new Pistol(name);
                        break;
                    }
                case "Rifle":
                    {
                        gun = new Rifle(name);
                        break;
                    }
                default:
                    {
                        return "Invalid gun type!";
                    }
            }
            guns.Enqueue(gun);
            return $"Successfully added {gun.Name} of type: {gun.GetType().Name}";
        }

        public string AddGunToPlayer(string name)
        {
            if (guns.Count == 0) return "There are no guns in the queue!";
            if (name == "Vercetti")
            {
                IGun guntoadd = guns.Dequeue();
                mainPlayer.GunRepository.Add(guntoadd);
                return $"Successfully added {guntoadd.Name} to the Main Player: Tommy Vercetti";
            }
            else if (!civilians.Any(x => x.Name == name)) return "Civil player with that name doesn't exists!";
            else
            {
                IPlayer playertoaddgunto = civilians.FirstOrDefault(x => x.Name == name);
                IGun guntoadd = guns.Dequeue();
                playertoaddgunto.GunRepository.Add(guntoadd);
                return $"Successfully added {guntoadd.Name} to the Civil Player: {playertoaddgunto.Name}";
            }
        }

        public string AddPlayer(string name)
        {
            IPlayer player = new CivilPlayer(name);
            civilians.Add(player);
            return $"Successfully added civil player: {player.Name}!";
        }

        public string Fight()
        {
            INeighbourhood neighbourhood = new GangNeighbourhood();
            neighbourhood.Action(mainPlayer, civilians);
            bool allok = false;
            if (mainPlayer.LifePoints == 100 && civilians.All(x => x.LifePoints == 50)) allok = true;
            if (allok) return "Everything is okay!";
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("A fight happened:");
                sb.AppendLine($"Tommy live points: {mainPlayer.LifePoints}!");
                sb.AppendLine($"Tommy has killed: {civilians.Count(x => !x.IsAlive)} players!");
                sb.AppendLine($"Left Civil Players: {civilians.Count(x => x.IsAlive)}!");
                return sb.ToString().Trim();
            }
        }
    }
}
