using SmartHome.Entities.ComponentInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Entities.Commands
{
    public class SwitchOnCommand: ICommand
    {
        private ISwitch switcher;

        public SwitchOnCommand(ISwitch switcher)
        {
            this.switcher = switcher;
        }

        public void Execute()
        {
            switcher.SwitchOn();
        }
    }
}
