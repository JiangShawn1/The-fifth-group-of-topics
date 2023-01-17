using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 專題.Models.DTOs;
using 專題.Models.EFModels;
using 專題.Models.Services.Interfaces;
using 專題.Models.ViewModels;

namespace 專題.Models.Infrastructures.Repositories
{
	public class OrderRepository : IOrderRepository
	{
		private readonly AppDbContext _db = new AppDbContext();

		public void Create(OrderDto dto)
		{
			Order order = new Order
			{
				Id = dto.Id,
				MemberId = dto.MemberId,
				OrderAddress = dto.OrderAddress,
				OrderStatus = dto.OrderStatus,
				OrderContent = dto.OrderContent,
				OrderNumber = dto.OrderNumber,
				OrderType = dto.OrderType,
				TradeStatus = dto.TradeStatus,
				Amount = dto.Amount,
				ShippingMethod = dto.ShippingMethod,
				UseCoupon = dto.UseCoupon,
				CreateAt = DateTime.Now,
			};
			_db.Orders.Add(order);
			_db.SaveChanges();
		}

		public IEnumerable<OrderDto> Search(int? orderId, string orderNumber)
		{
			IEnumerable<Order> query = _db.Orders.OrderBy(x => x.Id);
			if (orderId.HasValue) query = query.Where(x => x.Id == orderId);
			if (!string.IsNullOrEmpty(orderNumber)) query = query.Where(x => x.OrderNumber.Contains(orderNumber));

			return query.Select(x => x.ToEntity());
		}
		public SelectList BindCouponSelectList()
		{
			return new SelectList(_db.Coupons, "Id", "CouponName");
		}
		public SelectList BindCouponSelectList(int? useCoupon)
		{
			return new SelectList(_db.Coupons, "Id", "CouponName", useCoupon);
		}

		public OrderDto Find(int id)
		{
			return _db.Orders.FirstOrDefault(x => x.Id == id).ToEntity();
		}
		public void Edit(OrderDto dto)
		{
			Order order = _db.Orders.Find(dto.Id);

			order.Id = dto.Id;
			order.MemberId = dto.MemberId;
			order.OrderAddress = dto.OrderAddress;
			order.OrderStatus = dto.OrderStatus;
			order.OrderContent = dto.OrderContent;
			order.OrderNumber = dto.OrderNumber;
			order.OrderType = dto.OrderType;
			order.TradeStatus = dto.TradeStatus;
			order.Amount = dto.Amount;
			order.ShippingMethod = dto.ShippingMethod;
			order.UseCoupon = dto.UseCoupon;

			_db.SaveChanges();
		}
		public void Delete(int id)
		{
			Order order = _db.Orders.Find(id);
			_db.Orders.Remove(order);
			_db.SaveChanges();
		}
	}
}