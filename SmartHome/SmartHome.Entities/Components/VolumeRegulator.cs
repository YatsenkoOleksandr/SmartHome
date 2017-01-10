using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Entities.Components
{
    public class VolumeRegulator: Regulator
    {
        private const string MEASURE_NAME = "Volume";

        public VolumeRegulator()
        {
            MeasureName = MEASURE_NAME;
        }

        public VolumeRegulator(string measureName)
        {
            MeasureName = measureName;
        }
    }
}
