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

        public bool Add(string Name, string ShopId)
        {
            bool Result = false;
            try
            {
                string Id = Guid.NewGuid().ToString();
                Result = _sliderData.Add(Id, Name, ShopId);
                List<string> Images = new List<string>() { 
                    "3AD39245-E731-4C3A-9ACC-6A59BB8F2D5B",
                    "87E5D2A5-E88C-4590-98E6-37B59DF84508",
                    "57C7FD8C-BE12-471B-8C99-AA4B7B81F1CF",
                    "26ACECFB-6B75-41C9-8440-C085166C98A1"
                };
                Result = AddSliderConnectorForSlider(Id, Images);
            }
            catch (Exception)
            {

            }
            return Result;
        }

        public bool Update(string Id, List<string> ImageIds)
        {
            bool Result = false;
            try
            {
                //Result = _sliderData.Update(Id, Name);
                if (ImageIds != null && ImageIds.Count > 0)
                {
                    _sliderData.DeleteSliderConnectorBySliderId(Id);
                    Result = AddSliderConnectorForSlider(Id, ImageIds);
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

        public bool AddImages(string Image, string QualityType)
        {
            bool Result = false;
            try
            {
                string Id = Guid.NewGuid().ToString();
                Result = _sliderData.AddImages(Id, Image, QualityType);
            }
            catch (Exception)
            {

            }
            return Result;
        }

        public bool DeleteImages(string[] Ids)
        {
            bool Result = false;
            try
            {
                Result = _sliderData.DeleteImages(Ids);
                if(Result && Ids != null && Ids.Length > 0)
                {
                    foreach (string id in Ids)
                    {
                        DeleteSliderConnectorByImageId(id);
                    }                        
                }
            }
            catch (Exception)
            {

            }
            return Result;
        }

        public List<Models.ImageInfo> GetAllImages()
        {
            List<Models.ImageInfo> ImagesList = new List<Models.ImageInfo>();
            DataTable dt = new DataTable();
            try
            {
                dt = _sliderData.GetAllImages();
                foreach (DataRow record in dt.Rows)
                {
                    Models.ImageInfo image = new Models.ImageInfo();
                    image.Id = record["Id"].ToString();
                    image.Image = record["Image"].ToString();
                    image.Type = record["QualityType"].ToString();
                    ImagesList.Add(image);
                }
            }
            catch (Exception)
            {

            }
            return ImagesList;
        }

        public List<Models.ImageInfo> GetAllImagesByShopId(string ShopId)
        {
            List<Models.ImageInfo> ImagesList = new List<Models.ImageInfo>();
            DataTable dt = new DataTable();
            try
            {
                dt = _sliderData.GetAllImagesByShopId(ShopId);
                foreach (DataRow record in dt.Rows)
                {
                    Models.ImageInfo image = new Models.ImageInfo();
                    image.Id = record["Id"].ToString();
                    image.Image = record["Image"].ToString();
                    image.Type = record["QualityType"].ToString();
                    ImagesList.Add(image);
                }
            }
            catch (Exception)
            {

            }
            return ImagesList;
        }

        public List<string> GetAllImagesBySliderId(string SliderId)
        {
            List<string> Images = new List<string>();
            DataTable dt = new DataTable();
            try
            {
                dt = _sliderData.GetAllImagesBySliderId(SliderId);
                foreach (DataRow record in dt.Rows)
                {
                    var ImageInfo = _sliderData.GetImageById(record["ImageId"].ToString());
                    string ImagePath = "";
                    foreach (DataRow ImageRecord in ImageInfo.Rows)
                    {
                        ImagePath = ImageRecord["Image"].ToString();
                    }
                    Images.Add(ImagePath);
                }
            }
            catch (Exception)
            {

            }
            return Images;
        }

        public List<Models.Slider> GetSliderInfoByShopId(string ShopId)
        {
            List<Models.Slider> sliderslist = new List<Models.Slider>();
            DataTable dt = new DataTable();
            try
            {
                dt = _sliderData.GetSliderInfoByShopId(ShopId);
                foreach (DataRow record in dt.Rows)
                {
                    Models.Slider slider = new Models.Slider();
                    slider.Id = record["Id"].ToString();
                    slider.Name = record["Name"].ToString();
                    slider.ShopId = record["ShopId"].ToString();
                    slider.Images = GetAllImagesBySliderId(record["Id"].ToString()); //Build images for slider
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
                string[] guids = ImageIds[0].Split(',');
                foreach (string Image in guids)
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