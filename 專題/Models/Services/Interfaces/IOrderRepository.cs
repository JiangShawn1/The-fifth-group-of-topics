using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 專題.Models.DTOs;

namespace 專題.Models.Services.Interfaces
{
	public interface IOrderRepository
	{
		IEnumerable<OrderDto> Search(int? orderId, string orderNumber);
	}
}
