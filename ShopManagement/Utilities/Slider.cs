using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ShopManagement.Utilities
{
    public class Slider
    {
        Data.Slider _sliderData = new Data.Slider();
        DataTable dt = new DataTable();

        public bool Add(string Name, string ShopId)
        {
            bool Result = false;
            try
            {
                string Id = Guid.NewGuid().ToString();
                Result = _sliderData.Add(Id, Name, ShopId);
            }
            catch (Exception)
            {

            }
            return Result;
        }

        public bool Update(string Id, string Name, List<string> ImageIds)
        {
            bool Result = false;
            try
            {
                Result = _sliderData.Update(Id, Name);
                if (Result && ImageIds != null && ImageIds.Count > 0)
                {
                    Result = _sliderData.DeleteSliderConnectorBySliderId(Id);
                    if (Result)
                    {
                        Result = AddSliderConnectorForSlider(Id, ImageIds);
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
                Result = DeleteSliderConnectorBySliderId(Id);
                if (Result)
                {
                    Result = _sliderData.Delete(Id);
                }                
            }
            catch (Exception)
            {

            }
            return Result;
        }

        public bool AddImages(string Id, string Image, string ShopId)
        {
            bool Result = false;
            try
            {
                Result = _sliderData.AddImages(Id, Image, ShopId);
            }
            catch (Exception)
            {

            }
            return Result;
        }

        public bool DeleteImages(List<string> Ids, string ShopId)
        {
            bool Result = false;
            try
            {
                Result = _sliderData.DeleteImages(Ids, ShopId);
                if(Result && Ids != null && Ids.Count > 0)
                {
                    foreach (string id in Ids)
                    {
                        Result = DeleteSliderConnectorByImageId(id);
                    }                        
                }
            }
            catch (Exception)
            {

            }
            return Result;
        }

        public List<string> GetAllImages()
        {
            List<string> ImagesList = new List<string>();
            try
            {
                dt = _sliderData.GetAllImages();
                foreach (DataRow record in dt.Rows)
                {
                    string Image = record["Image"].ToString();
                    if (!string.IsNullOrEmpty(Image))
                    {
                        ImagesList.Add(Image);
                    }
                }
            }
            catch (Exception)
            {

            }
            return ImagesList;
        }

        public List<string> GetAllImagesByShopId(string ShopId)
        {
            List<string> ImagesList = new List<string>();
            try
            {
                dt = _sliderData.GetAllImagesByShopId(ShopId);
                foreach (DataRow record in dt.Rows)
                {
                    string Image = record["Image"].ToString();
                    if (!string.IsNullOrEmpty(Image))
                    {
                        ImagesList.Add(Image);
                    }
                }
            }
            catch (Exception)
            {

            }
            return ImagesList;
        }

        public List<Models.Slider> GetSliderInfoByShopId(string ShopId)
        {
            List<Models.Slider> sliderslist = new List<Models.Slider>();
            try
            {
                dt = _sliderData.GetSliderInfoByShopId(ShopId);
                foreach (DataRow record in dt.Rows)
                {
                    Models.Slider slider = new Models.Slider();
                    slider.Id = record["Image"].ToString();
                    slider.Name = record["Name"].ToString();
                    slider.ShopId = record["ShopId"].ToString();
                    slider.Images = (List<string>)record["Image"];
                    sliderslist.Add(slider);
                }
            }
            catch (Exception)
            {

            }
            return sliderslist;
        }
        

        public bool AddSliderConnectorForSlider(string SliderId,List<string> ImageIds)
        {
            bool result = false;
            try
            {
                foreach (string Image in ImageIds)
                {
                    result = _sliderData.AddSliderConnectorForSlider(SliderId, Image);
                }
            }
            catch (Exception)
            {

            }
            return result;
        }

        public bool DeleteSliderConnectorBySliderId(string SliderId)
        {
            bool result = false;
            try
            {
                result = _sliderData.DeleteSliderConnectorBySliderId(SliderId);
            }
            catch (Exception)
            {

            }
            return result;
        }

        public bool DeleteSliderConnectorByImageId(string SliderId)
        {
            bool result = false;
            try
            {
                result = _sliderData.DeleteSliderConnectorByImageId(SliderId);
            }
            catch (Exception)
            {

            }
            return result;
        }
    }
}