using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;

namespace ShopManagement.Utilities
{
    public class Order
    {
        Data.Order _orderData = new Data.Order();

        public bool Add(string BillNumber,string CustomerName, string Image, string Image2, string Image3, string ShopId, int Amount, int PaidAmount, int BalanceAmount, string CustomerMobileNumber, string Status, string Notes, DateTime StartDate, DateTime EndDate, Models.SafariInfo safariInfo, Models.PantInfo pantInfo, Models.ShirtInfo shirtInfo)
        {
            bool Result = false;
            try
            {
                string Id = Guid.NewGuid().ToString();
                Result = _orderData.Add(Id, BillNumber, CustomerName, Image, Image2, Image3, ShopId, Amount, PaidAmount, BalanceAmount, CustomerMobileNumber, Status, Notes, StartDate, EndDate);
                if (Result)
                {
                    string Message = "Hi "+ CustomerName + ", Your Order has been Taken, Expected Delivery " + EndDate.ToString("dd/MMM/yyyy") + " and Total Amount is " + Amount;
                    sendSMS(CustomerMobileNumber, Message);
                    if (safariInfo != null)
                    {
                        safariInfo.Id = Guid.NewGuid().ToString();
                        safariInfo.OrderId = Id;
                        Result = _orderData.AddSafariInfo(safariInfo.Id, safariInfo.OrderId, safariInfo.Length, safariInfo.Shoulder, safariInfo.S_Length, safariInfo.S_Loose, safariInfo.Chest, safariInfo.Waist, safariInfo.Hip, safariInfo.Collar, safariInfo.Collar_Style, safariInfo.Buttons, safariInfo.Side_Vent, safariInfo.S_Breast, safariInfo.D_Breast, safariInfo.Breast, safariInfo.Notes); 
                    }

                    if (Result)
                    {
                        if (pantInfo != null)
                        {
                            pantInfo.Id = Guid.NewGuid().ToString();
                            pantInfo.OrderId = Id;
                            Result = _orderData.AddPantInfo(pantInfo.Id, pantInfo.OrderId, pantInfo.Length, pantInfo.Seat, pantInfo.Hip, pantInfo.InSeen, pantInfo.Thigh, pantInfo.Knee, pantInfo.Bottom, pantInfo.BackPocket, pantInfo.WatchPocket, pantInfo.Iron, pantInfo.Emming, pantInfo.BottomFold, pantInfo.BuckleModel, pantInfo.HookButton, pantInfo.Button, pantInfo.Notes); 
                        }

                        if (Result)
                        {
                            if (shirtInfo != null)
                            {
                                shirtInfo.Id = Guid.NewGuid().ToString();
                                shirtInfo.OrderId = Id;
                                Result = _orderData.AddShirtInfo(shirtInfo.Id, shirtInfo.OrderId, shirtInfo.Length, shirtInfo.Shoulder, shirtInfo.S_Length, shirtInfo.S_Loose, shirtInfo.Chest, shirtInfo.Waist, shirtInfo.Hip, shirtInfo.Collar, shirtInfo.Collar_Size, shirtInfo.Collar_Style, shirtInfo.Cuf_Size, shirtInfo.Cuf_Style, shirtInfo.Collar_Button, shirtInfo.Patti, shirtInfo.Pocket, shirtInfo.InnerPocket, shirtInfo.KneePatch, shirtInfo.Fit, shirtInfo.Notes); 
                            }
                        }
                    }
                    
                }
            }
            catch (Exception)
            {

            }
            return Result;
        }

