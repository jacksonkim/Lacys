using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LacysMobile.Web.Models
{
    public class UserModel
    {
        [StringLength(40), Required(ErrorMessage = "First Name Required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(40), Required(ErrorMessage = "Last Name Required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [StringLength(300), Required(ErrorMessage = "Address Required")]
        public string Address { get; set; }

        [StringLength(40), Required(ErrorMessage = "City Required")]
        public string City { get; set; }

        public string State { get; set; }

        [StringLength(10), Required(ErrorMessage = "Zip Code Required")]
        [Display(Name = "Zip Code")]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid Zip")]
        public string Zip { get; set; }

        [Required(ErrorMessage="Phone Required")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email Required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Ship to:")]
        public string ShipType { get; set; }
     }
}