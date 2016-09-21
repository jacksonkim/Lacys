using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LacysMobile.Web.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal SalePrice { get; set; }
    }
}
