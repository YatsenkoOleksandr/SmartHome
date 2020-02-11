using SmartHome.EFStorage.EFContext;
using SmartHome.Entities.Commands;
using SmartHome.Entities.ComponentInterfaces;
using SmartHome.Entities.Components;
using SmartHome.Entities.Devices;
using SmartHome.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            using (SmartHomeContext context = new SmartHomeContext())
            {
                IQueryable<BaseDevice> devices = context.BaseDevices
                    .Include("Switches")
                    .Include("Regulators")
                    .Include("ChannelRegulators")
                    .Include("ChannelRegulators.Current")
                    .Include("ChannelRegulators.Channels");
                foreach (BaseDevice item in devices)
                {
                    Console.WriteLine("{0} {1}", item.Id, item.Name);
                    foreach(Switch sw in item.Switches)
                    {
                        Console.WriteLine("\t{0} {1} {2}", sw.Id, sw.Name, sw.IsSwitchOn);
                    }
                    foreach(Regulator reg in item.Regulators)
                    {
                        Console.WriteLine("\t{0} {1} {2} {3} {4} {5}", 
                            reg.Id, 
                            reg.Name, 
                            reg.MeasureName,
                            reg.MinValue,
                            reg.MaxValue,
                            reg.Value);
                    }
                    foreach(ChannelRegulator chReg in item.ChannelRegulators)
                    {
                        Console.WriteLine("\t{0} {1} {2} {3}",
                            chReg.Id,
                            chReg.Name,
                            chReg.MinFrequency,
                            chReg.MaxFrequency);
                        Console.WriteLine("\t{0} {1} {2}",
                           chReg.Current.Id,
                           chReg.Current.Name,
                           chReg.Current.Frequency);
                        foreach (Channel ch in chReg.Channels)
                        {
                            Console.WriteLine("\t\t{0} {1} {2}",
                                ch.Id,
                                ch.Name,
                                ch.Frequency);
                        }
                    }
                }             
            }*/

            /*
            BaseDevice bd = new Fridge()
            {
                Name = "Samsung",
                Switches = new List<Switch>()
            };

            bd.Switches.Add(new Switch()
            {
                Name = "ESwitch",
                BaseDevice = bd,
                IsSwitchOn = false
            });
            */

            /*
            DeviceService service = new DeviceService();
            BaseDevice bd = service.Get(3);
            ICommand cmd = new SwitchChannelCommand(bd.ChannelRegulators.FirstOrDefault(), new Channel());
            service.ExecuteCommand(cmd);

            Console.WriteLine(bd.Switches.FirstOrDefault().IsSwitchOn);
            */
        }        
    }
}
