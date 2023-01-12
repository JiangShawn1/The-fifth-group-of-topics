using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using 專題.Models.DTOs;
using 專題.Models.EFModels;
using 專題.Models.ViewModels;

namespace 專題.Models.Infrastructures.Repositories
{
	public class CouponRepository
	{
		private readonly AppDbContext _db;

		public CouponRepository(AppDbContext db)
		{
			_db = db;
		}
		public IEnumerable<CouponDto> Search(int? couponId, string couponName/*, bool? status*/)
		{
			IEnumerable<Coupon> query = _db.Coupons;
			if (couponId.HasValue) query = query.Where(x => x.Id == couponId);
			if (!string.IsNullOrEmpty(couponName)) query = query.Where(x => x.CouponName.Contains(couponName));
			//if (status.HasValue) query = query.Where(x => x.Status == status);
			//query = query.OrderBy(x => x.Name);

			return query.Select(x => x.ToEntity());
		}

		public bool IsExist(string couponName)
		{
			var entity = _db.Coupons.SingleOrDefault(x => x.CouponName == couponName);

			return (entity != null);
		}

		public void Create(CouponVM model)
		{
			Coupon coupon = new Coupon
			{
				Id = model.Id,
				CouponName = model.CouponName,
			};

			_db.Coupons.Add(coupon);
			_db.SaveChanges();
		}
	}
}