        public bool Update(string Id, string BillNumber, string CustomerName, string Image, string Image2, string Image3, string ShopId, int Amount, int PaidAmount, int BalanceAmount, string CustomerMobileNumber, string Status, string Notes, DateTime StartDate, DateTime EndDate, Models.SafariInfo safariInfo, Models.PantInfo pantInfo, Models.ShirtInfo shirtInfo)
        {
            bool Result = false;
            try
            {
                var _previousOrderData = GetOrderInfoById(Id);
                if(_previousOrderData != null && !string.IsNullOrEmpty(_previousOrderData.Id))
                {
                    if(_previousOrderData.Status != Status)
                    {
                        string Message = "Hi " + CustomerName + ", Your Order status has been changed from " + _previousOrderData.Status + " to " + Status + ", Expected Delivery " + EndDate.ToString("dd/MMM/yyyy") + " and Total Amount is " + Amount;
                        sendSMS(CustomerMobileNumber, Message);
                    }
                }
                Result = _orderData.Update(Id, BillNumber, CustomerName, Image, Image2, Image3, ShopId, Amount, PaidAmount, BalanceAmount, CustomerMobileNumber, Status, Notes, StartDate, EndDate);
                if (Result)
                {
                    if (safariInfo != null)
                    {
                        _orderData.DeleteSafariInfoByOrderId(Id);
                        safariInfo.Id = Guid.NewGuid().ToString();
                        safariInfo.OrderId = Id;
                        Result = _orderData.AddSafariInfo(safariInfo.Id, safariInfo.OrderId, safariInfo.Length, safariInfo.Shoulder, safariInfo.S_Length, safariInfo.S_Loose, safariInfo.Chest, safariInfo.Waist, safariInfo.Hip, safariInfo.Collar, safariInfo.Collar_Style, safariInfo.Buttons, safariInfo.Side_Vent, safariInfo.S_Breast, safariInfo.D_Breast, safariInfo.Breast, safariInfo.Notes);
                    }

                    if (Result)
                    {
                        if (pantInfo != null)
                        {
                            _orderData.DeletePantiInfoByOrderId(Id);
                            pantInfo.Id = Guid.NewGuid().ToString();
                            pantInfo.OrderId = Id;
                            Result = _orderData.AddPantInfo(pantInfo.Id, pantInfo.OrderId, pantInfo.Length, pantInfo.Seat, pantInfo.Hip, pantInfo.InSeen, pantInfo.Thigh, pantInfo.Knee, pantInfo.Bottom, pantInfo.BackPocket, pantInfo.WatchPocket, pantInfo.Iron, pantInfo.Emming, pantInfo.BottomFold, pantInfo.BuckleModel, pantInfo.HookButton, pantInfo.Button, pantInfo.Notes);
                        }

                        if (Result)
                        {
                            if (shirtInfo != null)
                            {
                                _orderData.DeleteShirtInfoByOrderId(Id);
                                shirtInfo.Id = Guid.NewGuid().ToString();
                                shirtInfo.OrderId = Id;
                                Result = _orderData.AddShirtInfo(shirtInfo.Id, shirtInfo.OrderId, shirtInfo.Length, shirtInfo.Shoulder, shirtInfo.S_Length, shirtInfo.S_Loose, shirtInfo.Chest, shirtInfo.Waist, shirtInfo.Hip, shirtInfo.Collar, shirtInfo.Collar_Size, shirtInfo.Collar_Style, shirtInfo.Cuf_Size, shirtInfo.Cuf_Style, shirtInfo.Collar_Button, shirtInfo.Patti, shirtInfo.Pocket, shirtInfo.InnerPocket, shirtInfo.KneePatch, shirtInfo.Fit, shirtInfo.Notes);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
            return Result;
        }

        public bool Delete(string Id)
        {
            bool Result = false;
            try
            {
                Result = _orderData.Delete(Id);
                _orderData.DeleteSafariInfoByOrderId(Id);
                _orderData.DeleteShirtInfoByOrderId(Id);
                _orderData.DeletePantiInfoByOrderId(Id);
            }
            catch (Exception)
            {

            }
            return Result;
        }

        public bool DeleteOrderByShopId(string ShopId)
        {
            bool Result = false;
            try
            {
                Result = _orderData.DeleteOrderByShopId(ShopId);
            }
            catch (Exception)
            {

            }
            return Result;
        }

        public Models.Order GetOrderInfoById(string Id)
        {
            DataTable dt = new DataTable();
            Models.Order OrderInfo = new Models.Order();
            try
            {
                dt = _orderData.GetOrderById(Id);
                foreach (DataRow record in dt.Rows)
                {
                    OrderInfo = BuildOrderInfo(record);
                }
            }
            catch (Exception)
            {

            }
            return OrderInfo;
        }

        public Models.Order GetOrderByBillNumber(string BillNumber)
        {
            DataTable dt = new DataTable();
            Models.Order OrderInfo = new Models.Order();
            try
            {
                dt = _orderData.GetOrderByBillNumber(BillNumber);
                foreach (DataRow record in dt.Rows)
                {
                    OrderInfo = BuildOrderInfo(record);
                }
            }
            catch (Exception)
            {

            }
            return OrderInfo;
        }

        public List<Models.Order> GetAllOrders()
        {
            DataTable dt = new DataTable();
            List<Models.Order> OrdersList = new List<Models.Order>();
            try
            {
                dt = _orderData.GetAllOrders();
                foreach (DataRow record in dt.Rows)
                {
                    Models.Order OrderInfo = new Models.Order();
                    OrderInfo = BuildOrderInfo(record);
                    OrdersList.Add(OrderInfo);
                }
            }
            catch (Exception)
            {

            }
            return OrdersList;
        }

        public List<Models.Order> GetAllOrdersByShopIds(List<string> ShopIds)
        {
            DataTable dt = new DataTable();
            List<Models.Order> OrdersList = new List<Models.Order>();
            try
            {
                dt = _orderData.GetAllOrdersByShopId(ShopIds);
                foreach (DataRow record in dt.Rows)
                {
                    Models.Order OrderInfo = new Models.Order();
                    OrderInfo = BuildOrderInfo(record);
                    OrdersList.Add(OrderInfo);
                }
            }
            catch (Exception)
            {

            }
            return OrdersList;
        }

        public List<Models.Order> GetAllOrdersByStatus(string Status)
        {
            DataTable dt = new DataTable();
            List<Models.Order> OrdersList = new List<Models.Order>();
            try
            {
                dt = _orderData.GetAllOrdersByStatus(Status);
                foreach (DataRow record in dt.Rows)
                {
                    Models.Order OrderInfo = new Models.Order();
                    OrderInfo = BuildOrderInfo(record);
                    OrdersList.Add(OrderInfo);
                }
            }
            catch (Exception)
            {

            }
            return OrdersList;
        }
        
        public List<Models.Order> GetAllOrdersDates(string ShopId, string FilterDate)
        {
            DataTable dt = new DataTable();
            List<Models.Order> OrdersList = new List<Models.Order>();
            try
            {
                dt = _orderData.GetAllOrdersDates(ShopId, FilterDate);
                foreach (DataRow record in dt.Rows)
                {
                    Models.Order OrderInfo = new Models.Order();
                    OrderInfo = BuildOrderInfo(record);
                    OrdersList.Add(OrderInfo);
                }
            }
            catch (Exception)
            {

            }
            return OrdersList;
        }

        public int GetShopTodaysOderCount(string ShopId)
        {
            int OrdersCount = 0;
            DataTable dt = new DataTable();
            try
            {
                dt = _orderData.GetShopTodaysOderCount(ShopId);
                foreach (DataRow record in dt.Rows)
                {
                    OrdersCount = (int)record["Count"];
                }
            }
            catch (Exception)
            {

            }
            return OrdersCount;
        }

        public List<Models.Order> GetOrdersByCompletedDate(List<string> ShopId, string FilterDate)
        {
            DataTable dt = new DataTable();
            List<Models.Order> OrdersList = new List<Models.Order>();
            try
            {
                dt = _orderData.GetOrdersByCompletedDate(ShopId, FilterDate);
                foreach (DataRow record in dt.Rows)
                {
                    Models.Order OrderInfo = new Models.Order();
                    OrderInfo = BuildOrderInfo(record);
                    OrdersList.Add(OrderInfo);
                }
            }
            catch (Exception)
            {

            }
            return OrdersList;
        }

        public Models.Order BuildOrderInfo(DataRow record)
        {
            Models.Order OrderInfo = new Models.Order();
            Utilities.Shop shopUtilities = new Shop();
            DateTime CurrentDate = DateTime.UtcNow.Date;
            try
            {
                OrderInfo.Id = record["Id"].ToString();
                OrderInfo.BillNumber = record["BillNumber"].ToString();
                OrderInfo.CustomerName = record["CustomerName"].ToString();
                OrderInfo.Image = record["Image"].ToString();
                OrderInfo.Image2 = record["Image2"].ToString();
                OrderInfo.Image3 = record["Image3"].ToString();
                OrderInfo.ShopId = record["ShopId"].ToString();
                OrderInfo.Amount = (int)record["Amount"];
                OrderInfo.PaidAmount = (int)record["PaidAmount"];
                OrderInfo.BalanceAmount = (int)record["BalanceAmount"];
                OrderInfo.CustomerMobileNumber = record["CustomerMobileNumber"].ToString(); ;
                OrderInfo.Status = record["Status"].ToString();
                OrderInfo.Notes = record["Notes"].ToString();
                OrderInfo.StartDate = Convert.ToDateTime(record["StartDate"].ToString());
                OrderInfo.EndDate = Convert.ToDateTime(record["EndDate"].ToString());
                OrderInfo.CreatedDate = Convert.ToDateTime(record["CreatedDate"].ToString());
                OrderInfo.ModifiedDate = Convert.ToDateTime(record["ModifiedDate"].ToString());
                OrderInfo.SafariInfo = GetSafariInfoByOrderId(record["Id"].ToString());
                OrderInfo.PantInfo = GetPantiInfoByOrderId(record["Id"].ToString());
                OrderInfo.ShirtInfo = GetShirtiInfoByOrderId(record["Id"].ToString());
                var days = ((TimeSpan)(OrderInfo.EndDate - CurrentDate)).Days;
                OrderInfo.DaysRemaining = days > 0 ? days.ToString() : "0";
                OrderInfo.ShopName = shopUtilities.GetShopById(record["ShopId"].ToString()).Name;
                OrderInfo.StartDateInString = OrderInfo.StartDate.ToString("yyyy-MM-dd");
                OrderInfo.EndDateInString = OrderInfo.EndDate.ToString("yyyy-MM-dd");
            }
            catch (Exception)
            {

            }
            return OrderInfo;
        }

        public Models.SafariInfo GetSafariInfoByOrderId(string OrderId)
        {
            DataTable dt = new DataTable();
            Models.SafariInfo SafariInfo = new Models.SafariInfo();
            try
            {
                dt = _orderData.GetSafariInfoByOrderId(OrderId);
                foreach (DataRow record in dt.Rows)
                {
                    SafariInfo = new Models.SafariInfo()
                    {
                        Id = record["Id"].ToString(),
                        OrderId = record["OrderId"].ToString(),
                        CreatedDate = record["CreatedDate"].ToString(),
                        Length = record["Length"].ToString(),
                        Shoulder = record["Shoulder"].ToString(),
                        S_Length = record["S_Length"].ToString(),
                        S_Loose = record["S_Loose"].ToString(),
                        Chest = record["Chest"].ToString(),
                        Waist = record["Waist"].ToString(),
                        Hip = record["Hip"].ToString(),
                        Collar = record["Collar"].ToString(),
                        Collar_Style = record["Collar_Style"].ToString(),
                        Buttons = record["Buttons"].ToString(),
                        Side_Vent = record["Side_Vent"].ToString(),
                        S_Breast = record["S_Breast"].ToString(),
                        D_Breast = record["D_Breast"].ToString(),
                        Breast = record["Breast"].ToString(),
                        Notes = record["Notes"].ToString(),
                        ModifiedDate = record["ModifiedDate"].ToString()
                    };
                }
            }
            catch (Exception)
            {

            }
            return SafariInfo;
        }

        public Models.PantInfo GetPantiInfoByOrderId(string OrderId)
        {
            DataTable dt = new DataTable();
            Models.PantInfo PantInfo = new Models.PantInfo();
            try
            {
                dt = _orderData.GetPantiInfoByOrderId(OrderId);
                foreach (DataRow record in dt.Rows)
                {
                    PantInfo = new Models.PantInfo()
                    {
                        Id = record["Id"].ToString(),
                        OrderId = record["OrderId"].ToString(),
                        CreatedDate = record["CreatedDate"].ToString(),
                        Length = record["Length"].ToString(),
                        Seat = record["Seat"].ToString(),
                        Hip = record["Hip"].ToString(),
                        InSeen = record["InSeen"].ToString(),
                        Thigh = record["Thigh"].ToString(),
                        Knee = record["Knee"].ToString(),
                        Bottom = record["Bottom"].ToString(),
                        BackPocket = record["BackPocket"].ToString(),
                        WatchPocket = record["WatchPocket"].ToString(),
                        Iron = record["Iron"].ToString(),
                        Emming = record["Emming"].ToString(),
                        BottomFold = record["BottomFold"].ToString(),
                        BuckleModel = record["BuckleModel"].ToString(),
                        HookButton = record["HookButton"].ToString(),
                        Button = record["Button"].ToString(),
                        Notes = record["Notes"].ToString(),
                        ModifiedDate = record["ModifiedDate"].ToString()
                    };
                }
            }
            catch (Exception)
            {

            }
            return PantInfo;
        }

        public Models.ShirtInfo GetShirtiInfoByOrderId(string OrderId)
        {
            DataTable dt = new DataTable();
            Models.ShirtInfo ShirtInfo = new Models.ShirtInfo();
            try
            {
                dt = _orderData.GetShirtiInfoByOrderId(OrderId);
                foreach (DataRow record in dt.Rows)
                {
                    ShirtInfo = new Models.ShirtInfo()
                    {
                        Id = record["Id"].ToString(),
                        OrderId = record["OrderId"].ToString(),
                        CreatedDate = record["CreatedDate"].ToString(),
                        Length = record["Length"].ToString(),
                        Shoulder = record["Shoulder"].ToString(),
                        S_Length = record["S_Length"].ToString(),
                        S_Loose = record["S_Loose"].ToString(),
                        Chest = record["Chest"].ToString(),
                        Waist = record["Waist"].ToString(),
                        Hip = record["Hip"].ToString(),
                        Collar = record["Collar"].ToString(),
                        Collar_Size = record["Collar_Size"].ToString(),
                        Collar_Style = record["Collar_Style"].ToString(),
                        Cuf_Size = record["Cuf_Size"].ToString(),
                        Cuf_Style = record["Cuf_Style"].ToString(),
                        Collar_Button = record["Collar_Button"].ToString(),
                        Patti = record["Patti"].ToString(),
                        Pocket = record["Pocket"].ToString(),
                        InnerPocket = record["InnerPocket"].ToString(),
                        KneePatch = record["KneePatch"].ToString(),
                        Fit = record["Fit"].ToString(),
                        Notes = record["Notes"].ToString(),
                        ModifiedDate = record["ModifiedDate"].ToString()
                    };
                }
            }
            catch (Exception)
            {

            }
            return ShirtInfo;
        }
        public string sendSMS(string MobileNumber, string Message)
        {
            bool IsSendMessage = Globals.IsSendSMS;
            string result = "";
            string API_Key = Globals.API_Key;
            if (IsSendMessage)
            {
                var client = new RestClient("https://www.fast2sms.com/dev/bulkV2?authorization=" + API_Key + "&route=v3&sender_id=TXTIND&message=" + Message + "&language=english&flash=1&numbers=" + MobileNumber);
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
            }
            return result;
        }
    }
}