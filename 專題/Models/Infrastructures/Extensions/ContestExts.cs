using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using 專題.Models.EFModels;
using 專題.Models.ViewModels;

namespace 專題.Models.Infrastructures.Extensions
{
	public static class ContestExts
	{
		public static Contest ToContest(this ContestCreateVM contestCreateRow)
		{
			return new Contest
			{
				Name = contestCreateRow.Name,
				SupplierID = contestCreateRow.SupplierID,
				CreateDateTime = DateTime.Now,
				ContestDate = contestCreateRow.ContestDate,
				RegistrationDeadline = contestCreateRow.RegistrationDeadline,
				Area = contestCreateRow.Area,
				Location = contestCreateRow.Location,
				MapURL = contestCreateRow.MapURL,
				RegistrationURL = contestCreateRow.RegistrationURL,
				Detail = contestCreateRow.Detail,

			};
		}
		public static Contest_Category ToContest_Category(this ContestCreateVM contestCreateRow)
		{
			return new Contest_Category
			{
				ContestID = contestCreateRow.Id,
				CategoryID = contestCreateRow.CategoryIDList.First(),
				Quota = contestCreateRow.QuotaList.First(),
				EnterFee = contestCreateRow.EnterFeeList.First(),
			};
		}
	}
}