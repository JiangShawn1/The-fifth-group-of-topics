using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using 專題.Models.DTOs;
using 專題.Models.Infrastructures.Repositories;
using 專題.Models.Services.Interfaces;
using 專題.Models.ViewModels;

namespace 專題.Models.Services
{
	public class CouponService
	{
		private readonly CouponRepository _repository;
		public CouponService(CouponRepository repository)
		{
			_repository = repository;
		}
		public IEnumerable<CouponDto> Search(int? couponId, string couponName)
			=> _repository.Search(couponId, couponName);

		public (bool IsSuccess, string ErrorMessage) CreateCoupon(CouponVM model)
		{
			return (true, null);
		}
	}
}