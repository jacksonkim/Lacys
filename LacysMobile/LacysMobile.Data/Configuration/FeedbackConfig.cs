using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LacysMobile.Models;

namespace LacysMobile.Data.Configuration
{
    public class FeedbackConfig : EntityTypeConfiguration<Feedback>
    {
        public FeedbackConfig()
        {
            this.ToTable("feedback");

            this.Property(f => f.FeedbackID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(f => f.FirstName).IsRequired();
            this.Property(f => f.LastName).IsRequired();
            this.Property(f => f.Email).IsRequired();
            this.Property(f => f.Comments).IsRequired();
            this.Property(f => f.FeedbackDate).IsRequired();
            this.Property(f => f.Date).IsOptional();
            this.Property(f => f.Responded).IsRequired();
        }

    }
}
