using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopManagement.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        DataTable dt = new DataTable();
        public ActionResult AddUser()
        {
            if (Session["UserId"] == null || Session["IsAdmin"].ToString() == "1")
                return RedirectToAction("Login", "Account");
            return View();
        }

        public ActionResult viewAllUser()
        {
            if (Session["UserId"] == null || Session["IsAdmin"].ToString() == "1")
                return RedirectToAction("Login", "Account");
            Utilities.User _UserUtility = new Utilities.User();
            Utilities.Shop _ShopUtility = new Utilities.Shop();

            List<Models.User> UsersList = _UserUtility.GetAllUsers();
            List<Models.UserAdditionalInfo> UserAdditionalInfoList = new List<Models.UserAdditionalInfo>();

            foreach(Models.User user in UsersList)
            {
                Models.UserAdditionalInfo userAdditionalInfo = new Models.UserAdditionalInfo();
                userAdditionalInfo.Id = user.Id;
                userAdditionalInfo.Name = user.Name;
                userAdditionalInfo.EmailId = user.EmailId;
                userAdditionalInfo.Password = user.Password;
                userAdditionalInfo.Image = user.Image;
                if(user.Status == "active")
                {
                    userAdditionalInfo.Status = "card-success";
                }
                else
                {
                    userAdditionalInfo.Status = "card-danger";
                }
                userAdditionalInfo.Area = user.Area;
                userAdditionalInfo.Notes = user.Notes;
                userAdditionalInfo.CreatedDate = user.CreatedDate;
                userAdditionalInfo.ModifiedDate = user.ModifiedDate;
                userAdditionalInfo.MobileNumber = user.MobileNumber;
                userAdditionalInfo.IsAdmin = user.IsAdmin;
                userAdditionalInfo.ShopInfo = _ShopUtility.GetUserConnectedShopInfo(user.Id);
                UserAdditionalInfoList.Add(userAdditionalInfo);
            }
            return View(UserAdditionalInfoList);
        }
    }
}