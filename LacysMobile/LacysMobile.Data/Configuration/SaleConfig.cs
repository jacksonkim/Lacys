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
    public class SaleConfig : EntityTypeConfiguration<Sale>
    {
        public SaleConfig()
        {
            this.ToTable("Sales");

            this.Property(p => p.SaleID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.ProductFK).IsRequired();
            this.Property(p => p.Quantity).IsRequired();
            this.Property(p => p.UserFK).IsRequired();
            this.Property(p => p.SaleDate).IsRequired();
        }
    }
}
