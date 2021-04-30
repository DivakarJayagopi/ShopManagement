using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopManagement.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            try
            {
                Session.Abandon();
            }
            catch (Exception)
            {

            }
            return View();
        }

        public ActionResult UserProfile()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Account");
            Utilities.User userUtility = new Utilities.User();
            string UserId = Session["UserId"].ToString();
            var UserInfo = userUtility.GetUserById(UserId);
            return View(UserInfo);
        }

        public ActionResult ChangePassword()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Account");
            return View();
        }

        public ActionResult ResetPassword()
        {            
            return View();
        }
    }
}