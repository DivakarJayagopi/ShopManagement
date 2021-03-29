using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopManagement.Controllers
{
    public class SliderController : Controller
    {
        // GET: Slider
        public ActionResult SliderSettings()
        {
            return View();
        }

        public ActionResult AddImage()
        {
            return View();
        }

        public ActionResult Gallery()
        {
            return View();
        }
    }
}