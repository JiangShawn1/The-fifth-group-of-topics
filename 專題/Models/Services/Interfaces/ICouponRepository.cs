using System.Collections.Generic;
using 專題.Models.DTOs;
using 專題.Models.ViewModels;

namespace 專題.Models.Services.Interfaces
{
	public interface ICouponRepository
	{
		void Create(CouponDto model);
		void Delete(int id);
		void Edit(CouponDto dto);
		CouponDto Find(int id);
		bool IsExist(string couponName);
		bool IsExistWithOutSelf(int id, string couponName);
		IEnumerable<CouponDto> Search(int? couponId, string couponName, string couponNumber);
	}
}