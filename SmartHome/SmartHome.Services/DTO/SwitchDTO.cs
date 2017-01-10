using SmartHome.Entities.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Services.DTO
{
    public class SwitchDTO : BaseComponentDTO
    {
        public bool IsSwitchOn { get; set; }
    }
}
