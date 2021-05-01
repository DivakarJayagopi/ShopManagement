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

        public bool Add(string Id, string BillNumber, string CustomerName, string Image, string ShopId, int Amount, string CustomerMobileNumber,string Status, string Notes, DateTime StartDate, DateTime EndDate)
        {
            bool Result = false;
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO OrderInfo VALUES(@Id,@BillNumber,@CustomerName,@Image,@ShopId,@Amount,@CustomerMobileNumber,@Status,@Notes,@StartDate,@EndDate,@CreatedDate,@ModifiedDate)");
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@BillNumber", BillNumber);
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
            catch (Exception exe)
            {

            }
            finally
            {
                con.Close();
            }
            return Result;
        }

        public bool AddSafariInfo(string Id, string OrderId, string Length, string Shoulder, string S_Length, string S_Loose, string Chest, string Waist, string Hip, string Collar, string Collar_Style, string Buttons, string Side_Vent, string S_Breast, string D_Breast, string Breast, string Notes)
        {
            bool Result = false;
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO SafariInfo VALUES(@Id,@OrderId,@CreatedDate,@Length,@Shoulder,@S_Length,@S_Loose,@Chest,@Waist,@Hip,@Collar,@Collar_Style,@Buttons,@Side_Vent,@S_Breast,@D_Breast,@Breast,@Notes,@ModifiedDate)");
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@OrderId", OrderId);
                cmd.Parameters.AddWithValue("@CreatedDate", System.DateTime.Now);
                cmd.Parameters.AddWithValue("@Length", Length);
                cmd.Parameters.AddWithValue("@Shoulder", Shoulder);
                cmd.Parameters.AddWithValue("@S_Length", S_Length);
                cmd.Parameters.AddWithValue("@S_Loose", S_Loose);
                cmd.Parameters.AddWithValue("@Chest", Chest);
                cmd.Parameters.AddWithValue("@Waist", Waist);
                cmd.Parameters.AddWithValue("@Hip", Hip);
                cmd.Parameters.AddWithValue("@Collar", Collar);
                cmd.Parameters.AddWithValue("@Collar_Style", Collar_Style);
                cmd.Parameters.AddWithValue("@Buttons", Buttons);
                cmd.Parameters.AddWithValue("@Side_Vent", Side_Vent);
                cmd.Parameters.AddWithValue("@S_Breast", S_Breast);
                cmd.Parameters.AddWithValue("@D_Breast", D_Breast);
                cmd.Parameters.AddWithValue("@Breast", Breast);
                cmd.Parameters.AddWithValue("@Notes", Notes);
                cmd.Parameters.AddWithValue("@ModifiedDate", System.DateTime.Now);
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

        public bool AddPantInfo(string Id, string OrderId, string Length, string Seat, string Hip, string InSeen, string Thigh, string Knee, string Bottom, string BackPocket, string WatchPocket, string Iron, string Emming, string BottomFold, string BuckleModel, string HookButton, string Button, string Notes)
        {
            bool Result = false;
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO PantInfo VALUES(@Id,@OrderId,@CreatedDate,@Length,@Seat,@Hip,@InSeen,@Thigh,@Knee,@Bottom,@BackPocket,@WatchPocket,@Iron,@Emming,@BottomFold,@BuckleModel,@HookButton,@Button,@Notes,@ModifiedDate)");
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@OrderId", OrderId);
                cmd.Parameters.AddWithValue("@CreatedDate", System.DateTime.Now);
                cmd.Parameters.AddWithValue("@Length", Length);
                cmd.Parameters.AddWithValue("@Seat", Seat);
                cmd.Parameters.AddWithValue("@Hip", Hip);
                cmd.Parameters.AddWithValue("@InSeen", InSeen);
                cmd.Parameters.AddWithValue("@Thigh", Thigh);
                cmd.Parameters.AddWithValue("@Knee", Knee);
                cmd.Parameters.AddWithValue("@Bottom", Bottom);
                cmd.Parameters.AddWithValue("@BackPocket", BackPocket);
                cmd.Parameters.AddWithValue("@WatchPocket", WatchPocket);
                cmd.Parameters.AddWithValue("@Iron", Iron);
                cmd.Parameters.AddWithValue("@Emming", Emming);
                cmd.Parameters.AddWithValue("@BottomFold", BottomFold);
                cmd.Parameters.AddWithValue("@BuckleModel", BuckleModel);
                cmd.Parameters.AddWithValue("@HookButton", HookButton);
                cmd.Parameters.AddWithValue("@Button", Button);
                cmd.Parameters.AddWithValue("@Notes", Notes);
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

        public bool AddShirtInfo(string Id, string OrderId, string Length, string Shoulder, string S_Length, string S_Loose, string Chest, string Waist, string Hip, string Collar, string Collar_Size, string Collar_Style, string Cuf_Size, string Cuf_Style, string Collar_Button, string Patti, string Pocket, string InnerPocket, string KneePatch, string Fit, string Notes)
        {
            bool Result = false;
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO ShirtInfo VALUES(@Id,@OrderId,@CreatedDate,@Length,@Shoulder,@S_Length,@S_Loose,@Chest,@Waist,@Hip,@Collar,@Collar_Size,@Collar_Style,@Cuf_Size,@Cuf_Style,@Collar_Button,@Patti,@Pocket,@InnerPocket,@KneePatch,@Fit,@Notes,@ModifiedDate)");
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@OrderId", OrderId);
                cmd.Parameters.AddWithValue("@CreatedDate", System.DateTime.Now);
                cmd.Parameters.AddWithValue("@Length", Length);
                cmd.Parameters.AddWithValue("@Shoulder", Shoulder);
                cmd.Parameters.AddWithValue("@S_Length", S_Length);
                cmd.Parameters.AddWithValue("@S_Loose", S_Loose);
                cmd.Parameters.AddWithValue("@Chest", Chest);
                cmd.Parameters.AddWithValue("@Waist", Waist);
                cmd.Parameters.AddWithValue("@Hip", Hip);
                cmd.Parameters.AddWithValue("@Collar", Collar);
                cmd.Parameters.AddWithValue("@Collar_Size", Collar_Size);
                cmd.Parameters.AddWithValue("@Collar_Style", Collar_Style);
                cmd.Parameters.AddWithValue("@Cuf_Size", Cuf_Size);
                cmd.Parameters.AddWithValue("@Cuf_Style", Cuf_Style);
                cmd.Parameters.AddWithValue("@Collar_Button", Collar_Button);
                cmd.Parameters.AddWithValue("@Patti", Patti);
                cmd.Parameters.AddWithValue("@Pocket", Pocket);
                cmd.Parameters.AddWithValue("@InnerPocket", InnerPocket);
                cmd.Parameters.AddWithValue("@KneePatch", KneePatch);
                cmd.Parameters.AddWithValue("@Fit", Fit);
                cmd.Parameters.AddWithValue("@Notes", Notes);
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

        public bool Update(string Id,string BillNumber, string CustomerName, string Image, string ShopId, int Amount, string CustomerMobileNumber,string Status, string Notes, DateTime StartDate, DateTime EndDate)
        {
            bool Result = false;
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE OrderInfo SET BillNumber=@BillNumber, CustomerName=@CustomerName, Image=@Image, ShopId=@ShopId, Amount=@Amount, CustomerMobileNumber=@CustomerMobileNumber, Status=@Status, Notes=@Notes, StartDate=@StartDate, EndDate=@EndDate, ModifiedDate=@ModifiedDate WHERE Id=@Id");
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@BillNumber", BillNumber);
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

        public bool UpdateSafariInfo(string Id, string OrderId, string Length, string Shoulder, string S_Length, string S_Loose, string Chest, string Waist, string Hip, string Collar, string Collar_Style, string Buttons, string Side_Vent, string S_Breast, string D_Breast, string Breast, string Notes)
        {
            bool Result = false;
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE SafariInfo SET OrderId=@OrderId, Length=@Length, Shoulder=@Shoulder, S_Length=@S_Length, S_Loose=@S_Loose, Chest=@Chest, Waist=@Waist, Hip=@Hip, Collar=@Collar, Collar_Style=@Collar_Style, Buttons=@Buttons, Side_Vent=@Side_Vent, S_Breast=@S_Breast, D_Breast=@D_Breast, Breast=@Breast, Notes=@Notes, ModifiedDate=@ModifiedDate WHERE Id=@Id");
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@OrderId", OrderId);
                cmd.Parameters.AddWithValue("@Length", Length);
                cmd.Parameters.AddWithValue("@Shoulder", Shoulder);
                cmd.Parameters.AddWithValue("@S_Length", S_Length);
                cmd.Parameters.AddWithValue("@S_Loose", S_Loose);
                cmd.Parameters.AddWithValue("@Chest", Chest);
                cmd.Parameters.AddWithValue("@Waist", Waist);
                cmd.Parameters.AddWithValue("@Hip", Hip);
                cmd.Parameters.AddWithValue("@Collar", Collar);
                cmd.Parameters.AddWithValue("@Collar_Style", Collar_Style);
                cmd.Parameters.AddWithValue("@Buttons", Buttons);
                cmd.Parameters.AddWithValue("@Side_Vent", Side_Vent);
                cmd.Parameters.AddWithValue("@S_Breast", S_Breast);
                cmd.Parameters.AddWithValue("@D_Breast", D_Breast);
                cmd.Parameters.AddWithValue("@Breast", Breast);
                cmd.Parameters.AddWithValue("@Notes", Notes);
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

        public bool UpdatePantInfo(string Id, string OrderId, string Length, string Seat, string Hip, string InSeen, string Thigh, string Knee, string Bottom, string BackPocket, string WatchPocket, string Iron, string Emming, string BottomFold, string BuckleModel, string HookButton, string Button, string Notes)
        {
            bool Result = false;
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE PantInfo SET OrderId=@OrderId, Length=@Length, Seat=@Seat, Hip=@Hip, InSeen=@InSeen, Thigh=@Thigh, Knee=@Knee, Bottom=@Bottom, BackPocket=@BackPocket, WatchPocket=@WatchPocket, Iron=@Iron, Emming=@Emming, BottomFold=@BottomFold, BuckleModel=@BuckleModel, HookButton=@HookButton, Button=@Button, Notes=@Notes, ModifiedDate=@ModifiedDate WHERE Id=@Id");
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@OrderId", OrderId);
                cmd.Parameters.AddWithValue("@Length", Length);
                cmd.Parameters.AddWithValue("@Seat", Seat);
                cmd.Parameters.AddWithValue("@Hip", Hip);
                cmd.Parameters.AddWithValue("@InSeen", InSeen);
                cmd.Parameters.AddWithValue("@Thigh", Thigh);
                cmd.Parameters.AddWithValue("@Knee", Knee);
                cmd.Parameters.AddWithValue("@Bottom", Bottom);
                cmd.Parameters.AddWithValue("@BackPocket", BackPocket);
                cmd.Parameters.AddWithValue("@WatchPocket", WatchPocket);
                cmd.Parameters.AddWithValue("@Iron", Iron);
                cmd.Parameters.AddWithValue("@Emming", Emming);
                cmd.Parameters.AddWithValue("@BottomFold", BottomFold);
                cmd.Parameters.AddWithValue("@BuckleModel", BuckleModel);
                cmd.Parameters.AddWithValue("@HookButton", HookButton);
                cmd.Parameters.AddWithValue("@Button", Button);
                cmd.Parameters.AddWithValue("@Notes", Notes);
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

        public bool UpdateShirtInfo(string Id, string OrderId, string Length, string Shoulder, string S_Length, string S_Loose, string Chest, string Waist, string Hip, string Collar, string Collar_Size, string Collar_Style, string Cuf_Size, string Cuf_Style, string Collar_Button, string Patti, string Pocket, string InnerPocket, string KneePatch, string Fit, string Notes)
        {
            bool Result = false;
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE ShirtInfo VALUES OrderId=@OrderId, Length=@Length, Shoulder=@Shoulder, S_Length=@S_Length, S_Loose=@S_Loose, Chest=@Chest, Waist=@Waist, Hip=@Hip, Collar=@Collar, Collar_Size=@Collar_Size, Collar_Style=@Collar_Style, Cuf_Size=@Cuf_Size, Cuf_Style=@Cuf_Style, Collar_Button=@Collar_Button, Patti=@Patti, Pocket=@Pocket, InnerPocket=@InnerPocket, KneePatch=@KneePatch, Fit=@Fit, Notes=@Notes, ModifiedDate=@ModifiedDate WHERE Id=@Id");
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@OrderId", OrderId);
                cmd.Parameters.AddWithValue("@Length", Length);
                cmd.Parameters.AddWithValue("@Shoulder", Shoulder);
                cmd.Parameters.AddWithValue("@S_Length", S_Length);
                cmd.Parameters.AddWithValue("@S_Loose", S_Loose);
                cmd.Parameters.AddWithValue("@Chest", Chest);
                cmd.Parameters.AddWithValue("@Waist", Waist);
                cmd.Parameters.AddWithValue("@Hip", Hip);
                cmd.Parameters.AddWithValue("@Collar", Collar);
                cmd.Parameters.AddWithValue("@Collar_Size", Collar_Size);
                cmd.Parameters.AddWithValue("@Collar_Style", Collar_Style);
                cmd.Parameters.AddWithValue("@Cuf_Size", Cuf_Size);
                cmd.Parameters.AddWithValue("@Cuf_Style", Cuf_Style);
                cmd.Parameters.AddWithValue("@Collar_Button", Collar_Button);
                cmd.Parameters.AddWithValue("@Patti", Patti);
                cmd.Parameters.AddWithValue("@Pocket", Pocket);
                cmd.Parameters.AddWithValue("@InnerPocket", InnerPocket);
                cmd.Parameters.AddWithValue("@KneePatch", KneePatch);
                cmd.Parameters.AddWithValue("@Fit", Fit);
                cmd.Parameters.AddWithValue("@Notes", Notes);
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

        public bool DeleteSafariInfoByOrderId(string OrderId)
        {
            bool Result = false;
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM SafariInfo WHERE OrderId=@OrderId");
                cmd.Parameters.AddWithValue("@OrderId", OrderId);
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

        public bool DeleteShirtInfoByOrderId(string OrderId)
        {
            bool Result = false;
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM ShirtInfo WHERE OrderId=@OrderId");
                cmd.Parameters.AddWithValue("@OrderId", OrderId);
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

        public bool DeletePantiInfoByOrderId(string OrderId)
        {
            bool Result = false;
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM PantInfo WHERE OrderId=@OrderId");
                cmd.Parameters.AddWithValue("@OrderId", OrderId);
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

        public DataTable GetOrderByBillNumber(string BillNumber)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM OrderInfo WHERE BillNumber=@BillNumber");
                cmd.Parameters.AddWithValue("@BillNumber", BillNumber);
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
                    cmd = new SqlCommand("SELECT * FROM OrderInfo WHERE DATEPART(MONTH,StartDate)=DATEPART(MONTH,@FilterDate) and DATEPART(YEAR,StartDate)=DATEPART(YEAR,@FilterDate) and ShopId=@ShopId");
                    cmd.Parameters.AddWithValue("@ShopId", ShopId);
                    cmd.Parameters.AddWithValue("@FilterDate", FilterDate);
                }
                else
                {
                    cmd = new SqlCommand("SELECT * FROM OrderInfo WHERE DATEPART(MONTH,StartDate)=DATEPART(MONTH,@FilterDate) and DATEPART(YEAR,StartDate)=DATEPART(YEAR,@FilterDate)");
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

        public DataTable GetOrdersByCompletedDate(string ShopId, string FilterDate)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd;
                if (!string.IsNullOrEmpty(ShopId))
                {
                    cmd = new SqlCommand("SELECT * FROM OrderInfo WHERE DATEPART(MONTH,EndDate)=DATEPART(MONTH,@FilterDate) and DATEPART(YEAR,EndDate)=DATEPART(YEAR,@FilterDate)and DATEPART(DAY,EndDate)=DATEPART(DAY,@FilterDate) and ShopId=@ShopId");
                    cmd.Parameters.AddWithValue("@ShopId", ShopId);
                    cmd.Parameters.AddWithValue("@FilterDate", FilterDate);
                }
                else
                {
                    cmd = new SqlCommand("SELECT * FROM OrderInfo WHERE DATEPART(MONTH,EndDate)=DATEPART(MONTH,@FilterDate) and DATEPART(YEAR,EndDate)=DATEPART(YEAR,@FilterDate) and DATEPART(DAY,EndDate)=DATEPART(DAY,@FilterDate)");
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

        public DataTable GetShopTodaysOderCount(string ShopId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("select Count(*) as Count from OrderInfo where DATEPART(MONTH,CreatedDate)=DATEPART(MONTH,CURRENT_TIMESTAMP) and DATEPART(YEAR,CreatedDate)=DATEPART(YEAR,CURRENT_TIMESTAMP) and DATEPART(DAY,CreatedDate)=DATEPART(DAY,CURRENT_TIMESTAMP) and ShopId=@ShopId");
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

        public DataTable GetSafariInfoByOrderId(string OrderId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM SafariInfo WHERE OrderId=@OrderId");
                cmd.Parameters.AddWithValue("@OrderId", OrderId);
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

        public DataTable GetPantiInfoByOrderId(string OrderId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM PantInfo WHERE OrderId=@OrderId");
                cmd.Parameters.AddWithValue("@OrderId", OrderId);
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

        public DataTable GetShirtiInfoByOrderId(string OrderId)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM ShirtInfo WHERE OrderId=@OrderId");
                cmd.Parameters.AddWithValue("@OrderId", OrderId);
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