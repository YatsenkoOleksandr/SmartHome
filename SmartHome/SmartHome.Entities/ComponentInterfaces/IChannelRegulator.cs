using SmartHome.Entities.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Entities.ComponentInterfaces
{
    public interface IChannelRegulator
    {
        int MinFrequency { get; }
        int MaxFrequency { get; }
        ICollection<Channel> Channels { get; }
        Channel Current { get; }
        void SwitchChannel(Channel channel);
        void AddChannel(Channel channel);
        void RemoveChannel(Channel channel);  
    }
}
