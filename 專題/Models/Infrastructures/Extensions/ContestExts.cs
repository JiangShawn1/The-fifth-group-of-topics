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
		public static List<Contest_Category> ToContest_Category(this ContestCreateVM contestCreateRow)
		{
			List<Contest_Category> list = new List<Contest_Category>();

			for (int i = 0; i < contestCreateRow.QuotaList.Count; i++)
			{
				if (contestCreateRow.EnterFeeList[i] == 0) break;
				list.Add(
					new Contest_Category
					{
						ContestID = contestCreateRow.Id,
						CategoryID = contestCreateRow.CategoryIDList[i],
						Quota = contestCreateRow.QuotaList[i],
						EnterFee = contestCreateRow.EnterFeeList[i],
					});
			}
			return list;
		}
		public static Contest ToContestE(this ContestEditVM contestEditRow)
		{
			return new Contest
			{
				Id = contestEditRow.Id,
				Name = contestEditRow.Name,
				SupplierID = contestEditRow.SupplierID,
				CreateDateTime = contestEditRow.CreateDateTime,
				ContestDate = contestEditRow.ContestDate,
				RegistrationDeadline = contestEditRow.RegistrationDeadline,
				Area = contestEditRow.Area,
				Location = contestEditRow.Location,
				MapURL = contestEditRow.MapURL,
				RegistrationURL = contestEditRow.RegistrationURL,
				Detail = contestEditRow.Detail,
				Review = contestEditRow.Review,

			};
		}
		public static List<Contest_Category> ToContest_CategoryE(this ContestEditVM contestEditRow)
		{
			List<Contest_Category> list = new List<Contest_Category>();
			for (int i = 0; i < contestEditRow.QuotaList.Count; i++)
			{
				if (contestEditRow.EnterFeeList[i] == 0) break;
				list.Add(
					new Contest_Category
					{
						ContestID = contestEditRow.Id,
						Id = contestEditRow.Contest_CategoryIDList[i],
						CategoryID = contestEditRow.CategoryIDList[i],
						Quota = contestEditRow.QuotaList[i],
						EnterFee = contestEditRow.EnterFeeList[i],
					});
			}
			return list;
		}

		public static ContestDetailVM ToContestDetailVM(this Contest contest, List<Contest_Category> cc)
		{
			var EnterFeeList = new List<int>();
			var QuotaList = new List<int>();
			var CategoryList = new List<string>();

			foreach (var item in cc)
			{
				EnterFeeList.Add(item.EnterFee);
				QuotaList.Add(item.Quota);
				CategoryList.Add(item.Category.Category1);
			}

			return new ContestDetailVM
			{
				Id = contest.Id,
				Name = contest.Name,
				SupplierName = contest.Supplier.SupplierName,
				CreateDateTime=contest.CreateDateTime,
				ContestDate=contest.ContestDate,
				RegistrationDeadline=contest.RegistrationDeadline,
				Area=contest.Area,
				Location=contest.Location,
				MapURL=contest.MapURL,
				CategoryList = CategoryList,
				EnterFeeList = EnterFeeList,
				QuotaList = QuotaList,
				RegistrationURL=contest.RegistrationURL,
				Detail=contest.Detail,
				Review=contest.Review,
			};
		}
	}
}