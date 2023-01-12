﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using 專題.Models.EFModels;

namespace 專題.Models.ViewModels
{
	public class ContestEditVM
	{
		public ContestEditVM()
		{
			Contest_Category = new HashSet<Contest_Category>();
		}

		public int Id { get; set; }

		[Required]
		[StringLength(50)]
		[Display(Name = "活動名稱")]
		public string Name { get; set; }
		public int SupplierID { get; set; }
		public DateTime CreateDateTime { get; set; }
		[Required]
		[Display(Name = "活動日期")]
		public DateTime ContestDate { get; set; }

		[Required]
		[Display(Name = "報名截止日")]
		public DateTime RegistrationDeadline { get; set; }

		[Required]
		[StringLength(50)]
		[Display(Name = "活動地區")]
		public string Area { get; set; }

		[Required]
		[StringLength(50)]
		[Display(Name = "活動地點")]
		public string Location { get; set; }

		[Required]
		[Display(Name = "地圖資訊")]
		public string MapURL { get; set; }
		public List<int> Contest_CategoryIDList { get; set; }
		[Required]
		[Display(Name = "組別")]
		public List<int> CategoryIDList { get; set; }
		[Required]
		[Display(Name = "名額")]
		public List<int> QuotaList { get; set; }
		[Required]
		[Display(Name = "金額")]
		public List<int> EnterFeeList { get; set; }

		[Required]
		[StringLength(50)]
		[Display(Name = "報名連結")]
		public string RegistrationURL { get; set; }

		[Required]
		[Display(Name = "活動簡章")]
		public string Detail { get; set; }
		[Display(Name = "審核狀態")]
		public bool Review { get; set; }


		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<Contest_Category> Contest_Category { get; set; }


		public virtual Supplier Supplier { get; set; }
	}
}