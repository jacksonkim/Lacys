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
    public class InventoryConfig : EntityTypeConfiguration<Inventory>
    {
        public InventoryConfig()
        {
            this.ToTable("Inventory");

            this.Property(p => p.InventoryID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.ProductFK).IsRequired();
            this.Property(p => p.CurrentInventory).IsRequired();
        }
    }
}
