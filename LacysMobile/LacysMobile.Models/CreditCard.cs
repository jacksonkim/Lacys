using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LacysMobile.Models
{
    public class CreditCard
    {
        [Key]
        public int CardID { get; set; }
        public int UserFK { get; set; }
        public int CardType { get; set; }
        public string CardNo { get; set; }
        public int SecurityNo { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}