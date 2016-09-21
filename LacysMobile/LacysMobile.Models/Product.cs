using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacysMobile.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public string ItemType { get; set; }
        public decimal WarehousePrice { get; set; }
        public decimal SellingPrice { get; set; }
        public bool IsSpecial { get; set; }
        public bool IsNew{ get; set; }
        public ICollection<ProductReview> Reviews { get; set; }
        public Product()
        {
            this.Reviews = new List<ProductReview>();
        }
    }
}
