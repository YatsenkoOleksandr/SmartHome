using SmartHome.Entities.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Services.DTO
{
    public class ModeRegulatorDTO : BaseComponentDTO
    {
        public ModeRegulatorDTO()
        {
            ModeDTOs = new List<ModeDTO>();
        }

        public ICollection<ModeDTO> ModeDTOs { get; set; }

        public ModeDTO Current { get; set; }
    }
}
