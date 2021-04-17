using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShopManagement.Data
{
    public class Order
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString);

        public bool Add(string Id, string CustomerName, string Image, string ShopId, int Amount, int CustomerMobileNumber,string Status, string Notes, DateTime StartDate, DateTime EndDate)
        {
            bool Result = false;
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO OrderInfo VALUES(@Id,@CustomerName,@Image,@ShopId,@Amount,@CustomerMobileNumber,@Status,@Notes,@StartDate,@EndDate,@CreatedDate,@ModifiedDate)");
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@CustomerName", CustomerName);
                cmd.Parameters.AddWithValue("@Image", Image);
                cmd.Parameters.AddWithValue("@ShopId", ShopId);
                cmd.Parameters.AddWithValue("@Amount", Amount);
                cmd.Parameters.AddWithValue("@CustomerMobileNumber", CustomerMobileNumber);
                cmd.Parameters.AddWithValue("@Status", Status);
                cmd.Parameters.AddWithValue("@Notes", Notes);
                cmd.Parameters.AddWithValue("@StartDate", StartDate);
                cmd.Parameters.AddWithValue("@EndDate", EndDate);
                cmd.Parameters.AddWithValue("@CreatedDate", System.DateTime.Now);
                cmd.Parameters.AddWithValue("@ModifiedDate", System.DateTime.Now);
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

        public bool Update(string Id, string CustomerName, string Image, string ShopId, int Amount, int CustomerMobileNumber,string Status, string Notes, DateTime StartDate, DateTime EndDate)
        {
            bool Result = false;
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE OrderInfo SET CustomerName=@CustomerName, Image=@Image, ShopId=@ShopId, Amount=@Amount, CustomerMobileNumber=@CustomerMobileNumber, Status=@Status, Notes=@Notes, StartDate=@StartDate, EndDate=@EndDate, ModifiedDate=@ModifiedDate WHERE Id=@Id");
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@CustomerName", CustomerName);
                cmd.Parameters.AddWithValue("@Image", Image);
                cmd.Parameters.AddWithValue("@ShopId", ShopId);
                cmd.Parameters.AddWithValue("@Amount", Amount);
                cmd.Parameters.AddWithValue("@CustomerMobileNumber", CustomerMobileNumber);
                cmd.Parameters.AddWithValue("@Status", Status);
                cmd.Parameters.AddWithValue("@Notes", Notes);
                cmd.Parameters.AddWithValue("@StartDate", StartDate);
                cmd.Parameters.AddWithValue("@EndDate", EndDate);
                cmd.Parameters.AddWithValue("@ModifiedDate", System.DateTime.Now);
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
                SqlCommand cmd = new SqlCommand("DELETE FROM OrderInfo WHERE Id=@Id");
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

        public bool DeleteOrderByShopId(string ShopId)
        {
            bool Result = false;
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM OrderInfo WHERE ShopId=@ShopId");
                cmd.Parameters.AddWithValue("@ShopId", ShopId);
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

        public DataTable GetOrderById(string Id)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM OrderInfo WHERE Id=@Id");
                cmd.Parameters.AddWithValue("@Id", Id);
                con.Open();
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }
            catch (Exception)
            {
                con.Close();
            }
            return dt;
        }

        public DataTable GetAllOrders()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM OrderInfo");
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

        public DataTable GetAllOrdersByShopId(string ShopId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM OrderInfo WHERE ShopId=@ShopId");
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

        public DataTable GetAllOrdersByStatus(string Status)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM OrderInfo WHERE Status=@Status");
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

        public DataTable GetAllOrdersDates(string ShopId, string FilterDate)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd;
                if (!string.IsNullOrEmpty(ShopId))
                {
                    cmd = new SqlCommand("SELECT * FROM OrderInfo WHERE datepart(month,CreatedDate) =datepart(month,@FilterDate) and datepart(year,CreatedDate)=datepart(year,@FilterDate) and ShopId=@ShopId");
                    cmd.Parameters.AddWithValue("@SupplierId", ShopId);
                    cmd.Parameters.AddWithValue("@FilterDate", FilterDate);
                }
                else
                {
                    cmd = new SqlCommand("SELECT * FROM OrderInfo WHERE datepart(month,CreatedDate) =datepart(month,@FilterDate) and datepart(year,CreatedDate)=datepart(year,@FilterDate)");
                    cmd.Parameters.AddWithValue("@FilterDate", FilterDate);
                }               
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