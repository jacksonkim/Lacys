using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LacysMobile.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public int CustFK { get; set; }
        public DateTime ShipDate { get; set; }
        public DateTime ExpArrivalDate { get; set; }
        public decimal PurchaseTotal { get; set; }
        public decimal ShipCost { get; set; }
        public decimal OrderCost { get; set; }
        public string ShipType { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

        public Order()
        {
            this.OrderItems = new List<OrderItem>();
        }
        
    }
}
