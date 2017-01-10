using SmartHome.Entities.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Entities.DeviceInterfaces
{
    public interface IBrightnessDevice
    {
        Regulator BrightnessRegulator { get; }
    }
}
