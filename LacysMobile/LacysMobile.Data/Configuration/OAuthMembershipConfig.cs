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
    public class OAuthMembershipConfig : EntityTypeConfiguration<OAuthMembership>
    {
        public OAuthMembershipConfig()
        {
            this.ToTable("webpages_OAuthMembership");

            this.HasKey(k => new { k.Provider, k.ProviderUserId });

            this.Property(p => p.Provider)
                .HasMaxLength(30).IsRequired();

            this.Property(p => p.ProviderUserId)
                .IsRequired().HasMaxLength(100);

            this.Property(p => p.UserId).IsRequired();
        }
    }
}
