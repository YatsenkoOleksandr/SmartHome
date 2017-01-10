using SmartHome.Entities.ComponentInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Entities.Components
{
    public class ChannelRegulator : BaseComponent, IChannelRegulator
    {
        private Channel current;

        public virtual ICollection<Channel> Channels
        {
            get; set;
        }

        public virtual Channel Current
        {
            get
            {
                return current;
            }
            set
            {
                if(Channels.Contains(value))
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

        public int MaxFrequency
        {
            get; set;
        }

        public int MinFrequency
        {
            get; set;
        }

        public virtual void AddChannel(Channel channel)
        {
            Channel ch = Channels.FirstOrDefault(c => c.Id == channel.Id);
            if(ch == null)
            {
                Channels.Add(channel);
                NotifySuccessObservers();
            }
        }

        public virtual void RemoveChannel(Channel channel)
        {
            Channels.Remove(channel);
        }

        public virtual void SwitchChannel(Channel channel)
        {            
            if (Channels.Contains(channel))
            {
                Channels.Add(channel);
                NotifySuccessObservers();
            }
        }
    }
}
