using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Security;


namespace LacysMobile.Web.Models
{
    public class CreditCardModel 
    {
        [Display(Name="Card Type:")]
        public string CardType { get; set; }

        [Display(Name="Expiration:")]
        public int ExpiryMonth { get; set; }
        public int ExpiryYear { get; set; }

        [Required]
        [RegularExpression(@"\d{3}$", ErrorMessage = "Card Security Code must be 3 digits")]
        [Display(Name = "Card Security Code")]
        public string SecurityNo { get; set; }

        [Display(Name = "Card Number:")]
        [Required]
        [RegularExpression(@"\d{16}$", ErrorMessage = "Card number must be 16 digits")]
        public string CreditCardNumber
        { get; set; }
    }
}
