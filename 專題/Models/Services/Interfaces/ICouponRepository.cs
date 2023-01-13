using System.Collections.Generic;
using 專題.Models.DTOs;
using 專題.Models.ViewModels;

namespace 專題.Models.Services.Interfaces
{
	public interface ICouponRepository
	{
		void Create(CouponDto model);
		void Edit(CouponDto dto);
		bool IsExist(string couponName);
		bool IsExistWithOutSelf(int id, string couponName);
		IEnumerable<CouponDto> Search(int? couponId, string couponName, string couponNumber);
	}
}