using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.IO.Contracts
{
    class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
