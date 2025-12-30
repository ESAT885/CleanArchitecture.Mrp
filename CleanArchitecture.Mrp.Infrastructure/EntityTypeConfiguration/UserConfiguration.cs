using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Mrp.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Mrp.Infrastructure.EntityTypeConfiguration
{
    public class UserConfiguration : BaseEntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(name: "Users");
            builder.Property(e => e.UserName).HasColumnName("UserName").HasMaxLength(100).IsRequired();
            builder.Property(e => e.PasswordHash).HasColumnName("PasswordHash").IsRequired();
            base.Configure(builder);
        }
    }
}
