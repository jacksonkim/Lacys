﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LacysMobile.Models;

namespace LacysMobile.Data.Configuration
{
    public class MembershipConfig : EntityTypeConfiguration<Membership>
    {
        public MembershipConfig()
        {
            this.ToTable("webpages_Membership");
            this.HasKey(p => p.UserId);

            this.Property(p => p.UserId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(p => p.ConfirmationToken)
                .HasMaxLength(128);

            this.Property(p => p.PasswordFailuresSinceLastSuccess)
                .IsRequired();

            this.Property(p => p.Password)
                .IsRequired().HasMaxLength(128);

            this.Property(p => p.PasswordSalt)
                .IsRequired().HasMaxLength(128);

            this.Property(p => p.PasswordVerificationToken)
                .HasMaxLength(128);
        }
    }
}
