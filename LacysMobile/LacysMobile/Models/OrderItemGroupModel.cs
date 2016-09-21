using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LacysMobile.Web.Models
{
    public class OrderItemGroupModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
    }
}