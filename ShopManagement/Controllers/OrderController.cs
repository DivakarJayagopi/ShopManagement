using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopManagement.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult AddOrder()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Account");
            Utilities.Shop _ShopUtility = new Utilities.Shop();
            List<Models.Shop> Shopslist = new List<Models.Shop>();
            if (Session["IsAdmin"].ToString() == "1")
            {
                Shopslist = _ShopUtility.GetAllShops();
            }
            else
            {
                string UserId = Session["UserId"].ToString();
                Shopslist = _ShopUtility.GetUserConnectedShopsList(UserId);
            }
            
            return View(Shopslist);
        }

        public ActionResult ViewOrders()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Account");
            Utilities.Order _orderUtility = new Utilities.Order();
            List<Models.Order> OrdersList = new List<Models.Order>();
            if(Session["IsAdmin"].ToString() == "1" || Session["IsAdmin"].ToString() == "2")
            {
                OrdersList = _orderUtility.GetAllOrders();
            }
            else
            {
                Utilities.Shop _ShopUtility = new Utilities.Shop();
                string UserId = Session["UserId"].ToString();
                var Shopslist = _ShopUtility.GetUserConnectedShopsList(UserId);
                var ShopIds = Shopslist.Select(x => x.Id).ToList();
                OrdersList = _orderUtility.GetAllOrdersByShopIds(ShopIds);
            }
            return View(OrdersList);
        }

        public ActionResult OrdersManagement()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Account");
            else if(Session["IsAdmin"].ToString() == "2")
                return RedirectToAction("Dashboard", "Dashboard");


            Utilities.Shop _ShopUtility = new Utilities.Shop();
            List<Models.Shop> Shopslist = new List<Models.Shop>();
            if (Session["IsAdmin"].ToString() == "1")
            {
                Shopslist = _ShopUtility.GetAllShops();
            }
            else
            {
                string UserId = Session["UserId"].ToString();
                Shopslist = _ShopUtility.GetUserConnectedShopsList(UserId);
            }
            return View(Shopslist);
        }
    }
}