using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShopManagement.Data
{
    public class User
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString);
        DataTable dt = new DataTable();

        public DataTable ValidateUserLogin(string MobileNumber, string Password)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE MobileNumber=@MobileNumber AND Password=@Password");
                cmd.Parameters.AddWithValue("@MobileNumber", MobileNumber);
                cmd.Parameters.AddWithValue("@Password", Password);
                con.Open();
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception)
            {

            }
            finally
            {
                con.Close();
            }
            return dt;
        }
        public bool AddUser(string Id, string Name, string EmailId,string Password, string Image, string Status, string Area, string Notes, string MobileNumber,int IsAdmin)
        {
            bool Result = false;
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Users VALUES(@Id,@Name,@EmailId,@Password,@Image,@Status,@Area,@Notes,@CreatedDate,@ModifiedDate,@MobileNumber,@IsAdmin)");
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@EmailId", EmailId);
                cmd.Parameters.AddWithValue("@Password", Password);
                cmd.Parameters.AddWithValue("@Image", Image);
                cmd.Parameters.AddWithValue("@Status", Status);
                cmd.Parameters.AddWithValue("@Area", Area);
                cmd.Parameters.AddWithValue("@Notes", Notes);
                cmd.Parameters.AddWithValue("@CreatedDate", System.DateTime.Now);
                cmd.Parameters.AddWithValue("@ModifiedDate", System.DateTime.Now);
                cmd.Parameters.AddWithValue("@MobileNumber", MobileNumber);
                cmd.Parameters.AddWithValue("@IsAdmin", IsAdmin);
                con.Open();
                cmd.Connection = con;
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    Result = true;
                }
            }
            catch (Exception exe)
            {

            }
            finally
            {
                con.Close();
            }
            return Result;
        }

        public bool Update(string Id, string Name, string EmailId,string Password, string Image, string Status, string Area, string Notes, string MobileNumber, int IsAdmin)
        {
            bool Result = false;
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE Users SET Name=@Name, EmailId=@EmailId, Password=@Password, Image=@Image, Status=@Status, Area=@Area, Notes=@Notes, MobileNumber=@MobileNumber,IsAdmin=@IsAdmin, ModifiedDate=@ModifiedDate  WHERE Id=@Id");
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@EmailId", EmailId);
                cmd.Parameters.AddWithValue("@Password", Password);
                cmd.Parameters.AddWithValue("@Image", Image);
                cmd.Parameters.AddWithValue("@Status", Status);
                cmd.Parameters.AddWithValue("@Area", Area);
                cmd.Parameters.AddWithValue("@Notes", Notes);
                cmd.Parameters.AddWithValue("@ModifiedDate", System.DateTime.Now);
                cmd.Parameters.AddWithValue("@MobileNumber", MobileNumber);
                cmd.Parameters.AddWithValue("@IsAdmin", IsAdmin);
                con.Open();
                cmd.Connection = con;
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    Result = true;
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                con.Close();
            }
            return Result;
        }

        public bool Delete(string Id)
        {
            bool Result = false;
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Users WHERE Id=@Id");
                cmd.Parameters.AddWithValue("@Id", Id);
                con.Open();
                cmd.Connection = con;
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    Result = true;
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                con.Close();
            }
            return Result;
        }

        public DataTable GetAllUsers()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users");
                con.Open();
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception)
            {

            }
            finally
            {
                con.Close();
            }
            return dt;
        }

        public DataTable GetAllUsersByStatus(bool IsActive)
        {
            try
            {
                string Status = "active";
                if (!IsActive)
                    Status = "inactive";
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE Status=@Status");
                cmd.Parameters.AddWithValue("@Status", Status);
                con.Open();
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception)
            {

            }
            finally
            {
                con.Close();
            }
            return dt;
        }

        public DataTable GetUserById(string Id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE Id=@Id");
                cmd.Parameters.AddWithValue("@Id", Id);
                con.Open();
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception)
            {

            }
            finally
            {
                con.Close();
            }
            return dt;
        }

        public bool DeleteUserConnectorByUserId(string UserId)
        {
            bool Result = false;
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM UserConnector WHERE UserId=@UserId");
                cmd.Parameters.AddWithValue("@UserId", UserId);
                cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);
                con.Open();
                cmd.Connection = con;
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    Result = true;
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                con.Close();
            }
            return Result;
        }

        public DataTable GetShopConnectedUserInfo(string ShopId)
        {
            try
            {
                dt = new DataTable();
                SqlCommand cmd = new SqlCommand("SELECT usr.* FROM UserConnector uc JOIN Users usr ON usr.Id = uc.UserId WHERE uc.ShopId = @ShopId");
                cmd.Parameters.AddWithValue("@ShopId", ShopId);
                con.Open();
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception)
            {

            }
            finally
            {
                con.Close();
            }
            return dt;
        }

        public DataTable GetUserInfoForExistsProperty(string UserName, string MobileNumber, string EMailId)
        {
            try
            {
                string AppendQuery = "";
                if (!string.IsNullOrEmpty(UserName))
                {
                    AppendQuery += "WHERE Name = @Name";
                }
                else if (!string.IsNullOrEmpty(MobileNumber))
                {
                    AppendQuery += "WHERE MobileNumber = @MobileNumber";
                }
                else if (!string.IsNullOrEmpty(EMailId))
                {
                    AppendQuery += "WHERE EmailId = @EmailId";
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users " + AppendQuery);
                con.Open();
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception)
            {

            }
            finally
            {
                con.Close();
            }
            return dt;
        }
    }
}