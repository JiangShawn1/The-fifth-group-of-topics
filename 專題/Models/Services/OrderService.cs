using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using 專題.Models.DTOs;
using 專題.Models.EFModels;
using 專題.Models.Infrastructures.Repositories;
using 專題.Models.Services.Interfaces;
using 專題.Models.ViewModels;

namespace 專題.Models.Services
{
	public class OrderService
	{
		private readonly IOrderRepository _repository;
		public OrderService(IOrderRepository repository)
		{
			_repository = repository;
		}

		public IEnumerable<OrderDto> Search(int? orderId, string orderNumber)
		{
			return _repository.Search(orderId, orderNumber);
		}

		public (bool IsSuccess, string ErrorMessage) CreateOrder(OrderDto dto)
		{
			// todo 判斷各欄位是否正確

			dto.OrderNumber = Guid.NewGuid().ToString("N");

			_repository.Create(dto);

			return (true, null);
		}

		public (bool IsSuccess, string ErrorMessage) EditOrder(int id, OrderDto orderDto)
		{
			_repository.Edit(orderDto);

			return (true, null);
		}
	}
}