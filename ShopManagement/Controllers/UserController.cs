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
            return View();
        }

        public ActionResult viewAllUser()
        {
            Utilities.User _UserUtility = new Utilities.User();
            List<Models.User> UsersList = _UserUtility.GetAllUsers();
            UsersList = UsersList.Select(x =>{
                if (x.Status.ToLower() == "active")
                    x.Status = "card-success";
                else
                    x.Status = "card-danger";
                return x;
            }).ToList();
            return View(UsersList);
        }
    }
}