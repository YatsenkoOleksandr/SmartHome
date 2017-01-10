using SmartHome.Entities.ComponentInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Entities.Components
{
    public class ModeRegulator : BaseComponent, IModeRegulator
    {
        private Mode current;

        public Mode Current
        {
            get
            {
                return current;
            }
            set
            {
                if(Modes.Contains(value))
                {
                    current = value;
                    NotifySuccessObservers();
                }
                else
                {
                    NotifyFailObservers();
                }
            }
        }

        public ICollection<Mode> Modes
        {
            get; set;
        }

        public void SwitchMode(Mode mode)
        {
            if(Modes.Contains(mode))
            {
                Modes.Add(mode);
                NotifySuccessObservers();
            }
        }
    }
}
