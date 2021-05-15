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
            string UserId = "";
            if (Session["IsAdmin"].ToString() != "1")
            {
                UserId = Session["UserId"].ToString();
            }
            Utilities.Slider _sliderUtility = new Utilities.Slider();
            Utilities.Order _orderUtility = new Utilities.Order();
            List<Models.Slider> sliderslist = _sliderUtility.GetSliderInfoByShopId(UserId);
            string Today = DateTime.Now.ToString("yyyy-MM-dd");
            string Tomorrow = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
            string _3Day = DateTime.Now.AddDays(2).ToString("yyyy-MM-dd");
            string _4Day = DateTime.Now.AddDays(3).ToString("yyyy-MM-dd");
            string _5Day = DateTime.Now.AddDays(4).ToString("yyyy-MM-dd");

            List<string> Shopids = null;
            if (Session["IsAdmin"].ToString() == "0")
            {
                Utilities.Shop _ShopUtility = new Utilities.Shop();
                List<Models.Shop> Shopslist = new List<Models.Shop>();
                Shopslist = _ShopUtility.GetUserConnectedShopsList(UserId);
                Shopids = Shopslist.Select(x => x.Id).ToList();
            }

            List<Models.Order> TodayCompletingOrders = _orderUtility.GetOrdersByCompletedDate(Shopids, Today);
            List<Models.Order> TomorrowCompletingOrders = _orderUtility.GetOrdersByCompletedDate(Shopids, Tomorrow);
            List<Models.Order> OrderCompletingIn3Days = _orderUtility.GetOrdersByCompletedDate(Shopids, _3Day);
            List<Models.Order> OrderCompletingIn4Days = _orderUtility.GetOrdersByCompletedDate(Shopids, _4Day);
            List<Models.Order> OrderCompletingIn5Days = _orderUtility.GetOrdersByCompletedDate(Shopids, _5Day);
            Models.DashBoardCustomClass dashBoardCustomClass = new Models.DashBoardCustomClass();
            dashBoardCustomClass.Sliders = sliderslist;
            dashBoardCustomClass.TodayCompletingOrders = TodayCompletingOrders;
            dashBoardCustomClass.TomorrowCompletingOrders = TomorrowCompletingOrders;
            dashBoardCustomClass.OrderCompletingIn3Days = OrderCompletingIn3Days;
            dashBoardCustomClass.OrderCompletingIn4Days = OrderCompletingIn4Days;
            dashBoardCustomClass.OrderCompletingIn5Days = OrderCompletingIn5Days;
            ViewBag.TodayOrderCount = TodayCompletingOrders.Count;
            ViewBag.TomorrowOrderCount = TomorrowCompletingOrders.Count;
            ViewBag._3DaysOrderCount = OrderCompletingIn3Days.Count;
            ViewBag._4DaysOrderCount = OrderCompletingIn4Days.Count;
            ViewBag._5DaysOrderCount = OrderCompletingIn5Days.Count;
            return View(dashBoardCustomClass);
        }
    }
}