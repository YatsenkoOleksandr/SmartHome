using SmartHome.Entities.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Services
{
    public class CommandExecuter
    {
        private ICollection<ICommand> commands;

        public CommandExecuter()
        {
            commands = new List<ICommand>();
        }

        public void AddCommand(ICommand command)
        {
            commands.Add(command);
        }

        public void Execute()
        {
            foreach(ICommand command in commands)
            {
                command.Execute();
            }
            commands.Clear();
        }
    }
}
