﻿using System;
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
            Shopslist = _ShopUtility.GetAllShops();
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
                var ShopId = Session["ShopId"].ToString();
                OrdersList = _orderUtility.GetAllOrdersByShopId(ShopId);
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
            Shopslist = _ShopUtility.GetAllShops();
            return View(Shopslist);
        }
    }
}