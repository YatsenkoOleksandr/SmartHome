using SmartHome.Entities.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Services.DTO
{
    public class RegulatorDTO : BaseComponentDTO
    {
        public string MeasureName { get; set; }

        public int MinValue { get; set; }

        public int MaxValue { get; set; }

        public int Value { get; set; }
    }
}
