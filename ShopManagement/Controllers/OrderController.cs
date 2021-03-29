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
            return View();
        }

        public ActionResult ViewOrders()
        {
            return View();
        }

        public ActionResult OrdersManagement()
        {
            return View();
        }
    }
}