using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ShoppingList.Core.Models;

#nullable disable

namespace ShoppingList.Dal
{
    public partial class ShoppingListDatabaseContext : DbContext
    {
        public ShoppingListDatabaseContext(){}

        public ShoppingListDatabaseContext(DbContextOptions<ShoppingListDatabaseContext> options)
            : base(options){}

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCart { get; set; }

        public virtual DbSet<ShoppingCartProducts> ShoppingCartProducts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Croatian_CI_AS");

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Name).HasMaxLength(50);
                entity.Property(e => e.IsChecked).IsRequired(true);
                entity.Property(e => e.Price).IsRequired(true);
                entity.Property(e => e.Description).HasMaxLength(50).IsRequired(false);

            });
            modelBuilder.Entity<ShoppingCart>(entity => {
                entity.Property(e => e.Name).IsRequired(true).HasMaxLength(15);
                entity.Property(e => e.ForDate).IsRequired(false);
                entity.Property(e => e.Id);
                
            });

            modelBuilder.Entity<ShoppingCart>().HasKey(e => e.Id);

            modelBuilder.Entity<ShoppingCartProducts>().HasKey(e => new { e.ProductId, e.ShoppingListId });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
