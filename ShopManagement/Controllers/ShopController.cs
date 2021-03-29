using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopManagement.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult AddShop()
        {
            Utilities.User _UserUtility = new Utilities.User();
            List<Models.User> UsersList = _UserUtility.GetAllUsers();
            UsersList = UsersList.Where(x => x.Status == "active").ToList();
            return View(UsersList);
        }
        public ActionResult ViewAllShops()
        {
            Utilities.Shop _ShopUtility = new Utilities.Shop();
            List<Models.Shop> Shopslist = new List<Models.Shop>();
            Shopslist = _ShopUtility.GetAllShops();
            Shopslist = Shopslist.Select(x => {
                if (x.Status.ToLower() == "active")
                    x.Status = "card-success";
                else
                    x.Status = "card-danger";
                return x;
            }).ToList();
            return View(Shopslist);
        }
    }
}