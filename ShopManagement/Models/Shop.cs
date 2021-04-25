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
        public int TodaysOderCount { get; set; }
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
        public int TodaysOderCount { get; set; }
    }

    public class ShopInfoForChart
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int TotalOrdersCount { get; set; }
        public int AwaitingOrdersCount { get; set; }
        public int InprogressOrdersCount { get; set; }
        public int CompletedOrdersCount { get; set; }
        public int DroppedOrdersCount { get; set; }
        public int TotalAmount { get; set; }
        public int ReceivedAmount { get; set; }
        public int BalanceAmount { get; set; }
    }
}