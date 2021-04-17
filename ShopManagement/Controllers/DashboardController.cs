using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopManagement.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Dashboard()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Account");
            string ShopId = "";
            if(Session["IsAdmin"].ToString() != "1")
            {

            }
            Utilities.Slider _sliderUtility = new Utilities.Slider();
            List<Models.Slider> sliderslist = _sliderUtility.GetSliderInfoByShopId(ShopId);
            return View(sliderslist);
        }
    }
}