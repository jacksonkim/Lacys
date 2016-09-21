using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LacysMobile.Models
{
    public class ProductReview
    {
        [Key]
        public int ReviewID { get; set; }
        public int ProductFK { get; set; }
        public int Score { get; set; }
        public int UserFK { get; set; }
        public DateTime ReviewDate { get; set; }
        public string Date { get; set; }
        public string Comments { get; set; }
    }

    
}
