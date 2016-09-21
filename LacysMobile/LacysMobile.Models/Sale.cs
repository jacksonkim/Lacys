using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; 

namespace LacysMobile.Models
{
    public class Sale
    {
        [Key]
        public int SaleID { get; set; }
        public int ProductFK { get; set; }
        public int Quantity { get; set; }
        public int UserFK { get; set; }
        public DateTime SaleDate { get; set; }
    }
}
