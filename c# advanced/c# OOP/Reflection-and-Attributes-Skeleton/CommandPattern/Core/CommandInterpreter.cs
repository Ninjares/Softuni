using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] argss = args.Split(' ', 2);
            string commandname = argss[0]+"Command";
            string[] commandArg;
            if (argss.Length > 1) commandArg = argss[1].Split();
            else commandArg = null;
            Assembly assembly = Assembly.GetCallingAssembly();
            Type[] types = assembly.GetTypes();
            Type type = types.FirstOrDefault(x => x.Name == commandname); //fix dis
            ICommand command = (ICommand)Activator.CreateInstance(type);
            
            return command.Execute(commandArg);
        }
    }
}
