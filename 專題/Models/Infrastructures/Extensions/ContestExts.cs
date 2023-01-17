using System;
using System.Collections.Generic;
using System.Data.Entity;
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

		public static Registration_Information ToRI(this Registration_InformationCreateVM VM)
		{
			return new Registration_Information
			{
				InformationID = VM.InformationID,
				RegistrationID = VM.RegistrationID,
			};
		}

		public static Registration ToRe(this Registration_InformationCreateVM VM)
		{
			return new Registration
			{
				MemberID= VM.MemberID,
				Contest_CategoryID= VM.Contest_CategoryID,
			};
		}

		public static Information ToIn(this Registration_InformationCreateVM VM)
		{
			return new Information
			{
				Name= VM.Name,
				Phone= VM.Phone,
				Gender= VM.Gender,
				Address= VM.Address,
			};
		}

		public static Registration_InformationEditVM ToRIEditVM(this Registration_Information RI,Registration registration, Information information)
		{
			return new Registration_InformationEditVM
			{
				Id = RI.Id,
				InformationID = information.Id,
				RegistrationID = registration.Id,
				MemberID = registration.MemberID,
				Contest_CategoryID = registration.Contest_CategoryID,
				PaymentStatus = registration.PaymentStatus,
				Name = information.Name,
				Phone = information.Phone,
				Gender = information.Gender,
				Address = information.Address,
			};
		}

		public static Registration_Information ToRIE(this Registration_InformationEditVM VM) 
		{
			return new Registration_Information
			{
				Id = VM.Id,
				InformationID = VM.InformationID,
				RegistrationID = VM.RegistrationID,
			};
		}
		public static Registration ToReE(this Registration_InformationEditVM VM)
		{
			return new Registration
			{
				Id= VM.RegistrationID,
				MemberID = VM.MemberID,
				Contest_CategoryID = VM.Contest_CategoryID,
				PaymentStatus = VM.PaymentStatus,
			};
		}

		public static Information ToInE(this Registration_InformationEditVM VM)
		{
			return new Information
			{
				Id = VM.InformationID,
				Name = VM.Name,
				Phone = VM.Phone,
				Gender = VM.Gender,
				Address = VM.Address,
			};
		}
	}
}