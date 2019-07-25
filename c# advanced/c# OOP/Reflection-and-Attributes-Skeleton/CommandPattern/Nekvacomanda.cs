using System;
using System.Collections.Generic;
using System.Text;
using CommandPattern.Core.Contracts;

namespace CommandPattern
{
    class NekvaCommand : ICommand
    {
        public string Execute(string[] args)
        {
            return "wooooo";
        }
    }
}
