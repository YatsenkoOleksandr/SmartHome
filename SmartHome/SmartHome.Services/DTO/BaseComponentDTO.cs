using SmartHome.Entities.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Services.DTO
{
    public class BaseComponentDTO
    {
        public int DeviceId { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
