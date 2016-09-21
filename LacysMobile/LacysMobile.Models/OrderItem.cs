using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LacysMobile.Models
{
    public class OrderItem
    {
        [Key]
        public int ItemID { get; set; }
        public int OrderFK { get; set; }
        public int ProductFK { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }       
    }
}
