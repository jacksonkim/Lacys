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
    public class ProductConfig : EntityTypeConfiguration<Product>
    {
        public ProductConfig()
        {
            this.ToTable("products");

            this.Property(p => p.ProductID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(p => p.Name).IsRequired().HasMaxLength(100);

            this.Property(p => p.Description).IsRequired().HasMaxLength(500);

            this.Property(p => p.ItemType).IsRequired().HasMaxLength(100);

            this.Property(p => p.WarehousePrice).IsOptional().HasPrecision(10, 2);

            this.Property(p => p.SellingPrice).IsRequired().HasPrecision(10, 2);

            this.Property(p => p.IsSpecial).IsRequired().HasColumnType("bit");

            this.Property(p => p.IsNew).IsRequired().HasColumnType("bit");

            this.Property(p => p.ImageName).IsRequired().HasMaxLength(150);
            
            this.HasMany(p => p.Reviews)
                .WithRequired().HasForeignKey(r => r.ProductFK);
        }
    }
}
