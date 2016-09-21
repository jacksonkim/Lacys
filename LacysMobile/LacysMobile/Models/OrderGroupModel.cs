using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LacysMobile.Web.Models
{
    public class OrderGroupModel
    {
        public int OrderCount { get; set; }
        public DateTime ShippingDate { get; set; }
        public string ShortDate { get; set; }
        public List<OrderItemGroupModel> OrderItems { get; set; }
    }
}