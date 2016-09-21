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
    public class OrderConfig : EntityTypeConfiguration<Order>
    {
        public OrderConfig()
        {
            this.ToTable("Orders");

            this.Property(o => o.OrderID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(o => o.CustFK)
                .IsRequired();

            this.Property(o => o.ShipDate)
                .IsRequired();

            this.Property(o => o.ExpArrivalDate)
                .IsRequired();

            this.Property(o => o.PurchaseTotal)
                .IsRequired().HasPrecision(10, 2);

            this.Property(o => o.ShipCost)
                .IsRequired().HasPrecision(10, 2);

            this.Property(o => o.OrderCost)
                .IsRequired().HasPrecision(10, 2);

            this.HasMany(o => o.OrderItems)
                 .WithRequired().HasForeignKey(i => i.OrderFK);

        }
    }
}
