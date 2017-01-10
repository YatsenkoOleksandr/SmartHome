using SmartHome.Entities.ComponentInterfaces;
using SmartHome.Entities.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Entities.Commands
{
    public class AddChannelCommand : ICommand
    {
        private IChannelRegulator channelRegulator;
        private Channel channel;

        public AddChannelCommand(IChannelRegulator channelRegulator, Channel channel)
        {
            this.channelRegulator = channelRegulator;
            this.channel = channel;
        }

        public void Execute()
        {
            channelRegulator.AddChannel(channel);
        }
    }
}
