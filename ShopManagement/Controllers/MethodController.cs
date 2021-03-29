﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace ShopManagement.Controllers
{
    public class MethodController : Controller
    {
        Utilities.User _userData = new Utilities.User();
        Utilities.Shop _shopData = new Utilities.Shop();
        Utilities.Order _orderUtility = new Utilities.Order();
        Utilities.Slider _sliderUtility = new Utilities.Slider();
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
                    Image = Globals.Default_ProfileImagePath + imageName;
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
                    Image = Globals.Default_ProfileImagePath + imageName;
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
        public ActionResult UpdateShopInfo(string Id, string Name, string ShopArea, string EmployeeName, string Image, string Notes, string Status, string MobileNumber, int MaxOrderCount)
        {
            Dictionary<string, object> returnObject = new Dictionary<string, object>();
            try
            {
                bool Result = false;
                Result = _shopData.Update(Id, Name, ShopArea, EmployeeName, Image, Notes, Status, MobileNumber, MaxOrderCount);
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
                if (shopInfo != null && !string.IsNullOrEmpty(shopInfo.Id))
                {
                    returnObject.Add("shop", shopInfo);
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
                    returnObject.Add("usersList", shopsList);
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
        public ActionResult AddOrderInfo(string CustomerName, string Image, string ShopId, int Amount, int CustomerMobileNumber, string Status, string Notes, DateTime StartDate, DateTime EndDate)
        {
            Dictionary<string, object> returnObject = new Dictionary<string, object>();
            try
            {
                bool Result = false;
                Result = _orderUtility.Add(CustomerName, Image, ShopId, Amount, CustomerMobileNumber, Status, Notes, StartDate, EndDate);
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
        public ActionResult UpdateOrderInfo(string Id, string CustomerName, string Image, string ShopId, int Amount, int CustomerMobileNumber, string Status, string Notes, DateTime StartDate, DateTime EndDate)
        {
            Dictionary<string, object> returnObject = new Dictionary<string, object>();
            try
            {
                bool Result = false;
                Result = _orderUtility.Update(Id, CustomerName, Image, ShopId, Amount, CustomerMobileNumber, Status, Notes, StartDate, EndDate);
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
        public ActionResult UpdateSliderInfo(string Id, string Name, List<string> ImageIds)
        {
            Dictionary<string, object> returnObject = new Dictionary<string, object>();
            try
            {
                bool Result = false;
                Result = _sliderUtility.Update(Id, Name, ImageIds);
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
        public ActionResult AddImage(string Id, string Image, string ShopId)
        {
            Dictionary<string, object> returnObject = new Dictionary<string, object>();
            try
            {
                bool Result = false;
                Result = _sliderUtility.AddImages(Id, Image, ShopId);
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
        public ActionResult DeleteImages(List<string> ImageIds, string ShopId)
        {
            Dictionary<string, object> returnObject = new Dictionary<string, object>();
            try
            {
                bool Result = false;
                Result = _sliderUtility.DeleteImages(ImageIds, ShopId);
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
                var Images = _sliderUtility.GetSliderInfoByShopId(ShopId);
                if (Images != null)
                {
                    returnObject.Add("Images", Images);
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
    }
}