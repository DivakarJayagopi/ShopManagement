using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ShopManagement.Utilities
{
    public class Order
    {
        Data.Order _orderData = new Data.Order();

        public bool Add(string CustomerName, string Image, string ShopId, int Amount, int CustomerMobileNumber, string Status, string Notes, DateTime StartDate, DateTime EndDate)
        {
            bool Result = false;
            try
            {
                string Id = Guid.NewGuid().ToString();
                Result = _orderData.Add(Id, CustomerName, Image, ShopId, Amount, CustomerMobileNumber, Status, Notes, StartDate, EndDate);
            }
            catch (Exception)
            {

            }
            return Result;
        }

        public bool Update(string Id, string CustomerName, string Image, string ShopId, int Amount, int CustomerMobileNumber, string Status, string Notes, DateTime StartDate, DateTime EndDate)
        {
            bool Result = false;
            try
            {
                Result = _orderData.Update(Id, CustomerName, Image, ShopId, Amount, CustomerMobileNumber, Status, Notes, StartDate, EndDate);
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

        public List<Models.Order> GetAllOrdersByShopId(string ShopId)
        {
            DataTable dt = new DataTable();
            List<Models.Order> OrdersList = new List<Models.Order>();
            try
            {
                dt = _orderData.GetAllOrdersByShopId(ShopId);
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

        public Models.Order BuildOrderInfo(DataRow record)
        {
            Models.Order OrderInfo = new Models.Order();
            try
            {
                OrderInfo.Id = record["Id"].ToString();
                OrderInfo.CustomerName = record["CustomerName"].ToString();
                OrderInfo.Image = record["Image"].ToString();
                OrderInfo.ShopId = record["ShopId"].ToString();
                OrderInfo.Amount = (int)record["Amount"];
                OrderInfo.CustomerMobileNumber = record["CustomerMobileNumber"].ToString(); ;
                OrderInfo.Status = record["Status"].ToString();
                OrderInfo.Notes = record["Notes"].ToString();
                OrderInfo.StartDate = Convert.ToDateTime(record["StartDate"].ToString());
                OrderInfo.EndDate = Convert.ToDateTime(record["EndDate"].ToString());
                OrderInfo.CreatedDate = Convert.ToDateTime(record["CreatedDate"].ToString());
                OrderInfo.ModifiedDate = Convert.ToDateTime(record["ModifiedDate"].ToString());
                
            }
            catch (Exception)
            {

            }
            return OrderInfo;
        }
    }
}