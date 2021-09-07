using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ShoppingList.Models;

#nullable disable

namespace ShoppingList.Dal
{
    public partial class ShoppingListDatabaseContext : DbContext
    {
        public ShoppingListDatabaseContext()
        {
        }

        public ShoppingListDatabaseContext(DbContextOptions<ShoppingListDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCart { get; set; }

        public virtual DbSet<ShoppingCartProducts> ShoppingCartProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-7Q0LS7U;Database=ShoppingListDatabase;Trusted_Connection=True;");
            }
        }

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
