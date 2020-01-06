using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Core.Contracts
{
    interface ICommandInterpereter
    {
        string Read(string[] args);
    }
}
