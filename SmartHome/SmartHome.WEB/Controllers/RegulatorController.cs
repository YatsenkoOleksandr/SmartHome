using SmartHome.Services;
using SmartHome.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartHome.WEB.Controllers
{
    public class RegulatorController : Controller
    {
        private DeviceService deviceService;

        public RegulatorController()
        {
            deviceService = new DeviceService();
        }

        [HttpPost]
        public ActionResult Edit(RegulatorDTO regulator)
        {
            deviceService.Update(regulator);

            return RedirectToAction("Edit", "Home", new { Id = regulator.DeviceId });
        }
    }
}