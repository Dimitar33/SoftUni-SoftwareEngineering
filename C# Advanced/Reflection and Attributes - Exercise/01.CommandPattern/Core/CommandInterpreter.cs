using CommandPattern.Commands;
using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] input = args.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string commandType = input[0];
            string[] commandArguments = input.Skip(1).ToArray();


            Type type = Assembly.GetCallingAssembly().GetTypes().
                 FirstOrDefault(x => x.Name == $"{commandType}Command");

            ICommand comand = (ICommand)Activator.CreateInstance(type);

            return comand.Execute(commandArguments);
        }
    }
}
