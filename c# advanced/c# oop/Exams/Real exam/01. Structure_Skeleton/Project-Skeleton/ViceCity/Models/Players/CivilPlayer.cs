using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Players
{
    public class CivilPlayer:Player
    {
        private const int InitialHP = 50;
        
        public CivilPlayer(string name):base(name, InitialHP)
        {

        }

    }
}
