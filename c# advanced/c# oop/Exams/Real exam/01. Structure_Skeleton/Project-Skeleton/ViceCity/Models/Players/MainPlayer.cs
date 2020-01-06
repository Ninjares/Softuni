using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Players
{
    public class MainPlayer:Player
    {
        private const int InitialHP = 100;
        private const string name = "Tommy Vercetti";
        public MainPlayer() : base(name, InitialHP)
        {

        }
    }
}
