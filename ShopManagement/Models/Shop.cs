using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopManagement.Models
{
    public class Shop
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ShopArea { get; set; }
        public string Image { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string MobileNumber { get; set; }
        public int MaxOrderCount { get; set; }
    }

    public class ShopAdditionalInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ShopArea { get; set; }
        public string Image { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string MobileNumber { get; set; }
        public int MaxOrderCount { get; set; }
        public User UserInfo { get; set; }
    }
}