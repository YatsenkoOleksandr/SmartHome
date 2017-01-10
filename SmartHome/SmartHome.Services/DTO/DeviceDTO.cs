using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Services.DTO
{
    public class DeviceDTO
    {
        public DeviceDTO()
        {
            SwitchDTOs = new List<SwitchDTO>();
            RegulatorDTOs = new List<RegulatorDTO>();
            ModeRegulatorDTOs = new List<ModeRegulatorDTO>();
            ChannelRegulatorDTOs = new List<ChannelRegulatorDTO>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<SwitchDTO> SwitchDTOs { get; set; }

        public ICollection<RegulatorDTO> RegulatorDTOs { get; set; }

        public ICollection<ModeRegulatorDTO> ModeRegulatorDTOs { get; set; }

        public ICollection<ChannelRegulatorDTO> ChannelRegulatorDTOs { get; set; }
    }
}