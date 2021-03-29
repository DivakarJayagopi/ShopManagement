using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopManagement.Models
{
    public class Order
    {
        public string Id { get; set; }
        public string CustomerName { get; set; }
        public string Image { get; set; }
        public string ShopId { get; set; }
        public int Amount { get; set; }
        public string CustomerMobileNumber { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}