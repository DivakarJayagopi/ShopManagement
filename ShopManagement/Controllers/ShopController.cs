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
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Account");
            else if (Session["IsAdmin"].ToString() != "1")
                return RedirectToAction("Dashboard", "Dashboard");

            Utilities.User _UserUtility = new Utilities.User();
            List<Models.User> UsersList = _UserUtility.GetAllUsers();
            UsersList = UsersList.Where(x => x.Status == "active").ToList();
            return View(UsersList);
        }
        public ActionResult ViewAllShops()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Account");
            else if (Session["IsAdmin"].ToString() != "1")
                return RedirectToAction("Dashboard", "Dashboard");

            Utilities.Shop _ShopUtility = new Utilities.Shop();
            List<Models.Shop> Shopslist = new List<Models.Shop>();
            Utilities.User _UserUtility = new Utilities.User();
            List<Models.ShopAdditionalInfo> ShopAdditionalInfoList = new List<Models.ShopAdditionalInfo>();
            Shopslist = _ShopUtility.GetAllShops();

            foreach (Models.Shop shop in Shopslist)
            {
                Models.ShopAdditionalInfo shopAdditionalInfo = new Models.ShopAdditionalInfo();
                shopAdditionalInfo.Id = shop.Id;
                shopAdditionalInfo.Name = shop.Name;
                shopAdditionalInfo.ShopArea = shop.ShopArea;
                shopAdditionalInfo.Image = shop.Image;
                shopAdditionalInfo.Notes = shop.Notes;
                if (shop.Status == "active")
                {
                    shopAdditionalInfo.Status = "card-success";
                }
                else
                {
                    shopAdditionalInfo.Status = "card-danger";
                }
                shopAdditionalInfo.CreatedDate = shop.CreatedDate;
                shopAdditionalInfo.ModifiedDate = shop.ModifiedDate;
                shopAdditionalInfo.MobileNumber = shop.MobileNumber;
                shopAdditionalInfo.MaxOrderCount = shop.MaxOrderCount;
                shopAdditionalInfo.TodaysOderCount = shop.TodaysOderCount;
                shopAdditionalInfo.UserInfo = _UserUtility.GetShopConnectedUserInfo(shop.Id);
                ShopAdditionalInfoList.Add(shopAdditionalInfo);
            }
            return View(ShopAdditionalInfoList);
        }
    }
}