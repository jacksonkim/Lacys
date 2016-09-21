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
    public class OrderItemsConfig : EntityTypeConfiguration<OrderItem>
    {
        public OrderItemsConfig()
        {
            this.ToTable("OrderItems");
          
            this.Property(o => o.ItemID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(o => o.OrderFK)
                .IsRequired();

            this.Property(o => o.ProductFK)
                .IsRequired();

            this.Property(o => o.Quantity)
                .IsRequired();

            this.Property(o => o.Cost)
                .IsRequired().HasPrecision(10, 2);

        }
    }
}
