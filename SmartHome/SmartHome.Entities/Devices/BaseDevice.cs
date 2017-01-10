using SmartHome.Entities.Components;
using SmartHome.Entities.ObserverInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Entities.Devices
{
    public class BaseDevice: IFailObserver, ISuccessObserver
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Switch> Switches { get; set; }

        public virtual ICollection<Regulator> Regulators { get; set; }

        public virtual ICollection<ChannelRegulator> ChannelRegulators { get; set; }

        public virtual ICollection<ModeRegulator> ModeRegulators { get; set; }

        public virtual void FailUpdate()
        {

        }

        public virtual void SuccessUpdate()
        {

        }
    }
}
