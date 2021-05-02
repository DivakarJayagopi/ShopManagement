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
            if(Session["IsAdmin"].ToString() == "0")
            {
                ShopId = Session["ShopId"].ToString();
            }
            else if (Session["IsAdmin"].ToString() == "2")
            {
                ShopId = Session["UserId"].ToString();
            }
            Utilities.Slider _sliderUtility = new Utilities.Slider();
            Utilities.Order _orderUtility = new Utilities.Order();
            List<Models.Slider> sliderslist = _sliderUtility.GetSliderInfoByShopId(ShopId);
            string Today = DateTime.Now.ToString("yyyy-MM-dd");
            string Tomorrow = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
            string _3Day = DateTime.Now.AddDays(2).ToString("yyyy-MM-dd");
            string _4Day = DateTime.Now.AddDays(3).ToString("yyyy-MM-dd");
            string _5Day = DateTime.Now.AddDays(4).ToString("yyyy-MM-dd");

            List<Models.Order> TodayCompletingOrders = _orderUtility.GetOrdersByCompletedDate(ShopId, Today);
            List<Models.Order> TomorrowCompletingOrders = _orderUtility.GetOrdersByCompletedDate(ShopId, Tomorrow);
            List<Models.Order> OrderCompletingIn3Days = _orderUtility.GetOrdersByCompletedDate(ShopId, _3Day);
            List<Models.Order> OrderCompletingIn4Days = _orderUtility.GetOrdersByCompletedDate(ShopId, _4Day);
            List<Models.Order> OrderCompletingIn5Days = _orderUtility.GetOrdersByCompletedDate(ShopId, _5Day);
            Models.DashBoardCustomClass dashBoardCustomClass = new Models.DashBoardCustomClass();
            dashBoardCustomClass.Sliders = sliderslist;
            dashBoardCustomClass.TodayCompletingOrders = TodayCompletingOrders;
            dashBoardCustomClass.TomorrowCompletingOrders = TomorrowCompletingOrders;
            dashBoardCustomClass.OrderCompletingIn3Days = OrderCompletingIn3Days;
            dashBoardCustomClass.OrderCompletingIn4Days = OrderCompletingIn4Days;
            dashBoardCustomClass.OrderCompletingIn5Days = OrderCompletingIn5Days;
            if (Session["IsAdmin"].ToString() == "1" || Session["IsAdmin"].ToString() == "2")
            {
                ViewBag.ShopName = "All Shop";
            }                
            else
            {
                Utilities.Shop _shopUtility = new Utilities.Shop();
                var ShopInfo = _shopUtility.GetShopById(ShopId);
                ViewBag.ShopName = ShopInfo.Name;
            }
            ViewBag.TodayOrderCount = TodayCompletingOrders.Count;
            ViewBag.TomorrowOrderCount = TomorrowCompletingOrders.Count;
            ViewBag._3DaysOrderCount = OrderCompletingIn3Days.Count;
            ViewBag._4DaysOrderCount = OrderCompletingIn4Days.Count;
            ViewBag._5DaysOrderCount = OrderCompletingIn5Days.Count;
            return View(dashBoardCustomClass);
        }
    }
}