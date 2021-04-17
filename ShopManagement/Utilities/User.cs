using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ShopManagement.Utilities
{
    public class User
    {
        Data.User _userData = new Data.User();
        public Models.User ValidateUserLogin(string MobileNumber, string Password)
        {
            DataTable dt = new DataTable();
            Models.User UserInfo = new Models.User();
            try
            {
                dt = _userData.ValidateUserLogin(MobileNumber, Password);
                foreach (DataRow record in dt.Rows)
                {
                    UserInfo = BuildUserData(record);
                }
            }
            catch (Exception)
            {

            }
            return UserInfo;
        }
        public bool Add(string Name, string EmailId, string Password, string Image, string Status, string Area, string Notes, string MobileNumber, int IsAdmin)
        {
            bool Result = false;
            try
            {
                string Id = Guid.NewGuid().ToString();
                Result = _userData.AddUser(Id, Name, EmailId, Password, Image, Status, Area, Notes, MobileNumber, IsAdmin);
            }
            catch (Exception)
            {

            }
            return Result;
        }

        public bool Update(string Id, string Name, string EmailId, string Password, string Image, string Status, string Area, string Notes, string MobileNumber, int IsAdmin)
        {
            bool Result = false;
            try
            {
                Result = _userData.Update(Id, Name, EmailId, Password, Image, Status, Area, Notes, MobileNumber, IsAdmin);
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
                _userData.DeleteUserConnectorByUserId(Id);
                Result = _userData.Delete(Id);
            }
            catch (Exception)
            {

            }
            return Result;
        }

        public Models.User GetUserById(string Id)
        {
            DataTable dt = new DataTable();
            Models.User user = new Models.User();
            try
            {
                dt = _userData.GetUserById(Id);
                foreach (DataRow record in dt.Rows)
                {
                    user = BuildUserData(record);
                }
            }
            catch (Exception)
            {

            }
            return user;
        }

        public List<Models.User> GetAllUsers()
        {
            DataTable dt = new DataTable();
            List<Models.User> usersList = new List<Models.User>();
            try
            {
                dt = _userData.GetAllUsers();
                foreach (DataRow record in dt.Rows)
                {
                    Models.User user = new Models.User();
                    user = BuildUserData(record);
                    usersList.Add(user);
                }
            }
            catch (Exception)
            {

            }
            return usersList;
        }

        public List<Models.User> GetAllUsersByStatus(bool IsActive)
        {
            DataTable dt = new DataTable();
            List<Models.User> usersList = new List<Models.User>();
            try
            {
                dt = _userData.GetAllUsersByStatus(IsActive);
                foreach (DataRow record in dt.Rows)
                {
                    Models.User user = new Models.User();
                    user = BuildUserData(record);
                    usersList.Add(user);
                }
            }
            catch (Exception)
            {

            }
            return usersList;
        }

        public Models.User BuildUserData(DataRow record)
        {
            Models.User user = new Models.User();
            try
            {
                user.Id = record["Id"].ToString();
                user.Name = record["Name"].ToString();
                user.EmailId = record["EmailId"].ToString();
                user.Password = record["Password"].ToString();
                user.Image = record["Image"].ToString() == "" ? Globals.Default_shopImage : record["Image"].ToString();
                user.Status = record["Status"].ToString();
                user.Area = record["Area"].ToString();
                user.Notes = record["Notes"].ToString();
                user.CreatedDate = Convert.ToDateTime(record["CreatedDate"].ToString());
                user.ModifiedDate = Convert.ToDateTime(record["ModifiedDate"].ToString());
                user.MobileNumber = record["MobileNumber"].ToString();
                user.IsAdmin = (int)record["IsAdmin"];
            }
            catch (Exception)
            {

            }
            return user;
        }

        public bool DeleteUserConnectorByUserId(string UserId)
        {
            bool Result = false;
            try
            {
                Result = _userData.DeleteUserConnectorByUserId(UserId);
            }
            catch (Exception)
            {

            }
            return Result;
        }

        public Models.User GetShopConnectedUserInfo(string ShopId)
        {
            DataTable dt = new DataTable();
            Models.User user = new Models.User();
            try
            {
                dt = _userData.GetShopConnectedUserInfo(ShopId);
                foreach (DataRow record in dt.Rows)
                {
                    user = BuildUserData(record);
                }
            }
            catch (Exception)
            {

            }
            return user;
        }

        public bool GetUserInfoForExistsProperty(string UserName, string MobileNumber, string EMailId)
        {
            DataTable dt = new DataTable();
            bool IsUserExists = false;
            try
            {
                dt = _userData.GetUserInfoForExistsProperty(UserName, MobileNumber, EMailId);
                if(dt.Rows.Count > 0)
                {
                    IsUserExists = true;
                }
            }
            catch (Exception)
            {

            }
            return IsUserExists;
        }
    }
}