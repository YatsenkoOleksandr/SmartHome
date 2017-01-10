using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Entities.ComponentInterfaces
{    
    public interface ISwitch
    {
        void SwitchOn();
        void SwitchOff();
        bool IsSwitchOn { get; }
    }
}
