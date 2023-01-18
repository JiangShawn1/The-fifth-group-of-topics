using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using 專題.Models.DTOs;

namespace 專題.Models.Services.Interfaces
{
	public interface IOrderRepository
	{
		void Create(OrderDto dto);
		SelectList BindCouponSelectList();
		SelectList BindCouponSelectList(int? useCoupon);
		IEnumerable<OrderDto> Search(int? orderId, string orderNumber);
		OrderDto Find(int id);
		void Edit(OrderDto orderDto);
		void Delete(int id);
	}
}
