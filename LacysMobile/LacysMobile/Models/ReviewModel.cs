using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LacysMobile.Models
{
    public class ReviewModel
    {
        [Display(Name = "Score:")]
        public string Score
        { set; get; }
       
        [Required(ErrorMessage = "Comment Required")]
        [Display(Name = "Comment:")]
        public string Comments { get; set; }
    }

    public static class ReviewModelProductId
    {
        public static int ProductId { get; set; }
    }
}