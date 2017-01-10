using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Entities.ComponentInterfaces
{
    public interface IRegulator
    {
        string MeasureName { get; }
        int MinValue { get; }
        int MaxValue { get; }
        int Value { get; set; }
    }
}
