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
        public SafariInfo SafariInfo { get; set; }
        public PantInfo PantInfo { get; set; }
        public ShirtInfo ShirtInfo { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string DaysRemaining { get; set; }
        public string ShopName { get; set; }
        public string StartDateInString { get; set; }
        public string EndDateInString { get; set; }
    }

    public class SafariInfo
    {
        public string Id { get; set; }
        public string OrderId { get; set; }
        public string CreatedDate { get; set; }
        public string Length { get; set; }
        public string Shoulder { get; set; }
        public string S_Length { get; set; }
        public string S_Loose { get; set; }
        public string Chest { get; set; }
        public string Waist { get; set; }
        public string Hip { get; set; }
        public string Collar { get; set; }
        public string Collar_Style { get; set; }
        public string Buttons { get; set; }
        public string Side_Vent { get; set; }
        public string S_Breast { get; set; }
        public string D_Breast { get; set; }
        public string Breast { get; set; }
        public string Notes { get; set; }
        public string ModifiedDate { get; set; }
    }

    public class PantInfo
    {
        public string Id { get; set; }
        public string OrderId { get; set; }
        public string CreatedDate { get; set; }
        public string Length { get; set; }
        public string Seat { get; set; }
        public string Hip { get; set; }
        public string InSeen { get; set; }
        public string Thigh { get; set; }
        public string Knee { get; set; }
        public string Bottom { get; set; }
        public string BackPocket { get; set; }
        public string WatchPocket { get; set; }
        public string Iron { get; set; }
        public string Emming { get; set; }
        public string BottomFold { get; set; }
        public string BuckleModel { get; set; }
        public string HookButton { get; set; }
        public string Button { get; set; }
        public string Notes { get; set; }
        public string ModifiedDate { get; set; }
    }

    public class ShirtInfo
    {
        public string Id { get; set; }
        public string OrderId { get; set; }
        public string CreatedDate { get; set; }
        public string Length { get; set; }
        public string Shoulder { get; set; }
        public string S_Length { get; set; }
        public string S_Loose { get; set; }
        public string Chest { get; set; }
        public string Waist { get; set; }
        public string Hip { get; set; }
        public string Collar { get; set; }
        public string Collar_Size { get; set; }
        public string Collar_Style { get; set; }
        public string Cuf_Size { get; set; }
        public string Cuf_Style { get; set; }
        public string Collar_Button { get; set; }
        public string Patti { get; set; }
        public string Pocket { get; set; }
        public string InnerPocket { get; set; }
        public string KneePatch { get; set; }
        public string Fit { get; set; }
        public string Notes { get; set; }
        public string ModifiedDate { get; set; }
    }
}