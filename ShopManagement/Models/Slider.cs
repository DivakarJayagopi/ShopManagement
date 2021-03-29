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
}