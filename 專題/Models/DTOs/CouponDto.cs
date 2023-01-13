using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using 專題.Models.EFModels;

namespace 專題.Models.DTOs
{
	public class CouponDto
	{
		public int Id { get; set; }
		public string CouponName { get; set; }
		public string CouponNumber { get; set; }
		public int CouponType { get; set; }
		public int CouponDiscount { get; set; }
		public string CouponImage { get; set; }
		public string CouponContent { get; set; }
		public DateTime StartAt { get; set; }
		public DateTime? EndAt { get; set; }
	}

	public static partial class CouponExts
	{
		public static CouponDto ToEntity(this Coupon source)
			=> new CouponDto
			{
				Id = source.Id,
				CouponName = source.CouponName,
				CouponNumber = source.CouponNumber,
				CouponType = source.CouponType,
				CouponDiscount = source.CouponDiscount,
				CouponImage = source.CouponImage,
				CouponContent = source.CouponContent,
				StartAt = source.StartAt,
				EndAt = source.EndAt,
			};
	}
}