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
    public class CreditCardConfig : EntityTypeConfiguration<CreditCard>
    {
        public CreditCardConfig()
        {
            this.ToTable("CreditCard");

            this.Property(f => f.CardID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(f => f.UserFK).IsRequired();
            this.Property(f => f.CardType).IsRequired();
            this.Property(f => f.CardNo).IsRequired();
            this.Property(f => f.SecurityNo).IsRequired();
            this.Property(f => f.ExpirationDate).IsRequired();
        }

    }
}