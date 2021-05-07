using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopManagement.Controllers
{
    public class MethodController : Controller
    {
        Utilities.User _userData = new Utilities.User();
        Utilities.Shop _shopData = new Utilities.Shop();
        Utilities.Order _orderUtility = new Utilities.Order();
        Utilities.Slider _sliderUtility = new Utilities.Slider();

        public ActionResult ValidateUserLogin(string MobileNumber, string Password, bool IsRemember)
        {
            Dictionary<string, object> returnObject = new Dictionary<string, object>();
            try
            {
                var UserInfo = _userData.ValidateUserLogin(MobileNumber, Password);                
                if (UserInfo != null && !string.IsNullOrEmpty(UserInfo.Id))
                {
                    Session["UserId"] = UserInfo.Id;
                    Session["IsAdmin"] = UserInfo.IsAdmin;
                    Session["Name"] = UserInfo.Name;
                    Session["UserImage"] = UserInfo.Image;
                    returnObject.Add("userInfo", UserInfo);
                   

                    if(UserInfo.IsAdmin == 0)
                    {
                        Utilities.Shop _shopUtility = new Utilities.Shop();
                        var ShopInfo = _shopUtility.GetUserConnectedShopInfo(UserInfo.Id);
                        if (ShopInfo != null && !string.IsNullOrEmpty(ShopInfo.Id))
                        {
                            Session["ShopId"] = ShopInfo.Id;
                            Session["ShopName"] = ShopInfo.Name;
                            returnObject.Add("status", "success");
                        }
                        else
                        {
                            returnObject.Add("status", "fail");
                            returnObject.Add("errorMessage", "You are Not Connected any Shop, Contact Admin");
                        }
                    }
                    else
                    {
                        returnObject.Add("status", "success");
                    }

                    if (IsRemember)
                    {
                        HttpCookie cookie = new HttpCookie("Login");
                        cookie.Values.Add("MobileNumber", UserInfo.MobileNumber);
                        cookie.Values.Add("PWD", UserInfo.Password);
                        cookie.HttpOnly = true;
                        cookie.Expires = DateTime.Now.AddDays(30);
                        Response.Cookies.Add(cookie); 
                    }
                }
                else
                {
                    returnObject.Add("status", "fail");
                }
            }
            catch (Exception exe)
            {

            }
            return Json(new { message = returnObject }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LogOut()
        {
            Dictionary<string, object> returnObject = new Dictionary<string, object>();
            try
            {
                Response.Cookies["MobileNumber"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["Pwd"].Expires = DateTime.Now.AddDays(-1);
                returnObject.Add("status", "success");
            }
            catch (Exception)
            {

            }
            return Json(new { message = returnObject }, JsonRequestBehavior.AllowGet);
        }

        // GET: Method
        public ActionResult AddUserInfo(string Name, string EmailId, string Password, string Image, string Status, string Area, string Notes, string MobileNumber, int IsAdmin)
        {
            Dictionary<string, object> returnObject = new Dictionary<string, object>();
            try
            {
                bool Result = false;

                if (!string.IsNullOrEmpty(Image))
                {
                    string path = Server.MapPath("~" + Globals.Default_ProfileImagePath); //Path

                    //Check if directory exist
                    if (!System.IO.Directory.Exists(path))
                    {
                        System.IO.Directory.CreateDirectory(path); //Create directory if it doesn't exist
                    }

                    string imageName = Guid.NewGuid().ToString() + ".jpg";

                    //set the image path
                    string imgPath = Path.Combine(path, imageName);
                    var splitedValue = Image.Split(',');
                    var ReplaceValue = splitedValue[0] + ',';
                    Image = Image.Replace(ReplaceValue, "");
                    var imageBytes = Convert.FromBase64String(Image);

                    System.IO.File.WriteAllBytes(imgPath, imageBytes);
                    Image = Globals.Default_ProfileImagePath + "/" + imageName;
                }
                else
                {
                    Image = Globals.Default_ProfileImage;
                }
               
                Result = _userData.Add(Name, EmailId, Password, Image, Status, Area, Notes, MobileNumber, IsAdmin);
                if (Result == true)
                {
                    returnObject.Add("status", "success");
                }
                else
                {
                    returnObject.Add("status", "fail");
                }
            }
            catch (Exception exe)
            {

            }
            return Json(new { message = returnObject }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UpdateUserInfo(string Id,string Name, string EmailId, string Password, string Image, string Status, string Area, string Notes, string MobileNumber, int IsAdmin)
        {
            Dictionary<string, object> returnObject = new Dictionary<string, object>();
            try
            {
                bool Result = false;
                var UserInfo = _userData.GetUserById(Id);
                if (string.IsNullOrEmpty(Image))
                {
                    Image = UserInfo.Image;
                }
                else
                {
                    string path = Server.MapPath("~" + Globals.Default_ProfileImagePath); //Path

                    //Check if directory exist
                    if (!System.IO.Directory.Exists(path))
                    {
                        System.IO.Directory.CreateDirectory(path); //Create directory if it doesn't exist
                    }

                    string imageName = Guid.NewGuid().ToString() + ".jpg";

                    //set the image path
                    string imgPath = Path.Combine(path, imageName);
                    var splitedValue = Image.Split(',');
                    var ReplaceValue = splitedValue[0] + ',';
                    Image = Image.Replace(ReplaceValue, "");
                    var imageBytes = Convert.FromBase64String(Image);

                    System.IO.File.WriteAllBytes(imgPath, imageBytes);
                    Image = Globals.Default_ProfileImagePath + "/" + imageName;
                    string SessionUser = Session["UserId"].ToString();
                    if(Id == SessionUser)
                    {
                        Session["UserImage"] = Image;
                    }
                }
                Result = _userData.Update(Id, Name, EmailId, Password, Image, Status, Area, Notes, MobileNumber, IsAdmin);
                if (Result == true)
                {
                    UserInfo = _userData.GetUserById(Id);
                    returnObject.Add("userInfo", UserInfo);
                    returnObject.Add("status", "success");
                }
                else
                {
                    returnObject.Add("status", "fail");
                }
            }
            catch (Exception)
            {

            }
            return Json(new { message = returnObject }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UdpateUserProfileInfo(string Id, string Name, string EmailId, string Area, string Notes, string MobileNumber,string Image)
        {
            Dictionary<string, object> returnObject = new Dictionary<string, object>();
            try
            {
                bool Result = false;
                var UserInfo = _userData.GetUserById(Id);
                if (string.IsNullOrEmpty(Image))
                {
                    Image = UserInfo.Image;
                }
                else
                {
                    string path = Server.MapPath("~" + Globals.Default_ProfileImagePath); //Path

                    //Check if directory exist
                    if (!System.IO.Directory.Exists(path))
                    {
                        System.IO.Directory.CreateDirectory(path); //Create directory if it doesn't exist
                    }

                    string imageName = Guid.NewGuid().ToString() + ".jpg";

                    //set the image path
                    string imgPath = Path.Combine(path, imageName);
                    var splitedValue = Image.Split(',');
                    var ReplaceValue = splitedValue[0] + ',';
                    Image = Image.Replace(ReplaceValue, "");
                    var imageBytes = Convert.FromBase64String(Image);

                    System.IO.File.WriteAllBytes(imgPath, imageBytes);
                    Image = Globals.Default_ProfileImagePath + "/" + imageName;
                    Session["UserImage"] = Image;
                }
                Session["Name"] = Name;
                Result = _userData.Update(Id, Name, EmailId, UserInfo.Password, Image, UserInfo.Status, Area, Notes, MobileNumber, UserInfo.IsAdmin);
                if (Result == true)
                {
                    UserInfo = _userData.GetUserById(Id);
                    returnObject.Add("userInfo", UserInfo);
                    returnObject.Add("status", "success");
                }
                else
                {
                    returnObject.Add("status", "fail");
                }
            }
            catch (Exception)
            {

            }
            return Json(new { message = returnObject }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteUserById(string Id)
        {
            Dictionary<string, object> returnObject = new Dictionary<string, object>();
            try
            {
                bool Result = false;
                Result = _userData.Delete(Id);
                if (Result == true)
                {
                    returnObject.Add("status", "success");
                }
                else
                {
                    returnObject.Add("status", "fail");
                }
            }
            catch (Exception)
            {

            }
            return Json(new { message = returnObject }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetUserById(string Id)
        {
            Dictionary<string, object> returnObject = new Dictionary<string, object>();
            try
            {
                Models.User UserInfo = new Models.User();
                UserInfo = _userData.GetUserById(Id);
                if (UserInfo != null && !string.IsNullOrEmpty(UserInfo.Id))
                {
                    returnObject.Add("userInfo", UserInfo);
                    returnObject.Add("status", "success");
                }
                else
                {
                    returnObject.Add("status", "fail");
                }
            }
            catch (Exception)
            {

            }
            return Json(new { message = returnObject }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetUserInfoForExistsProperty(string UserName, string MobileNumber, string EMailId)
        {
            Dictionary<string, object> returnObject = new Dictionary<string, object>();
            try
            {
                
                bool IsUserInfoExist = _userData.GetUserInfoForExistsProperty(UserName, MobileNumber, EMailId);
                if (IsUserInfoExist)
                {
                    returnObject.Add("IsUserInfoExist", IsUserInfoExist);
                    returnObject.Add("status", "success");
                }
                else
                {
                    returnObject.Add("status", "fail");
                }
            }
            catch (Exception)
            {

            }
            return Json(new { message = returnObject }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllUsers()
        {
            Dictionary<string, object> returnObject = new Dictionary<string, object>();
            try
            {
                List<Models.User> usersList = new List<Models.User>();
                usersList = _userData.GetAllUsers();
                if (usersList != null)
                {
                    returnObject.Add("usersList", usersList);
                    returnObject.Add("status", "success");
                }
                else
                {
                    returnObject.Add("status", "fail");
                }
            }
            catch (Exception)
            {

            }
            return Json(new { message = returnObject }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllUsersByStatus(bool IsActive)
        {
            Dictionary<string, object> returnObject = new Dictionary<string, object>();
            try
            {
                List<Models.User> usersList = new List<Models.User>();
                usersList = _userData.GetAllUsersByStatus(IsActive);
                if (usersList != null)
                {
                    returnObject.Add("usersList", usersList);
                    returnObject.Add("status", "success");
                }
                else
                {
                    returnObject.Add("status", "fail");
                }
            }
            catch (Exception)
            {

            }
            return Json(new { message = returnObject }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddShopInfo(string Name, string ShopArea, string UserId, string Image, string Notes, string Status, string MobileNumber, int MaxOrderCount)
        {
            Dictionary<string, object> returnObject = new Dictionary<string, object>();
            try
            {
                bool Result = false;
                if (!string.IsNullOrEmpty(Image))
                {
                    string path = Server.MapPath("~" + Globals.Default_ShopImagePath); //Path

                    //Check if directory exist
                    if (!System.IO.Directory.Exists(path))
                    {
                        System.IO.Directory.CreateDirectory(path); //Create directory if it doesn't exist
                    }

                    string imageName = Guid.NewGuid().ToString() + ".jpg";

                    //set the image path
                    string imgPath = Path.Combine(path, imageName);
                    var splitedValue = Image.Split(',');
                    var ReplaceValue = splitedValue[0] + ',';
                    Image = Image.Replace(ReplaceValue, "");
                    var imageBytes = Convert.FromBase64String(Image);

                    System.IO.File.WriteAllBytes(imgPath, imageBytes);
                    Image = Globals.Default_ShopImagePath + "/" + imageName;
                }
                else
                {
                    Image = Globals.Default_shopImage;
                }
                Result = _shopData.Add(Name, ShopArea, UserId, Image, Notes, Status, MobileNumber, MaxOrderCount);
                if (Result == true)
                {
                    returnObject.Add("status", "success");
                }
                else
                {
                    returnObject.Add("status", "fail");
                }
            }
            catch (Exception)
            {

            }
            return Json(new { message = returnObject }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UpdateShopInfo(string Id, string Name, string ShopArea, string UserId, string Image, string Notes, string Status, string MobileNumber, int MaxOrderCount)
        {
            Dictionary<string, object> returnObject = new Dictionary<string, object>();
            try
            {
                bool Result = false;
                Utilities.Shop shopUtility = new Utilities.Shop();
                var ShopInfo = shopUtility.GetShopById(Id);
                if (string.IsNullOrEmpty(Image))
                {
                    Image = ShopInfo.Image;
                }
                else
                {
                    string path = Server.MapPath("~" + Globals.Default_ShopImagePath); //Path

                    //Check if directory exist
                    if (!System.IO.Directory.Exists(path))
                    {
                        System.IO.Directory.CreateDirectory(path); //Create directory if it doesn't exist
                    }

                    string imageName = Guid.NewGuid().ToString() + ".jpg";

                    //set the image path
                    string imgPath = Path.Combine(path, imageName);
                    var splitedValue = Image.Split(',');
                    var ReplaceValue = splitedValue[0] + ',';
                    Image = Image.Replace(ReplaceValue, "");
                    var imageBytes = Convert.FromBase64String(Image);

                    System.IO.File.WriteAllBytes(imgPath, imageBytes);
                    Image = Globals.Default_ShopImagePath + "/" + imageName;
                }
                Result = _shopData.Update(Id, Name, ShopArea, UserId, Image, Notes, Status, MobileNumber, MaxOrderCount);
                ShopInfo = shopUtility.GetShopById(Id);
                Utilities.User userUtility = new Utilities.User();
                var ShopConnectedUserInfo = userUtility.GetShopConnectedUserInfo(ShopInfo.Id);
                if (Result == true)
                {
                    returnObject.Add("ShopInfo", ShopInfo);
                    returnObject.Add("ShopConnectedUserInfo", ShopConnectedUserInfo);
                    returnObject.Add("status", "success");
                }
                else
                {
                    returnObject.Add("status", "fail");
                }
            }
            catch (Exception)
            {

            }
            return Json(new { message = returnObject }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteShopById(string Id)
        {
            Dictionary<string, object> returnObject = new Dictionary<string, object>();
            try
            {
                bool Result = false;
                Result = _shopData.Delete(Id);
                if (Result == true)
                {
                    returnObject.Add("status", "success");
                }
                else
                {
                    returnObject.Add("status", "fail");
                }
            }
            catch (Exception)
            {

            }
            return Json(new { message = returnObject }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetShopInfoById(string Id)
        {
            Dictionary<string, object> returnObject = new Dictionary<string, object>();
            try
            {
                Models.Shop shopInfo = new Models.Shop();
                shopInfo = _shopData.GetShopById(Id);
                Utilities.User userUtility = new Utilities.User();
                var UserInfo = userUtility.GetShopConnectedUserInfo(shopInfo.Id);
                if (shopInfo != null && !string.IsNullOrEmpty(shopInfo.Id))
                {
                    var usersList = _userData.GetAllUsersByStatus(true);
                    returnObject.Add("shopInfo", shopInfo);
                    returnObject.Add("ShopConnecteduserId", UserInfo.Id);
                    returnObject.Add("usersList", usersList);
                    returnObject.Add("status", "success");
                }
                else
                {
                    returnObject.Add("status", "fail");
                }
            }
            catch (Exception)
            {

            }
            return Json(new { message = returnObject }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllShops()
        {
            Dictionary<string, object> returnObject = new Dictionary<string, object>();
            try
            {
                List<Models.Shop> ShopsList = new List<Models.Shop>();
                ShopsList = _shopData.GetAllShops();
                if (ShopsList != null)
                {
                    returnObject.Add("ShopsList", ShopsList);
                    returnObject.Add("status", "success");
                }
                else
                {
                    returnObject.Add("status", "fail");
                }
            }
            catch (Exception)
            {

            }
            return Json(new { message = returnObject }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllShopsByStatus(bool IsActive)
        {
            Dictionary<string, object> returnObject = new Dictionary<string, object>();
            try
            {
                List<Models.Shop> shopsList = new List<Models.Shop>();
                shopsList = _shopData.GetAllShopsByStaus(IsActive);
                if (shopsList != null)
                {
                    returnObject.Add("ShopsList", shopsList);
                    returnObject.Add("status", "success");
                }
                else
                {
                    returnObject.Add("status", "fail");
                }
            }
            catch (Exception)
            {

            }
            return Json(new { message = returnObject }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetShopsCount()
        {
            Dictionary<string, object> returnObject = new Dictionary<string, object>();
            try
            {
                string Count = _shopData.GetShopsCount();
                if (!string.IsNullOrEmpty(Count))
                {
                    returnObject.Add("ShopsList", Count);
                    returnObject.Add("status", "success");
                }
                else
                {
                    returnObject.Add("status", "fail");
                }
            }
            catch (Exception)
            {

            }
            return Json(new { message = returnObject }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetShopCountByStaus(bool IsActive)
        {
            Dictionary<string, object> returnObject = new Dictionary<string, object>();
            try
            {
                string Count = _shopData.GetShopCountByStaus(IsActive);
                if (!string.IsNullOrEmpty(Count))
                {
                    returnObject.Add("usersList", Count);
                    returnObject.Add("status", "success");
                }
                else
                {
                    returnObject.Add("status", "fail");
                }
            }
            catch (Exception)
            {

            }
            return Json(new { message = returnObject }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddOrderInfo(string BillNumber,string CustomerName, string Image, string ShopId, int Amount, string CustomerMobileNumber, string Status, string Notes, string StartDate, string EndDate, Models.SafariInfo safariInfo, Models.PantInfo pantInfo, Models.ShirtInfo shirtInfo)
        {
            Dictionary<string, object> returnObject = new Dictionary<string, object>();
            try
            {
                bool Result = false;
                DateTime StartDateVal = DateTime.Parse(StartDate);
                DateTime EndDateVal = DateTime.Parse(EndDate);
                if (string.IsNullOrEmpty(Image))
                {
                    Image = Globals.Default_orderImage;
                }
                else
                {
                    string path = Server.MapPath("~" + Globals.Default_OrderImagePath); //Path

                    //Check if directory exist
                    if (!System.IO.Directory.Exists(path))
                    {
                        System.IO.Directory.CreateDirectory(path); //Create directory if it doesn't exist
                    }

                    string imageName = Guid.NewGuid().ToString() + ".jpg";

                    //set the image path
                    string imgPath = Path.Combine(path, imageName);
                    var splitedValue = Image.Split(',');
                    var ReplaceValue = splitedValue[0] + ',';
                    Image = Image.Replace(ReplaceValue, "");
                    var imageBytes = Convert.FromBase64String(Image);

                    System.IO.File.WriteAllBytes(imgPath, imageBytes);
                    Image = Globals.Default_OrderImagePath + "/" + imageName;
                }
                Result = _orderUtility.Add(BillNumber, CustomerName, Image, ShopId, Amount, CustomerMobileNumber, Status, Notes, StartDateVal, EndDateVal, safariInfo, pantInfo, shirtInfo);
                if (Result == true)
                {

                    returnObject.Add("status", "success");
                }
                else
                {
                    returnObject.Add("status", "fail");
                }
            }
            catch (Exception)
            {

            }
            return Json(new { message = returnObject }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UpdateOrderInfo(string Id,string BillNumber, string CustomerName, string Image, string ShopId, int Amount, string CustomerMobileNumber, string Status, string Notes, string StartDate, string EndDate, Models.SafariInfo safariInfo, Models.PantInfo pantInfo, Models.ShirtInfo shirtInfo)
        {
            Dictionary<string, object> returnObject = new Dictionary<string, object>();
            try
            {
                bool Result = false;
                DateTime StartDateVal = DateTime.Parse(StartDate);
                DateTime EndDateVal = DateTime.Parse(EndDate);
                var OrderInfo = _orderUtility.GetOrderInfoById(Id);
                if (string.IsNullOrEmpty(Image))
                {
                    Image = OrderInfo.Image;
                }
                else
                {
                    string path = Server.MapPath("~" + Globals.Default_OrderImagePath); //Path

                    //Check if directory exist
                    if (!System.IO.Directory.Exists(path))
                    {
                        System.IO.Directory.CreateDirectory(path); //Create directory if it doesn't exist
                    }

                    string imageName = Guid.NewGuid().ToString() + ".jpg";

                    //set the image path
                    string imgPath = Path.Combine(path, imageName);
                    var splitedValue = Image.Split(',');
                    var ReplaceValue = splitedValue[0] + ',';
                    Image = Image.Replace(ReplaceValue, "");
                    var imageBytes = Convert.FromBase64String(Image);

                    System.IO.File.WriteAllBytes(imgPath, imageBytes);
                    Image = Globals.Default_OrderImagePath + "/" + imageName;
                }
                Result = _orderUtility.Update(Id, BillNumber, CustomerName, Image, ShopId, Amount, CustomerMobileNumber, Status, Notes, StartDateVal, EndDateVal, safariInfo, pantInfo, shirtInfo);
                if (Result == true)
                {
                    returnObject.Add("status", "success");
                }
                else
                {
                    returnObject.Add("status", "fail");
                }
            }
            catch (Exception)
            {

            }
            return Json(new { message = returnObject }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteOrderById(string Id)
        {
            Dictionary<string, object> returnObject = new Dictionary<string, object>();
            try
            {
                bool Result = false;
                Result = _orderUtility.Delete(Id);
                if (Result == true)
                {
                    returnObject.Add("status", "success");
                }
                else
                {
                    returnObject.Add("status", "fail");
                }
            }
            catch (Exception)
            {

            }
            return Json(new { message = returnObject }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetOrderInfoById(string Id)
        {
            Dictionary<string, object> returnObject = new Dictionary<string, object>();
            try
            {
                Models.Order orderInfo = new Models.Order();
                orderInfo = _orderUtility.GetOrderInfoById(Id);
                if (orderInfo != null && !string.IsNullOrEmpty(orderInfo.Id))
                {
                    returnObject.Add("orderInfo", orderInfo);
                    returnObject.Add("status", "success");
                }
                else
                {
                    returnObject.Add("status", "fail");
                }
            }
            catch (Exception)
            {

            }
            return Json(new { message = returnObject }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllOrders()
        {
            Dictionary<string, object> returnObject = new Dictionary<string, object>();
            try
            {
                List<Models.Order> OrderList = new List<Models.Order>();
                OrderList = _orderUtility.GetAllOrders();
                if (OrderList != null)
                {
                    returnObject.Add("OrderList", OrderList);
                    returnObject.Add("status", "success");
                }
                else
                {
                    returnObject.Add("status", "fail");
                }
            }
            catch (Exception)
            {

            }
            return Json(new { message = returnObject }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllOrdersByShopId(string ShopId)
        {
            Dictionary<string, object> returnObject = new Dictionary<string, object>();
            try
            {
                List<Models.Order> OrderList = new List<Models.Order>();
                OrderList = _orderUtility.GetAllOrdersByShopId(ShopId);
                if (OrderList != null)
                {
                    returnObject.Add("OrderList", OrderList);
                    returnObject.Add("status", "success");
                }
                else
                {
                    returnObject.Add("status", "fail");
                }
            }
            catch (Exception)
            {

            }
            return Json(new { message = returnObject }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllOrdersByStatus(string Status)
        {
            Dictionary<string, object> returnObject = new Dictionary<string, object>();
            try
            {
                List<Models.Order> OrderList = new List<Models.Order>();
                OrderList = _orderUtility.GetAllOrdersByStatus(Status);
                if (OrderList != null)
                {
                    returnObject.Add("OrderList", OrderList);
                    returnObject.Add("status", "success");
                }
                else
                {
                    returnObject.Add("status", "fail");
                }
            }
            catch (Exception)
            {

            }
            return Json(new { message = returnObject }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllOrdersDates(string ShopId, string FilterDate)
        {
            Dictionary<string, object> returnObject = new Dictionary<string, object>();
            try
            {
                List<Models.Order> OrderList = new List<Models.Order>();
                OrderList = _orderUtility.GetAllOrdersDates(ShopId, FilterDate);
                if (OrderList != null)
                {
                    if (!string.IsNullOrEmpty(ShopId))
                    {
                        int awaitingOrdersCount = OrderList.Where(x => x.Status == "awaiting").ToList().Count;
                        int inprogressOrdersCount = OrderList.Where(x => x.Status == "inprogress").ToList().Count;
                        int completedOrdersCount = OrderList.Where(x => x.Status == "completed").ToList().Count;
                        int droppedOrdersCount = OrderList.Where(x => x.Status == "dropped").ToList().Count;

                        List<int> _totalAmount = OrderList.Select(x => x.Amount).ToList();
                        int TotalAmout = 0;

                        if (_totalAmount != null && _totalAmount.Count > 0)
                        {
                            TotalAmout = _totalAmount.Take(_totalAmount.Count).Sum();
                        }

                        List<int> _receivedAmount = OrderList.Where(x => x.Status == "completed").Select(x => x.Amount).ToList();
                        int ReceivedAmout = 0;

                        if (_receivedAmount != null && _receivedAmount.Count > 0)
                        {
                            ReceivedAmout = _receivedAmount.Take(_receivedAmount.Count).Sum();
                        }

                        

                        returnObject.Add("awaitingOrdersCount", awaitingOrdersCount);
                        returnObject.Add("inprogressOrdersCount", inprogressOrdersCount);
                        returnObject.Add("completedOrdersCount", completedOrdersCount);
                        returnObject.Add("droppedOrdersCount", droppedOrdersCount);

                        returnObject.Add("TotalAmount", TotalAmout);
                        returnObject.Add("ReceivedAmount", ReceivedAmout);
                        returnObject.Add("BalanceAmount", TotalAmout - ReceivedAmout);
                    }
                    else
                    {
                        Utilities.Shop shopUtility = new Utilities.Shop();
                        var ShopsList = shopUtility.GetAllShopsByStaus(true);

                        if(ShopsList != null && ShopsList.Count > 0)
                        {
                            List<Models.ShopInfoForChart> shopInfoForChartsList = new List<Models.ShopInfoForChart>();
                            foreach(var Shop in ShopsList)
                            {
                                var SingleShopOrderList = _orderUtility.GetAllOrdersDates(Shop.Id, FilterDate);

                                int awaitingOrdersCount = SingleShopOrderList.Where(x => x.Status == "awaiting").ToList().Count;
                                int inprogressOrdersCount = SingleShopOrderList.Where(x => x.Status == "inprogress").ToList().Count;
                                int completedOrdersCount = SingleShopOrderList.Where(x => x.Status == "completed").ToList().Count;
                                int droppedOrdersCount = SingleShopOrderList.Where(x => x.Status == "dropped").ToList().Count;

                                List<int> _totalAmount = SingleShopOrderList.Select(x => x.Amount).ToList();
                                int TotalAmout = 0;

                                if (_totalAmount != null && _totalAmount.Count > 0)
                                {
                                    TotalAmout = _totalAmount.Take(_totalAmount.Count).Sum();
                                }

                                List<int> _receivedAmount = SingleShopOrderList.Where(x => x.Status == "completed").Select(x => x.Amount).ToList();
                                int ReceivedAmout = 0;

                                if (_receivedAmount != null && _receivedAmount.Count > 0)
                                {
                                    ReceivedAmout = _receivedAmount.Take(_receivedAmount.Count).Sum();
                                }

                                Models.ShopInfoForChart shopInfoForChart = new Models.ShopInfoForChart()
                                {
                                    Id = Shop.Id,
                                    Name = Shop.Name,

                                    TotalOrdersCount = SingleShopOrderList.Count,
                                    AwaitingOrdersCount = awaitingOrdersCount,
                                    InprogressOrdersCount = inprogressOrdersCount,
                                    CompletedOrdersCount = completedOrdersCount,
                                    DroppedOrdersCount = droppedOrdersCount,

                                    TotalAmount = TotalAmout,
                                    ReceivedAmount = ReceivedAmout,
                                    BalanceAmount = TotalAmout - ReceivedAmout
                                };
                                shopInfoForChartsList.Add(shopInfoForChart);
                                
                            }
                            returnObject.Add("ShopInfoForChartsList", shopInfoForChartsList);
                        }
                    }
                    returnObject.Add("OrderList", OrderList);
                    returnObject.Add("status", "success");
                }
                else
                {
                    returnObject.Add("status", "fail");
                }
            }
            catch (Exception exe)
            {

            }
            return Json(new { message = returnObject }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddSliderInfo(string Name, string ShopId)
        {
            Dictionary<string, object> returnObject = new Dictionary<string, object>();
            try
            {
                bool Result = false;
                Result = _sliderUtility.Add(Name, ShopId);
                if (Result == true)
                {
                    returnObject.Add("status", "success");
                }
                else
                {
                    returnObject.Add("status", "fail");
                }
            }
            catch (Exception)
            {

            }
            return Json(new { message = returnObject }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UpdateSliderInfo(string Id, List<string> ImageIds)
        {
            Dictionary<string, object> returnObject = new Dictionary<string, object>();
            try
            {
                bool Result = false;                
                Result = _sliderUtility.Update(Id, ImageIds);
                if (Result == true)
                {
                    returnObject.Add("status", "success");
                }
                else
                {
                    returnObject.Add("status", "fail");
                }
            }
            catch (Exception)
            {

            }
            return Json(new { message = returnObject }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddImage(string Images, string QualityType)
        {
            Dictionary<string, object> returnObject = new Dictionary<string, object>();
            try
            {
                bool Result = false;

                string path = string.Empty;
                switch (QualityType.ToLower())
                {
                    case "high":
                        path = Server.MapPath("~" + Globals.Default_GalleryPath_High); //Path
                        break;
                    case "low":
                        path = Server.MapPath("~" + Globals.Default_GalleryPath_Low); //Path
                        break;
                    case "medium":
                        path = Server.MapPath("~" + Globals.Default_GalleryPath_Medium); //Path
                        break;
                }
                //Check if directory exist
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path); //Create directory if it doesn't exist
                }


                string imageName = Guid.NewGuid().ToString() + ".jpg";
                string _image = Images;
                //set the image path
                string imgPath = Path.Combine(path, imageName);
                var splitedValue = _image.Split(',');
                var ReplaceValue = splitedValue[0] + ',';
                _image = _image.Replace(ReplaceValue, "");
                var imageBytes = Convert.FromBase64String(_image);

                System.IO.File.WriteAllBytes(imgPath, imageBytes);
                _image = Globals.Default_GalleryPath_High + "/" + imageName;
                switch (QualityType.ToLower())
                {
                    case "high":
                        _image = Globals.Default_GalleryPath_High + "/" + imageName; //Path
                        break;
                    case "low":
                        _image = Globals.Default_GalleryPath_Low + "/" + imageName; //Path
                        break;
                    case "medium":
                        _image = Globals.Default_GalleryPath_Medium + "/" + imageName; //Path
                        break;
                }
                Result = _sliderUtility.AddImages(_image,QualityType);
                if (Result == true)
                {
                    returnObject.Add("status", "success");
                }
                else
                {
                    returnObject.Add("status", "fail");
                }
            }
            catch (Exception)
            {

            }
            return Json(new { message = returnObject }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteImages(string ImageIds)
        {
            Dictionary<string, object> returnObject = new Dictionary<string, object>();
            try
            {
                bool Result = false;
                var ids = ImageIds.Split(',');
                Result = _sliderUtility.DeleteImages(ids);
                if (Result == true)
                {
                    returnObject.Add("status", "success");
                }
                else
                {
                    returnObject.Add("status", "fail");
                }
            }
            catch (Exception)
            {

            }
            return Json(new { message = returnObject }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllImages()
        {
            Dictionary<string, object> returnObject = new Dictionary<string, object>();
            try
            {
                var Images = _sliderUtility.GetAllImages();
                if (Images != null)
                {
                    returnObject.Add("Images", Images);
                    returnObject.Add("status", "success");
                }
                else
                {
                    returnObject.Add("status", "fail");
                }
            }
            catch (Exception)
            {

            }
            return Json(new { message = returnObject }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllImagesByShopId(string ShopId)
        {
            Dictionary<string, object> returnObject = new Dictionary<string, object>();
            try
            {
                var Images = _sliderUtility.GetAllImagesByShopId(ShopId);
                if (Images != null)
                {
                    returnObject.Add("Images", Images);
                    returnObject.Add("status", "success");
                }
                else
                {
                    returnObject.Add("status", "fail");
                }
            }
            catch (Exception)
            {

            }
            return Json(new { message = returnObject }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetSliderInfoByShopId(string ShopId)
        {
            Dictionary<string, object> returnObject = new Dictionary<string, object>();
            try
            {
                var sliderslist = _sliderUtility.GetSliderInfoByShopId(ShopId);
                if (sliderslist != null)
                {
                    returnObject.Add("sliderslist", sliderslist);
                    returnObject.Add("status", "success");
                }
                else
                {
                    returnObject.Add("status", "fail");
                }
            }
            catch (Exception)
            {

            }
            return Json(new { message = returnObject }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ValidateOldPassword(string UserPassword)
        {
            Dictionary<string, object> returnObject = new Dictionary<string, object>();
            try
            {
                string UserId = Session["UserId"].ToString();
                var UserInfo = _userData.GetUserById(UserId); ;
                if (UserInfo != null && !string.IsNullOrEmpty(UserInfo.Id) && UserInfo.Password == UserPassword)
                {
                    returnObject.Add("status", "success");
                }
                else
                {
                    returnObject.Add("status", "fail");
                }
            }
            catch (Exception)
            {

            }
            return Json(new { message = returnObject }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdateUserPassword(string UserPassword)
        {
            Dictionary<string, object> returnObject = new Dictionary<string, object>();
            try
            {
                string UserId = Session["UserId"].ToString();
                if (!string.IsNullOrEmpty(UserId))
                {
                    var UpdatedStaus = _userData.UpdateUserPassword(UserId,UserPassword);
                    if (UpdatedStaus)
                    {
                        if (Request.Cookies["Pwd"] != null)
                        {
                            Response.Cookies["Pwd"].Value = UserPassword;
                        }
                        returnObject.Add("status", "success");
                    }
                }
                else
                {
                    returnObject.Add("status", "fail");
                }
            }
            catch (Exception)
            {

            }
            return Json(new { message = returnObject }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ForgotPassowrd(string MobileNumber)
        {
            Dictionary<string, object> returnObject = new Dictionary<string, object>();
            try
            {
                var UserInfo = _userData.GetUserByMobileNumber(MobileNumber);
                if (UserInfo != null && !string.IsNullOrEmpty(UserInfo.Id))
                {
                    string Message = "Hi " + UserInfo.Name + ", Your Password for Fb Designer Emporium is " + UserInfo.Password;
                    string SendSMS = _orderUtility.sendSMS(UserInfo.MobileNumber, Message);
                    returnObject.Add("status", "success");
                }
                else
                {
                    returnObject.Add("status", "fail");
                }
            }
            catch (Exception)
            {

            }
            return Json(new { message = returnObject }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult IsMobileNmberExists(string MobileNumber)
        {
            Dictionary<string, object> returnObject = new Dictionary<string, object>();
            try
            {
                var UserInfo = _userData.GetUserByMobileNumber(MobileNumber);
                if (UserInfo != null && !string.IsNullOrEmpty(UserInfo.Id))
                {
                    returnObject.Add("IsExist", true);
                    returnObject.Add("status", "success");
                }
                else
                {
                    returnObject.Add("IsExist", false);
                    returnObject.Add("status", "success");
                }
            }
            catch (Exception)
            {
                returnObject.Add("status", "fail");
            }
            return Json(new { message = returnObject }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult IsBillNumberExists(string BillNumber)
        {
            Dictionary<string, object> returnObject = new Dictionary<string, object>();
            try
            {
                var OrderInfo = _orderUtility.GetOrderByBillNumber(BillNumber);
                if (OrderInfo != null && !string.IsNullOrEmpty(OrderInfo.Id))
                {
                    returnObject.Add("IsExist", true);
                    returnObject.Add("status", "success");
                }
                else
                {
                    returnObject.Add("IsExist", false);
                    returnObject.Add("status", "success");
                }
            }
            catch (Exception)
            {
                returnObject.Add("status", "fail");
            }
            return Json(new { message = returnObject }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetShopConnectedUsersList(string ShopId)
        {
            Dictionary<string, object> returnObject = new Dictionary<string, object>();
            try
            {
                var UsersList = _userData.GetShopConnectedUserList(ShopId);
                if (UsersList != null && UsersList.Count > 0)
                {
                    returnObject.Add("UsersList", UsersList);
                }
                returnObject.Add("status", "success");
            }
            catch (Exception)
            {
                returnObject.Add("status", "fail");
            }
            return Json(new { message = returnObject }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteUserConnectorByUserAndShopId(string ShopId, string UserId)
        {
            Dictionary<string, object> returnObject = new Dictionary<string, object>();
            try
            {
                var result = _shopData.DeleteUserConnectorByUserAndShopId(ShopId, UserId);
                if (result)
                {
                    returnObject.Add("status", "success");
                }
                else
                {
                    returnObject.Add("status", "fail");
                }                
            }
            catch (Exception)
            {
                returnObject.Add("status", "fail");
            }
            return Json(new { message = returnObject }, JsonRequestBehavior.AllowGet);
        }
    }
}