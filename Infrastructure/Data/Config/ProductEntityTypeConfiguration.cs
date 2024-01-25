using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Entities;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            
            builder.Property(x=> x.Name)
            .HasMaxLength(200)
            .IsRequired();

             builder.Property(x=> x.PictureUrl)
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(x=> x.Description)
            .HasMaxLength(300);

            builder.Property(x=> x.Price)
            .HasColumnType("decimal(18,2)");
        }
    }

    public class ProductTypeEntityTypeConfiguration : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.ToTable("ProductTypes");
            
            builder.Property(x=> x.Name)
            .HasMaxLength(200)
            .IsRequired();
        }
    }

    public class ProductBrandEntityTypeConfiguration : IEntityTypeConfiguration<ProductBrand>
    {
        public void Configure(EntityTypeBuilder<ProductBrand> builder)
        {
            builder.ToTable("ProductBrands");
            
            builder.Property(x=> x.Name)
            .HasMaxLength(200)
            .IsRequired();
        }
    }

}