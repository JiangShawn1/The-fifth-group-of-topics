using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 專題.Models.DTOs;

namespace 專題.Models.Services.Interfaces
{
	public interface ICouponRepository
	{
		/// <summary>
		/// 篩選商品
		/// </summary>
		/// <param name="categoryId"></param>
		/// <param name="productName"></param>
		/// <param name="status"></param>
		/// <returns></returns>
		IEnumerable<CouponDto> Search(int? categoryId, string productName, bool? status);
	}
}
