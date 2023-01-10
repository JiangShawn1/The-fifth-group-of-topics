using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace 專題.Models.EFModels
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("name=AppDbContext")
        {
        }

        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<OnSale> OnSales { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductsImage> ProductsImages { get; set; }
        public virtual DbSet<ProductSize> ProductSizes { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Brand)
                .HasForeignKey(e => e.Brand_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Color>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Color)
                .HasForeignKey(e => e.Color_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.Account)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.Phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.Mail)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.CartItems)
                .WithRequired(e => e.Member)
                .HasForeignKey(e => e.Member_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OnSale>()
                .HasMany(e => e.Brands)
                .WithRequired(e => e.OnSale)
                .HasForeignKey(e => e.OnSale_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.CartItems)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.Product_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Stocks)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.Product_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductsImage>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.ProductsImage)
                .HasForeignKey(e => e.ProductsImages_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductSize>()
                .HasMany(e => e.Stocks)
                .WithRequired(e => e.ProductSize)
                .HasForeignKey(e => e.ProductSize_Id)
                .WillCascadeOnDelete(false);
        }
    }
}
