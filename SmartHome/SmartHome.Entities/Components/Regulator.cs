using SmartHome.Entities.ComponentInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Entities.Components
{   
    public class Regulator : BaseComponent, IRegulator
    {
        private int value;

        public int MaxValue
        {
            get; set;            
        }

        public string MeasureName
        {
            get; set;
        }

        public int MinValue
        {
            get; set;
        }

        public virtual int Value
        {
            get
            {
                return value;
            }

            set
            {
                if(value >= MinValue && value <= MaxValue)
                {
                    this.value = value;
                    NotifySuccessObservers();
                }
                else
                {
                    NotifyFailObservers();
                }
            }
        }
    }
}
