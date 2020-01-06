using PlayersAndMonsters.IO;
using PlayersAndMonsters.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Core.Contracts
{
    class Engine : IEngine
    {
        IManagerController managerController = new ManagerController();
        ICommandInterpereter commandInterpereter;
        IReader reader = new Reader();
        IWriter writer = new Writer();

        public Engine()
        {
            commandInterpereter = new CommandInterpreter(managerController);
        }
        public void Run()
        {
            
            while (true)
            {
                string command = reader.ReadLine();
                if (command == "Exit") break;
                else
                {
                    writer.WriteLine(commandInterpereter.Read(command.Split()));
                }
            }
         
        }
    }
}
