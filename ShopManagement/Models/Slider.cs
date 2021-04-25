using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopManagement.Models
{
    public class Slider
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ShopId { get; set; }
        public List<string> Images { get; set; }
    }

    public class ImageInfo
    {
        public string Id { get; set; }
        public string Image { get; set; }
        public string Type { get; set; }
    }

    public class ImageAdditionalInfo
    {
       public List<ImageInfo> HighQualityImage { get; set; }
       public List<ImageInfo> LowQualityImage { get; set; }
       public List<ImageInfo> MediumQualityImage { get; set; }
    }
}