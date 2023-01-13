using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using 專題.Models.DTOs;
using 專題.Models.EFModels;

namespace 專題.Models.ViewModels
{
	public class CouponVM
	{
		public int Id { get; set; }

		[Required]
		[StringLength(50)]
		[Display(Name = "優惠券名稱")]
		public string CouponName { get; set; }

		[StringLength(50)]
		[Display(Name = "序號")]
		public string CouponNumber { get; set; }

		[Display(Name = "類型")]
		public int CouponType { get; set; }

		[Display(Name = "折扣")]
		public int CouponDiscount { get; set; }

		[Display(Name = "圖片")]
		[StringLength(50)]
		public string CouponImage { get; set; }

		[Display(Name = "內容")]
		[StringLength(500)]
		public string CouponContent { get; set; }

		[Display(Name = "開始時間")]
		public DateTime StartAt { get; set; }

		[Display(Name = "結束時間")]
		public DateTime? EndAt { get; set; }
	}
	public static partial class CouponDtoExts
	{
		public static CouponVM ToVM(this CouponDto source)
		{
			return new CouponVM
			{
				Id = source.Id,
				CouponName = source.CouponName,
				CouponNumber = source.CouponNumber,
				CouponContent= source.CouponContent,
				CouponDiscount= source.CouponDiscount,
				CouponImage= source.CouponImage,
				CouponType= source.CouponType,
				StartAt= source.StartAt,
				EndAt= source.EndAt,
			};
		}
		public static CouponDto ToRequestDto(this CouponVM source)
		{
			return new CouponDto
			{
				Id = source.Id,
				CouponName = source.CouponName,
				CouponNumber = source.CouponNumber,
				CouponContent= source.CouponContent,
				CouponDiscount= source.CouponDiscount,
				CouponImage= source.CouponImage,
				CouponType= source.CouponType,
				StartAt= source.StartAt,
				EndAt= source.EndAt,
			};
		}
	}
}