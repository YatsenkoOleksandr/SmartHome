using SmartHome.Entities.Components;
using SmartHome.Entities.Devices;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.EFStorage.EFContext
{
    public class SmartHomeInitializer: DropCreateDatabaseIfModelChanges<SmartHomeContext>
    {
        protected override void Seed(SmartHomeContext context)
        {
            Fridge fridge = new Fridge()
            {
                Name = "Beko",
                Switches = new List<Switch>(),
                Regulators = new List<Regulator>(),
                ChannelRegulators = new List<ChannelRegulator>()             
            };
            fridge.Switches.Add(new Switch()
            {
                Name = "Electricity Switch",
                IsSwitchOn = false               
            });
            context.Fridges.Add(fridge);

            Radio radio = new Radio()
            {
                Name = "Sony",
                Switches = new List<Switch>(),
                Regulators = new List<Regulator>(),
                ChannelRegulators = new List<ChannelRegulator>()
            };
            radio.Switches.Add(new Switch()
            {
                Name = "Electricity Switch",
                IsSwitchOn = true
            });
            radio.Regulators.Add(new VolumeRegulator()
            {
                Name = "Volume Regulator",                
                MinValue = 0,
                MaxValue = 40,
                Value = 15            
            });
            context.Radios.Add(radio);

            TVSet tvSet = new TVSet()
            {
                Name = "Toshiba",
                Switches = new List<Switch>(),
                Regulators = new List<Regulator>(),
                ChannelRegulators = new List<ChannelRegulator>()
            };
            tvSet.Switches.Add(new Switch()
            {
                Name = "Electricity Switch",
                IsSwitchOn = true              
            });
            tvSet.Regulators.Add(new VolumeRegulator()
            {
                Name = "Volume Regulator",
                MinValue = 0,
                MaxValue = 100,
                Value = 11
            });
            tvSet.Regulators.Add(new Regulator()
            {
                Name = "Brightness Regulator",
                MeasureName = "Brightness",
                MinValue = 0,
                MaxValue = 100,
                Value = 78               
            });
            ChannelRegulator chReg = new ChannelRegulator()
            {
                MinFrequency = 10,
                MaxFrequency = 20000,
                Name = "TV Channels",
                Channels = new List<Channel>()  
            };
            chReg.Channels.Add(new Channel()
            {
                Frequency = 234,
                Name = "1"
            });
            chReg.Channels.Add(new Channel()
            {
                Frequency = 19000,
                Name = "5"
            });
            chReg.Channels.Add(new Channel()
            {
                Frequency = 5000,
                Name = "8"
            });
            Channel ch = new Channel()
            {
                Frequency = 5500,
                Name = "Seven"
            };
            chReg.Channels.Add(ch);            
            tvSet.ChannelRegulators.Add(chReg);           
            context.TVSets.Add(tvSet);
            context.SaveChanges();

            tvSet.ChannelRegulators.FirstOrDefault().Current = ch;
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
