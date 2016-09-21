using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LacysMobile.Web.Models
{
    public class ShoppingCartSaleModel
    {
        public int CustomerId { get; set; }
        public DateTime ShippingDate { get; set; }
        public String ShipType { get; set; }        
        public decimal SubTotal { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal OrderTotal { get; set; }
        public decimal SalesTax { get; set; }

        public List<ProductModel> ShoppingCartItems { get; set; }

        public ShoppingCartSaleModel()
        {
            this.ShoppingCartItems = new List<ProductModel>();
        }
    }
}