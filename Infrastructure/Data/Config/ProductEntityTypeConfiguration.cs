using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Entities;
using core.Entities.OrderAggregates;
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

    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.OwnsOne(o => o.ShippedToAddress, a =>
            {
                a.WithOwner();
            });

            builder.HasMany(o => o.OrderItems)
                .WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }


    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItems");

            builder.OwnsOne(o => o.ProductOrderItem, a =>
            {
                a.WithOwner();
            });

            builder.Property(a => a.Price)
                .HasColumnType("decimal(18,2)");
        }
    }

    public class DeliveryMethodConfiguration : IEntityTypeConfiguration<DeliveryMethod>
    {
        public void Configure(EntityTypeBuilder<DeliveryMethod> builder)
        {
            builder.ToTable("DeliveryMethods");

            builder.Property(a => a.Price)
                .HasColumnType("decimal(18,2)");
        }
    }

}