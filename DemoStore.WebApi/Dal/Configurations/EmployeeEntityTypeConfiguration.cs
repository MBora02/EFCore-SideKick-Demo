using DemoStore.WebApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace DemoStore.WebApi
{
    public class EmployeeEntityTypeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder
                .HasKey(x => x.EmployeeId)
                .HasName("PK_Employee");

            builder
                .Property(x => x.EmployeeId)
                .HasColumnName("EmployeeId")
                .HasColumnType("int")
                .HasPrecision(10, 0);

            builder
                .Property(x => x.EmployeeName)
                .HasColumnName("EmployeeName")
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsUnicode(true);

            builder
                .Property(x => x.EmployeeSurname)
                .HasColumnName("EmployeeSurname")
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsUnicode(true);

            builder
                .Property(x => x.EmployeeSalary)
                .HasColumnName("EmployeeSalary")
                .HasColumnType("decimal")
                .HasPrecision(18, 2);

            builder
                .Property(x => x.EmployeeDepartment)
                .HasColumnName("EmployeeDepartment")
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsUnicode(true);

            builder
                .Property(x => x.EmployeeStatus)
                .HasColumnName("EmployeeStatus")
                .HasColumnType("bit");

            builder
                .ToTable("Employee", "dbo");
        }
    }
}
