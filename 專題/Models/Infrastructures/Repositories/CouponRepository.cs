using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using 專題.Models.DTOs;
using 專題.Models.EFModels;
using 專題.Models.Services.Interfaces;
using 專題.Models.ViewModels;

namespace 專題.Models.Infrastructures.Repositories
{
	public class CouponRepository : ICouponRepository
	{
		private readonly AppDbContext _db = new AppDbContext();

		public IEnumerable<CouponDto> Search(int? couponId, string couponName, string couponNumber)
		{
			IEnumerable<Coupon> query = _db.Coupons.OrderBy(x=>x.Id);
			if (couponId.HasValue) query = query.Where(x => x.Id == couponId);
			if (!string.IsNullOrEmpty(couponName)) query = query.Where(x => x.CouponName.Contains(couponName));
			if (!string.IsNullOrEmpty(couponNumber)) query = query.Where(x => x.CouponNumber.Contains(couponNumber));

			return query.Select(x => x.ToEntity());
		}

		public bool IsExist(string couponName)
		{
			var entity = _db.Coupons.SingleOrDefault(x => x.CouponName == couponName);

			return (entity != null);
		}

		public void Create(CouponDto dto)
		{
			Coupon coupon = new Coupon
			{
				Id = dto.Id,
				CouponNumber = dto.CouponNumber,
				CouponContent = dto.CouponContent,
				CouponName = dto.CouponName,
				CouponDiscount = dto.CouponDiscount,
				CouponType = dto.CouponType,
				CouponImage = dto.CouponImage,
				StartAt = dto.StartAt,
				EndAt = dto.EndAt,
				CreateAt = DateTime.Now,
			};

			_db.Coupons.Add(coupon);
			_db.SaveChanges();
		}
		public bool IsExistWithOutSelf(int id, string couponName)
		{
			var entity = _db.Coupons.Where(x => x.Id != id).SingleOrDefault(x => x.CouponName == couponName);

			return (entity != null);
		}

		public void Edit(CouponDto dto)
		{
			Coupon coupon = _db.Coupons.Find(dto.Id);

			coupon.CouponName = dto.CouponName;
			coupon.CouponDiscount = dto.CouponDiscount;
			coupon.CouponType = dto.CouponType;
			coupon.CouponImage = dto.CouponImage;
			coupon.StartAt = dto.StartAt;
			coupon.EndAt = dto.EndAt;
			coupon.CouponContent = dto.CouponContent;

			_db.SaveChanges();
		}

		public void Delete(int id)
		{
			Coupon coupon = _db.Coupons.Find(id);
			_db.Coupons.Remove(coupon);
			_db.SaveChanges();
		}

		public CouponDto Find(int id)
		{
			return _db.Coupons.FirstOrDefault(x => x.Id == id).ToEntity();
		}
	}
}