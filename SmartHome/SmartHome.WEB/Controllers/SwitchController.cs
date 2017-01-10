using SmartHome.Services;
using SmartHome.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartHome.WEB.Controllers
{
    public class SwitchController : Controller
    {
        private DeviceService deviceService;

        public SwitchController()
        {
            deviceService = new DeviceService();
        }

        [HttpPost]
        public ActionResult Edit(SwitchDTO component)
        {
            deviceService.Update(component);

            return RedirectToAction("Edit", "Home", new { Id = component.DeviceId } );
        }     
    }
}