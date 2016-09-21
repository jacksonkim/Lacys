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
    class RoleConfig : EntityTypeConfiguration<Role>
    {
        public RoleConfig()
        {
            this.ToTable("webpages_Roles");
            this.Property(p => p.RoleName)
                .HasMaxLength(256).IsRequired();
        }
    }
}
