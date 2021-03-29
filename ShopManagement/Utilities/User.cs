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
        DataTable dt = new DataTable();

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
                user.Image = record["Image"].ToString() == "" ? Globals.Default_ProfileImage : record["Image"].ToString();
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
    }
}