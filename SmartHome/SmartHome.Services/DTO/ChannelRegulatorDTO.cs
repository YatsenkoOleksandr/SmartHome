using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHome.Entities.Components;

namespace SmartHome.Services.DTO
{
    public class ChannelRegulatorDTO : BaseComponentDTO
    {
        public ChannelRegulatorDTO()
        {
            ChannelDTOs = new List<ChannelDTO>();
        }

        public ICollection<ChannelDTO> ChannelDTOs { get; set; }

        public int MinFrequency { get; set; }

        public int MaxFrequency { get; set; }

        public ChannelDTO Current { get; set; }
    }
}
