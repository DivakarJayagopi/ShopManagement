using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopManagement.Models
{
    public class DashBoardCustomClass
    {
        public List<Models.Slider> Sliders { get; set; }
        public List<Models.Order> TodayCompletingOrders { get; set; }
        public List<Models.Order> TomorrowCompletingOrders { get; set; }
        public List<Models.Order> OrderCompletingIn3Days { get; set; }
        public List<Models.Order> OrderCompletingIn4Days { get; set; }
        public List<Models.Order> OrderCompletingIn5Days { get; set; }
    }
}