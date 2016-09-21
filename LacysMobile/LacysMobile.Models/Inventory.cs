using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; 

namespace LacysMobile.Models
{
    public class Inventory
    {
        [Key]
        public int InventoryID { get; set; }
        public int ProductFK { get; set; }
        public int CurrentInventory { get; set; }
    }
}
