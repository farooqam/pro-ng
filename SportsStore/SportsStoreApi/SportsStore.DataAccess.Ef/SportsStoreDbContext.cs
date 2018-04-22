using System;
using Microsoft.EntityFrameworkCore;
using SportsStoreApi.DataAccess;

namespace SportsStore.DataAccess.Ef
{
    public class SportsStoreDbContext : DbContext
    {
        private readonly SportsStoreDbContextSettings _settings;

        public SportsStoreDbContext(SportsStoreDbContextSettings settings)
        {
            _settings = settings;
        }
        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_settings.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasMaxLength(100);

                entity.Property(e => e.Price)
                    .IsRequired();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(true);

                entity.HasKey(e => e.ProductId);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsUnicode(false)
                    .HasMaxLength(100);

                entity.HasKey(e => e.Name);
            });

            modelBuilder.Entity<ProductCategorization>(entity =>
            {
                entity.HasOne(e => e.Category)
                    .WithMany(e => e.ProductCategorizations)
                    .HasForeignKey(e => e.Category);

                entity.HasOne(e => e.Product)
                    .WithMany(e => e.ProductCategorizations)
                    .HasForeignKey(e => e.Product);

                entity.HasKey(e => new { e.Category, e.Product});

            });
        }
    }
}
