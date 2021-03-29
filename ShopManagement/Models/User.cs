using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopManagement.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public string Status { get; set; }
        public string Area { get; set; }
        public string Notes { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string MobileNumber { get; set; }
        public int IsAdmin { get; set; }
    }

    public class UserAdditionalInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public string Status { get; set; }
        public string Area { get; set; }
        public string Notes { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string MobileNumber { get; set; }
        public int IsAdmin { get; set; }
        public Shop ShopInfo { get; set; }
    }
}