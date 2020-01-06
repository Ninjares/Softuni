using ViceCity.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.IO.Contracts;
using ViceCity.IO;

namespace ViceCity.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;


        public Engine()
        {
            this.reader = new Reader();
            this.writer = new Writer();

        }
        public void Run()
        {
            IController controller = new Controller();
            while (true)
            {
                var input = Console.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    if (input[0] == "AddPlayer")
                    {
                        Console.WriteLine(controller.AddPlayer(input[1]));
                    }
                    else if (input[0] == "AddGun")
                    {
                        Console.WriteLine(controller.AddGun(input[1], input[2]));
                    }
                    else if (input[0] == "AddGunToPlayer")
                    {
                        Console.WriteLine(controller.AddGunToPlayer(input[1]));
                    }
                    else if (input[0] == "Fight")
                    {
                        Console.WriteLine(controller.Fight());
                    }            
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
