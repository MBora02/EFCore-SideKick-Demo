using DemoStore.WebApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace DemoStore.WebApi
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasKey(x => x.ProductId)
                .HasName("PK_Product");

            builder
                .HasOne(x => x.Category)
                .WithMany(x => x.Categories)
                .HasForeignKey(x => x.CategoryId)
                .HasConstraintName("FK_Product_Category")
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.ProductId)
                .HasColumnName("ProductId")
                .HasColumnType("int")
                .HasPrecision(10, 0);

            builder
                .Property(x => x.ProductName)
                .HasColumnName("ProductName")
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsUnicode(true);

            builder
                .Property(x => x.ProductPrice)
                .HasColumnName("ProductPrice")
                .HasColumnType("decimal")
                .HasPrecision(18, 2);

            builder
                .Property(x => x.ProductStock)
                .HasColumnName("ProductStock")
                .HasColumnType("int")
                .HasPrecision(10, 0);

            builder
                .Property(x => x.ProductStatus)
                .HasColumnName("ProductStatus")
                .HasColumnType("bit");

            builder
                .ToTable("Product", "dbo");
        }
    }
}
