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
		private readonly ICouponRepository _repository;
		public CouponService(ICouponRepository repository)
		{
			_repository = repository;
		}
		public IEnumerable<CouponDto> Search(int? couponId, string couponName, string couponNumber)
			=> _repository.Search(couponId, couponName, couponNumber);

		public (bool IsSuccess, string ErrorMessage) CreateCoupon(CouponDto dto)
		{
			// todo 判斷各欄位是否正確

			// 判斷帳號是否已存在
			if (_repository.IsExist(dto.CouponName))
			{
				return (false, "優惠券已存在");
			}

			dto.CouponNumber = Guid.NewGuid().ToString("N");

			_repository.Create(dto);

			return (true, null);
		}

		public (bool IsSuccess, string ErrorMessage) EditCoupon(int id, CouponDto dto)
		{
			if (_repository.IsExistWithOutSelf(id, dto.CouponName))
			{
				return (false, "優惠券名稱已存在");
			}

			_repository.Edit(dto);

			return (true, null);
		}
	}
}