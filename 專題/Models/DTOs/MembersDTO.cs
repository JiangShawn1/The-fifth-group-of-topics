using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace 專題.Models.ViewModels
{
	public class MembersDTO
	{
		[Required]
		public int Members_Id { get; set; }
		[Required]
		[StringLength(50)]
		public string Name { get; set; }
		[Required]
		[StringLength(50)]
		public string Account { get; set; }
		[Required]
		[StringLength(50)]
		public string Password { get; set; }
		[Required]
		[StringLength(10)]
		public string Phone { get; set; }
		[Required]
		[StringLength(50)]
		public string Mail { get; set; }
		[Required]
		public int State { get; set; }
		[Required]
		public bool Subscription { get; set; }
	}
}