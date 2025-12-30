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
    public class ProductConfiguration : BaseEntityConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(name: "Products");
            builder.Property(e => e.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();
            builder.Property(e => e.Code).HasColumnName("Code").HasMaxLength(100).IsRequired();
            builder.Property(e => e.StockQuantity).HasDefaultValue(0);
            base.Configure(builder);
        }
    }
}
