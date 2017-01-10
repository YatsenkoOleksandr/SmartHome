using SmartHome.Entities.ComponentInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Entities.Commands
{
    public class RegulatorCommand : ICommand
    {
        private IRegulator regulator;

        private int value;     

        public RegulatorCommand(IRegulator regulator, int value)
        {
            this.regulator = regulator;
            this.value = value;
        }

        public void Execute()
        {
            regulator.Value = value;
        }
    }
}
