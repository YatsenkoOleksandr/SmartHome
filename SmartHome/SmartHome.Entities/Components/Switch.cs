using SmartHome.Entities.ComponentInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Entities.Components
{
    public class Switch : BaseComponent, ISwitch
    {
        public bool IsSwitchOn
        {
            get; set;
        }

        public virtual void SwitchOff()
        {
            IsSwitchOn = false;
            NotifySuccessObservers();
        }

        public virtual void SwitchOn()
        {
            IsSwitchOn = true;
            NotifySuccessObservers();
        }
    }
}
