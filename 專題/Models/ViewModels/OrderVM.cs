using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using 專題.Models.DTOs;
using 專題.Models.EFModels;

namespace 專題.Models.ViewModels
{
	public class OrderVM
	{
		public int Id { get; set; }

		[Display(Name = "會員ID")]
		[Required]
		public int MemberId { get; set; }

		[Display(Name = "訂單編號")]
		[StringLength(50)]
		public string OrderNumber { get; set; }

		[Display(Name = "訂單類型")]
		public int OrderType { get; set; }

		[Display(Name = "訂單狀態")]
		public int OrderStatus { get; set; }

		[Display(Name = "交易狀態")]
		public int TradeStatus { get; set; }

		[Display(Name = "使用優惠券")]
		public int? UseCoupon { get; set; }

		[Display(Name = "金額")]
		public int Amount { get; set; }

		[Display(Name = "運送方式")]
		[StringLength(50)]
		public string ShippingMethod { get; set; }

		[Display(Name = "運送地址")]
		[StringLength(200)]
		public string OrderAddress { get; set; }

		[Display(Name = "訂單內容")]
		[Required]
		[StringLength(500)]
		public string OrderContent { get; set; }

		[Display(Name = "優惠券")]
		public string CouponName { get; set; }
	}
	public static partial class OrderDtoExts
	{
		public static OrderVM ToVM(this OrderDto source)
		{
			return new OrderVM
			{
				Id = source.Id,
				MemberId = source.MemberId,
				OrderAddress = source.OrderAddress,
				OrderContent= source.OrderContent,
				OrderNumber= source.OrderNumber,
				OrderStatus= source.OrderStatus,
				OrderType= source.OrderType,
				ShippingMethod= source.ShippingMethod,
				Amount= source.Amount,
				UseCoupon= source.UseCoupon,
				TradeStatus= source.TradeStatus,
				CouponName = source.CouponName,
			};
		}
		public static OrderDto ToRequestDto(this OrderVM source)
		{
			return new OrderDto
			{
				Id = source.Id,
				MemberId = source.MemberId,
				OrderAddress = source.OrderAddress,
				OrderContent= source.OrderContent,
				OrderNumber= source.OrderNumber,
				OrderStatus= source.OrderStatus,
				OrderType= source.OrderType,
				ShippingMethod= source.ShippingMethod,
				Amount= source.Amount,
				UseCoupon= source.UseCoupon,
				TradeStatus= source.TradeStatus,
				CouponName = source.CouponName,
			};
		}
	}
}