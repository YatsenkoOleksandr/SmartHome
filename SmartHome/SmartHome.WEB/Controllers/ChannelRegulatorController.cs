using SmartHome.Services;
using SmartHome.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartHome.WEB.Controllers
{
    public class ChannelRegulatorController : Controller
    {
        private DeviceService deviceService;

        public ChannelRegulatorController()
        {
            deviceService = new DeviceService();
        }

        [HttpPost]
        public ActionResult Edit(ChannelRegulatorDTO modeRegulator)
        {
            return View();
        }
    }
}