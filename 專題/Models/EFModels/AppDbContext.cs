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

		public virtual DbSet<Coupon> Coupons { get; set; }
		public virtual DbSet<Order> Orders { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Coupon>()
				.Property(e => e.CouponNumber)
				.IsUnicode(false);

			modelBuilder.Entity<Coupon>()
				.HasMany(e => e.Orders)
				.WithOptional(e => e.Coupon)
				.HasForeignKey(e => e.UseCoupon);

			modelBuilder.Entity<Order>()
				.Property(e => e.OrderNumber)
				.IsUnicode(false);
		}

		public System.Data.Entity.DbSet<專題.Models.ViewModels.CouponVM> CouponVMs { get; set; }

		public System.Data.Entity.DbSet<專題.Models.ViewModels.OrderVM> OrderVMs { get; set; }
	}
}
