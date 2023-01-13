using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using 專題.Models.EFModels;

namespace 專題.Models.DTOs
{
	public class OrderDto
	{
		public int Id { get; set; }
		public string OrderNumber { get; set; }
		public int OrderType { get; set; }
		public int OrderStatus { get; set; }
		public int TradeStatus { get; set; }
		public int? UseCoupon { get; set; }
		public int Amount { get; set; }
		public string ShippingMethod { get; set; }
		public string OrderAddress { get; set; }
		public string OrderContent { get; set; }
	}
	public static partial class OrderExts
	{
		public static OrderDto ToEntity(this Order source)
			=> new OrderDto
			{
				Id = source.Id,
				OrderNumber = source.OrderNumber,
				OrderType = source.OrderType,
				OrderStatus = source.OrderStatus,
				TradeStatus = source.TradeStatus,
				UseCoupon = source.UseCoupon,
				Amount = source.Amount,
				ShippingMethod = source.ShippingMethod,
				OrderAddress = source.OrderAddress,
				OrderContent = source.OrderContent,
			};
	}
}