using SmartHome.Entities.ComponentInterfaces;
using SmartHome.Entities.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Entities.Commands
{
    public class SwitchModeCommand : ICommand
    {
        private IModeRegulator modeRegulator;

        private Mode mode;

        public SwitchModeCommand(IModeRegulator modeRegulator, Mode mode)
        {
            this.modeRegulator = modeRegulator;
            this.mode = mode;
        }

        public void Execute()
        {
            modeRegulator.SwitchMode(mode);
        }
    }
}
