using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShopManagement.Data
{
    public class Shop
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString);
        DataTable dt = new DataTable();

        public bool Add(string Id, string Name, string ShopArea, string Image, string Notes, string Status, string MobileNumber, int MaxOrderCount)
        {
            bool Result = false;
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO ShopsInfo VALUES(@Id,@Name,@ShopArea,@Image,@Notes,@Status,@CreatedDate,@ModifiedDate,@MobileNumber,@MaxOrderCount)");
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@ShopArea", ShopArea);
                cmd.Parameters.AddWithValue("@Image", Image);
                cmd.Parameters.AddWithValue("@Notes", Notes);
                cmd.Parameters.AddWithValue("@Status", Status);
                cmd.Parameters.AddWithValue("@CreatedDate", System.DateTime.Now);
                cmd.Parameters.AddWithValue("@ModifiedDate", System.DateTime.Now);
                cmd.Parameters.AddWithValue("@MobileNumber", MobileNumber);
                cmd.Parameters.AddWithValue("@MaxOrderCount", MaxOrderCount);
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

        public bool Update(string Id, string Name, string ShopArea, string Image, string Notes, string Status, string MobileNumber, int MaxOrderCount)
        {
            bool Result = false;
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE ShopsInfo SET Name=@Name, ShopArea=@ShopArea, Image=@Image, Notes=@Notes, Status=@Status, MobileNumber=@MobileNumber, ModifiedDate=@ModifiedDate, MaxOrderCount=@MaxOrderCount WHERE Id=@Id");
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@ShopArea", ShopArea);
                cmd.Parameters.AddWithValue("@Image", Image);
                cmd.Parameters.AddWithValue("@Notes", Notes);
                cmd.Parameters.AddWithValue("@Status", Status);
                cmd.Parameters.AddWithValue("@ModifiedDate", System.DateTime.Now);
                cmd.Parameters.AddWithValue("@MobileNumber", MobileNumber);
                cmd.Parameters.AddWithValue("@MaxOrderCount", MaxOrderCount);
                cmd.Connection = con;
                int i = cmd.ExecuteNonQuery();
                con.Close();
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
                SqlCommand cmd = new SqlCommand("DELETE FROM ShopsInfo WHERE Id=@Id");
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

        public DataTable GetAllShops()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM ShopsInfo");
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

        public DataTable GetAllShopsByStaus(bool IsActive)
        {
            try
            {
                string Status = "active";
                if (!IsActive)
                    Status = "inactive";
                SqlCommand cmd = new SqlCommand("SELECT * FROM ShopsInfo WHERE Status=@Status");
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

        public DataTable GetShopById(string Id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM ShopsInfo WHERE Id=@Id");
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

        public DataTable GetShopCount()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM ShopsInfo");
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

        public DataTable GetShopCountByStaus(bool IsActive)
        {
            try
            {
                string Status = "active";
                if (!IsActive)
                    Status = "inactive";
                SqlCommand cmd = new SqlCommand("SELECT * FROM ShopsInfo WHERE Status=@Status");
                cmd.Parameters.AddWithValue("@status", Status);
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

        public bool AddUserConnector(string ShopId, string UserId)
        {
            bool Result = false;
            try
            {
                string Id = Guid.NewGuid().ToString();
                SqlCommand cmd = new SqlCommand("INSERT INTO UserConnector VALUES(@Id,@UserId,@ShopId,@CreatedDate,@ModifiedDate)");
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@UserId", UserId);
                cmd.Parameters.AddWithValue("@ShopId", ShopId);
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

        public bool DeleteUserConnectorByShopId(string ShopId)
        {
            bool Result = false;
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM UserConnector WHERE ShopId=@ShopId");
                cmd.Parameters.AddWithValue("@ShopId", ShopId);
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

        public DataTable GetUserConnectedShopInfo(string UserId)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM ShopsInfo WHERE Status=@Status");
                cmd.Parameters.AddWithValue("@UserId", UserId);
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