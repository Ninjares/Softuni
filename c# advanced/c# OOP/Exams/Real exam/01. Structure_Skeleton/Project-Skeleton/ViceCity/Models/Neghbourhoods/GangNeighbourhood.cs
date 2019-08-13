using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Models.Neghbourhoods
{
    public class GangNeighbourhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            while (mainPlayer.GunRepository.Models.Count != 0 && civilPlayers.Any(x => x.IsAlive))
            {
                IGun mpGun = mainPlayer.GunRepository.Models.FirstOrDefault();
                mainPlayer.GunRepository.Remove(mpGun);
                while (mpGun.TotalBullets != 0&& civilPlayers.Any(x => x.IsAlive))
                {
                    IPlayer civplayer = civilPlayers.First(x => x.IsAlive);
                    while (civplayer.IsAlive && mpGun.CanFire) civplayer.TakeLifePoints(mpGun.Fire());
                }
            }
            foreach(IPlayer civplayer in civilPlayers.Where(x => x.IsAlive))
            {
                while (civplayer.GunRepository.Models.Count != 0 && mainPlayer.IsAlive) {
                    IGun civgun = civplayer.GunRepository.Models.First();
                    civplayer.GunRepository.Remove(civgun);
                    while (civgun.CanFire&&mainPlayer.IsAlive)
                    {
                        mainPlayer.TakeLifePoints(civgun.Fire());
                    } 
                }
                
            }
            
        }
    }
}
