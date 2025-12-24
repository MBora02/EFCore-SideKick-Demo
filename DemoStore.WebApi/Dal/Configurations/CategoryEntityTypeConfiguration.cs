using DemoStore.WebApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace DemoStore.WebApi
{
    public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .HasKey(x => x.CategoryId)
                .HasName("PK_Category");

            builder
                .Property(x => x.CategoryId)
                .HasColumnName("CategoryId")
                .HasColumnType("int")
                .HasPrecision(10, 0);

            builder
                .Property(x => x.CategoryName)
                .HasColumnName("CategoryName")
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsUnicode(true);

            builder
                .Property(x => x.CategoryStatus)
                .HasColumnName("CategoryStatus")
                .HasColumnType("bit");

            builder
                .ToTable("Category", "dbo");
        }
    }
}
