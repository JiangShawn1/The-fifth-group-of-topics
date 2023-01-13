using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using 專題.Models.DTOs;
using 專題.Models.EFModels;
using 專題.Models.Services.Interfaces;

namespace 專題.Models.Infrastructures.Repositories
{
	public class OrderRepository : IOrderRepository
	{
		private readonly AppDbContext _db = new AppDbContext();

		public IEnumerable<OrderDto> Search(int? orderId, string orderNumber)
		{
			IEnumerable <Order> query = _db.Orders;
			if (orderId.HasValue) query = query.Where(x => x.Id == orderId);
			if (!string.IsNullOrEmpty(orderNumber)) query = query.Where(x => x.OrderNumber.Contains(orderNumber));

			return query.Select(x => x.ToEntity());
		}
	}
}