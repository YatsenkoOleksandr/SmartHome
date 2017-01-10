using SmartHome.EFStorage.EFRepository;
using SmartHome.Entities.Commands;
using SmartHome.Entities.Components;
using SmartHome.Entities.Devices;
using SmartHome.Entities.RepositoryInterfaces;
using SmartHome.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Services
{
    public class DeviceService
    {
        private IUnitOfWork unitOfWork;

        public DeviceService()
        {
            
        }

        public IEnumerable<DeviceInfoDTO> GetBaseDevices()
        { 
            using (unitOfWork = new EFUnitOfWork(new EFStorage.EFContext.SmartHomeContext()))
            {
                List<DeviceInfoDTO> deviceDTOs = new List<DeviceInfoDTO>();
                IEnumerable<BaseDevice> dbDevices = unitOfWork.GetRepository<BaseDevice>().Get();

                foreach(BaseDevice device in dbDevices)
                {
                    deviceDTOs.Add(new DeviceInfoDTO()
                    {
                        Id = device.Id,
                        Name = device.Name
                    });
                }

                return deviceDTOs;
            }
        }

        public DeviceDTO Get(int deviceId)
        {
            using (unitOfWork = new EFUnitOfWork(new EFStorage.EFContext.SmartHomeContext()))
            {
                BaseDevice device = unitOfWork.GetRepository<BaseDevice>()
                        .Get(d => d.Id == deviceId,
                        includeProperties: "Switches,Regulators,ChannelRegulators.Channels,ChannelRegulators.Current,ModeRegulators,ModeRegulators.Current")
                        .FirstOrDefault();
                DeviceDTO deviceDTO = new DeviceDTO()
                {
                    Id = device.Id,
                    Name = device.Name                    
                };
                foreach(Switch component in device.Switches)
                {
                    deviceDTO.SwitchDTOs.Add(new SwitchDTO()
                    {
                        DeviceId = deviceDTO.Id,
                        Name = component.Name,
                        IsSwitchOn = component.IsSwitchOn,
                        Id = component.Id
                    });
                }
                foreach(Regulator regulator in device.Regulators)
                {
                    deviceDTO.RegulatorDTOs.Add(new RegulatorDTO()
                    {
                        DeviceId = deviceDTO.Id,
                        Name = regulator.Name,
                        MeasureName = regulator.MeasureName,
                        MinValue = regulator.MinValue,
                        MaxValue = regulator.MaxValue,
                        Value = regulator.Value,
                        Id = regulator.Id
                    });
                }

                FormModeRegulator(device, deviceDTO);
                FormChannelRegulatorDTO(device, deviceDTO);
                
                return deviceDTO;
            }
        }    

        private void FormModeRegulator(BaseDevice device, DeviceDTO deviceDTO)
        {
            foreach (ModeRegulator modeRegulator in device.ModeRegulators)
            {
                ModeRegulatorDTO modeRegulatorDTO = new ModeRegulatorDTO()
                {
                    DeviceId = deviceDTO.Id,
                    Name = modeRegulator.Name,
                    Id = modeRegulator.Id
                };
                foreach(Mode mode in modeRegulator.Modes)
                {
                    modeRegulatorDTO.ModeDTOs.Add(new ModeDTO()
                    {
                        Id = mode.Id,
                        Name = mode.Name
                    });
                }
                modeRegulatorDTO.Current = new ModeDTO()
                {
                    Id = modeRegulator.Current.Id,
                    Name = modeRegulator.Current.Name
                };
                deviceDTO.ModeRegulatorDTOs.Add(modeRegulatorDTO);
            }
        }

        private void FormChannelRegulatorDTO(BaseDevice device, DeviceDTO deviceDTO)
        {
            foreach (ChannelRegulator channelRegulator in device.ChannelRegulators)
            {
                ChannelRegulatorDTO channelRegulatorDTO = new ChannelRegulatorDTO()
                {
                    DeviceId = deviceDTO.Id,
                    Name = channelRegulator.Name,
                    MinFrequency = channelRegulator.MinFrequency,
                    MaxFrequency = channelRegulator.MaxFrequency,
                    Id = channelRegulator.Id
                };
                foreach (Channel channel in channelRegulator.Channels)
                {
                    channelRegulatorDTO.ChannelDTOs.Add(new ChannelDTO()
                    {
                        Id = channel.Id,
                        Name = channel.Name,
                        Frequency = channel.Frequency
                    });
                }
                channelRegulatorDTO.Current = new ChannelDTO()
                {
                    Id = channelRegulator.Id,
                    Name = channelRegulator.Name,
                    Frequency = channelRegulator.Current.Frequency
                };
                deviceDTO.ChannelRegulatorDTOs.Add(channelRegulatorDTO);
            }
        }

        public void Add(BaseDevice device)
        {
            using (unitOfWork = new EFUnitOfWork(new EFStorage.EFContext.SmartHomeContext()))
            {
                unitOfWork.GetRepository<BaseDevice>().Add(device);
                unitOfWork.Save();
            }
        }

        public void Remove(int deviceId)
        {
            using (unitOfWork = new EFUnitOfWork(new EFStorage.EFContext.SmartHomeContext()))
            {
                unitOfWork.GetRepository<BaseDevice>().Delete(deviceId);
            }
        }

        public void ExecuteCommand(ICommand cmd)
        {
            using (unitOfWork = new EFUnitOfWork(new EFStorage.EFContext.SmartHomeContext()))
            {
                cmd.Execute();
                unitOfWork.Save();
            }
        }

        public void Update(SwitchDTO switchDTO)
        {
            using (unitOfWork = new EFUnitOfWork(new EFStorage.EFContext.SmartHomeContext()))
            {
                Switch updatedSwitch = unitOfWork.GetRepository<Switch>()
                    .GetById(switchDTO.Id);
                updatedSwitch.IsSwitchOn = switchDTO.IsSwitchOn;
                unitOfWork.Save();
            }
        }

        public void Update(RegulatorDTO regulatorDTO)
        {
            using (unitOfWork = new EFUnitOfWork(new EFStorage.EFContext.SmartHomeContext()))
            {
                Regulator updatedRegulator = unitOfWork.GetRepository<Regulator>()
                    .GetById(regulatorDTO.Id);
                updatedRegulator.Value = regulatorDTO.Value;
                unitOfWork.Save();
            }
        }
    }
}
