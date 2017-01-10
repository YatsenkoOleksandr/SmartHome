using SmartHome.Entities.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Entities.ComponentInterfaces
{
    public interface IModeRegulator
    {
        ICollection<Mode> Modes { get; }

        Mode Current { get; }

        void SwitchMode(Mode mode);
    }
}
