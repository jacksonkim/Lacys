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
    public class ProductReviewConfig : EntityTypeConfiguration<ProductReview>
    {
        public ProductReviewConfig()
        {
            this.ToTable("productreviews");

            this.Property(p => p.ReviewID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.UserFK).IsRequired();
            this.Property(p => p.Score).IsRequired();
            this.Property(p => p.ReviewDate).IsRequired();
            this.Property(p => p.Comments).IsOptional().HasMaxLength(500);
        }

    }
}
