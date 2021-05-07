using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ShopManagement.Utilities
{
    public class Shop
    {
        Data.Shop _shopData = new Data.Shop();
        Data.Order _orderData = new Data.Order();
        

        public bool Add(string Name, string ShopArea, string UserId, string Image, string Notes, string Status, string MobileNumber, int MaxOrderCount)
        {
            bool Result = false;
            try
            {
                string Id = Guid.NewGuid().ToString();
                Result = _shopData.Add(Id, Name, ShopArea, Image, Notes, Status, MobileNumber, MaxOrderCount);
                if (Result)
                {
                    DeleteUserConnectorByShopId(Id);
                    if (Result)
                    {
                        Result = AddUserConnector(Id, UserId);
                    }
                    Utilities.Slider _sliderData = new Utilities.Slider();
                    Result = _sliderData.Add("Slider One", Id);
                    Result = _sliderData.Add("Slider Two", Id);
                }
            }
            catch (Exception)
            {

            }
            return Result;
        }

        public bool Update(string Id, string Name, string ShopArea, string UserId, string Image, string Notes, string Status, string MobileNumber, int MaxOrderCount)
        {
            bool Result = false;
            try
            {
                Result = _shopData.Update(Id, Name, ShopArea, Image, Notes, Status, MobileNumber, MaxOrderCount);
                if (Result)
                {
                    //DeleteUserConnectorByShopId(Id);
                    Utilities.User UserUtility = new User();
                    List<Models.User> UsersList = UserUtility.GetShopConnectedUserList(Id);
                    var UserIds = UsersList.Select(x => x.Id).ToList();
                    if (!UserIds.Contains(UserId))
                    {
                        Result = AddUserConnector(Id, UserId);
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
                DeleteUserConnectorByShopId(Id);
                _orderData.DeleteOrderByShopId(Id);
                Result = _shopData.Delete(Id);
            }
            catch (Exception)
            {

            }
            return Result;
        }

        public Models.Shop GetShopById(string Id)
        {
            DataTable dt = new DataTable();
            Models.Shop shop = new Models.Shop();
            try
            {
                dt = _shopData.GetShopById(Id);
                foreach (DataRow record in dt.Rows)
                {
                    shop = BuildShopData(record);
                }
            }
            catch (Exception)
            {

            }
            return shop;
        }

        public List<Models.Shop> GetAllShops()
        {
            DataTable dt = new DataTable();
            List<Models.Shop> shopsList = new List<Models.Shop>();
            try
            {
                dt = _shopData.GetAllShops();
                foreach (DataRow record in dt.Rows)
                {
                    Models.Shop shop = new Models.Shop();
                    shop = BuildShopData(record);
                    shopsList.Add(shop);
                }
            }
            catch (Exception)
            {

            }
            return shopsList;
        }
        
        public List<Models.Shop> GetAllShopsByStaus(bool IsActive)
        {
            DataTable dt = new DataTable();
            List<Models.Shop> shopsList = new List<Models.Shop>();
            try
            {
                dt = _shopData.GetAllShopsByStaus(IsActive);
                foreach (DataRow record in dt.Rows)
                {
                    Models.Shop shop = new Models.Shop();
                    shop = BuildShopData(record);
                    shopsList.Add(shop);
                }
            }
            catch (Exception)
            {

            }
            return shopsList;
        }

        public Models.Shop BuildShopData(DataRow record)
        {
            Models.Shop shop = new Models.Shop();
            Utilities.Order _orderUtility = new Order();
            try
            {
                shop.Id = record["Id"].ToString();
                shop.Name = record["Name"].ToString();
                shop.ShopArea = record["ShopArea"].ToString();
                shop.Image = record["Image"].ToString();
                shop.Notes = record["Notes"].ToString();
                shop.Status = record["Status"].ToString();
                shop.CreatedDate = Convert.ToDateTime(record["CreatedDate"].ToString());
                shop.ModifiedDate = Convert.ToDateTime(record["ModifiedDate"].ToString());
                shop.MobileNumber = record["MobileNumber"].ToString();
                shop.MaxOrderCount = (int)record["MaxOrderCount"];
                shop.TodaysOderCount = _orderUtility.GetShopTodaysOderCount(shop.Id);
            }
            catch (Exception)
            {

            }
            return shop;
        }

        public string GetShopsCount()
        {
            DataTable dt = new DataTable();
            string Count = "0";
            try
            {
                dt = _shopData.GetShopCount();
                foreach (DataRow record in dt.Rows)
                {
                    Count = record["CustomerCount"].ToString();
                }
            }
            catch (Exception)
            {

            }
            return Count;
        }

        public string GetShopCountByStaus(bool IsActive)
        {
            DataTable dt = new DataTable();
            string Count = "0";
            try
            {
                dt = _shopData.GetShopCountByStaus(IsActive);
                foreach (DataRow record in dt.Rows)
                {
                    Count = record["CustomerCount"].ToString();
                }
            }
            catch (Exception)
            {

            }
            return Count;
        }

        public bool AddUserConnector(string ShopId, string UserId)
        {
            bool Result = false;
            try
            {
                Result = _shopData.AddUserConnector(ShopId, UserId);
            }
            catch (Exception)
            {

            }
            return Result;
        }

        public bool DeleteUserConnectorByShopId(string ShopId)
        {
            bool Result = false;
            try
            {
                Result = _shopData.DeleteUserConnectorByShopId(ShopId);
            }
            catch (Exception)
            {

            }
            return Result;
        }
        public bool DeleteUserConnectorByUserAndShopId(string ShopId, string UserId)
        {
            bool Result = false;
            try
            {
                Result = _shopData.DeleteUserConnectorByUserAndShopId(ShopId, UserId);
            }
            catch (Exception)
            {

            }
            return Result;
        }

        public Models.Shop GetUserConnectedShopInfo(string UserId)
        {
            DataTable dt = new DataTable();
            Models.Shop shop = null;
            try
            {
                dt = _shopData.GetUserConnectedShopInfo(UserId);
                foreach (DataRow record in dt.Rows)
                {
                    shop = BuildShopData(record);
                }
            }
            catch (Exception)
            {

            }
            return shop;
        }


    }
}