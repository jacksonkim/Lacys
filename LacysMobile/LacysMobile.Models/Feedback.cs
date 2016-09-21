using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LacysMobile.Models
{
    public class Feedback
    {
        public int FeedbackID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Comments { get; set; }
        public DateTime FeedbackDate { get; set; }
        public string Date { get; set; }
        public bool Responded { get; set; }
    }
}