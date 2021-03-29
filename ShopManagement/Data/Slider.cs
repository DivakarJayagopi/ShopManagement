using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShopManagement.Data
{
    public class Slider
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString);
        DataTable dt = new DataTable();
        public bool Add(string Id, string Name, string ShopId)
        {
            bool Result = false;
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Slider VALUES(@Id,@Name,@ShopId,@CreatedDate,@ModifiedDate)");
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@ShopId", ShopId);
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

        public bool Update(string Id, string Name)
        {
            bool Result = false;
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE Slider Name=@Name, ModifiedDate=@ModifiedDate WHERE Id=@Id");
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@Name", Name);
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
                SqlCommand cmd = new SqlCommand("DELETE FROM Slider WHERE Id=@Id");
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

        public bool AddImages(string Id, string Image, string ShopId)
        {
            bool Result = false;
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Images VALUES(@Id,@Image,@ShopId,@CreatedDate,@ModifiedDate)");
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@Image", Image);
                cmd.Parameters.AddWithValue("@ShopId", ShopId);
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

        public bool DeleteImages(List<string> Id, string ShopId)
        {
            bool Result = false;
            try
            {
                string appendQuery = "";
                if (Id != null)
                    if (Id.Count > 0)
                    {
                        appendQuery = " WHERE Id IN('" + string.Join("','", Id) + "')";
                    }

                SqlCommand cmd = new SqlCommand("DELETE FROM Images ShopId=@ShopId " + appendQuery);
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@ShopId", ShopId);
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

        public DataTable GetAllImages()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Images");
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

        public DataTable GetAllImagesByShopId(string ShopId)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Images WHERE ShopId=@ShopId");
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

        public DataTable GetSliderInfoByShopId(string ShopId)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT sld.Id as Id, sld.Name as Name, sld.ShopId as ShopId, img.Image as Image FROM SliderConnector sc JOIN Images img ON sc.ImageId = img.Id JOIN Slider sld ON sld.Id = sc.SliderId WHERE ShopId=@ShopId");
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

        public bool AddSliderConnectorForSlider(string SliderId, string ImageId)
        {
            bool Result = false;
            try
            {
                string Id = Guid.NewGuid().ToString();
                SqlCommand cmd = new SqlCommand("INSERT INTO SliderConnector VALUES(@Id,@SliderId,@ImageId,@CreatedDate,@ModifiedDate)");
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@SliderId", SliderId);
                cmd.Parameters.AddWithValue("@ImageId", ImageId);
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

        public bool DeleteSliderConnectorBySliderId(string SliderId)
        {
            bool Result = false;
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM SliderConnector WHERE SliderId=@SliderId");
                cmd.Parameters.AddWithValue("@SliderId", SliderId);
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

        public bool DeleteSliderConnectorByImageId(string ImageId)
        {
            bool Result = false;
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM SliderConnector WHERE ImageId=@ImageId");
                cmd.Parameters.AddWithValue("@ImageId", ImageId);
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
    }
}