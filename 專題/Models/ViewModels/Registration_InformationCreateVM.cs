using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using 專題.Models.EFModels;

namespace 專題.Models.ViewModels
{
	public class Registration_InformationCreateVM
	{
		//Registration_Information
		public int Id { get; set; }

		public int RegistrationID { get; set; }

		public int InformationID { get; set; }

		public virtual Information Information { get; set; }

		public virtual Registration Registration { get; set; }
		//Registration
		[Display(Name = "報名人")]
		public int MemberID { get; set; }
		[Display(Name = "報名賽事")]
		public int Contest_CategoryID { get; set; }

		public bool PaymentStatus { get; set; }

		public virtual Contest_Category Contest_Category { get; set; }

		public virtual Member Member { get; set; }
		//Information
		[Display(Name = "姓名")]
		public string Name { get; set; }
		[Display(Name = "電話")]
		public string Phone { get; set; }
		[Display(Name = "性別")]
		public bool Gender { get; set; }
		[Display(Name = "地址")]
		public string Address { get; set; }
	}
}