using SmartHome.Services;
using SmartHome.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartHome.WEB.Controllers
{
    public class HomeController : Controller
    {
        private DeviceService deviceService;

        public HomeController()
        {
            deviceService = new DeviceService();
        }

        public ActionResult Index()
        {                  
            return View(deviceService.GetBaseDevices());
        }

        public ActionResult Edit(int? id)
        {
            DeviceDTO device = deviceService.Get((int)id);
            return View(device);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}