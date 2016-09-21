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
    public class UserConfig : EntityTypeConfiguration<User>
    {
        public UserConfig()
        {
            this.ToTable("users");

            this.Property(u => u.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(u => u.FirstName)
                .IsOptional().HasMaxLength(150);

            this.Property(u => u.LastName)
                .IsOptional().HasMaxLength(150);

            this.Property(u => u.UserName)
                .IsRequired().HasMaxLength(150);

            this.Property(u => u.AddressLine1)
                .IsOptional().HasMaxLength(500);

            this.Property(u => u.AddressLine2)
                .IsOptional().HasMaxLength(500);

            this.Property(u => u.City)
                .IsOptional().HasMaxLength(100);

            this.Property(u => u.StateProvince)
                .IsOptional().HasMaxLength(2);

            this.Property(u => u.PostalCode)
                .IsOptional().HasMaxLength(16);

            this.Property(u => u.Country)
                .IsOptional().HasMaxLength(150);

            this.Property(u => u.EmailAddress)
                .IsOptional().HasMaxLength(200);

            this.Property(u => u.PhoneNumber)
                .IsOptional().HasMaxLength(22);

            this.Property(u => u.CellNumber)
                .IsOptional().HasMaxLength(22);

            this.Property(u => u.PhoneExtension)
                .IsOptional().HasMaxLength(10);

            this.HasMany(u => u.Roles)
                .WithMany(r => r.Users).Map(m =>
                {
                    m.MapLeftKey("UserId");
                    m.MapRightKey("RoleId");
                    m.ToTable("webpages_UsersInRoles");
                });

        }
    }
}
