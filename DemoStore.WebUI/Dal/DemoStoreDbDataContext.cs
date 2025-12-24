using DemoStore.WebUI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace DemoStore.WebUI
{
    public partial class DemoStoreDbDataContext : DbContext
    {
        public DemoStoreDbDataContext(DbContextOptions<DemoStoreDbDataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if DEBUG
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
#endif
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new CategoryEntityTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
