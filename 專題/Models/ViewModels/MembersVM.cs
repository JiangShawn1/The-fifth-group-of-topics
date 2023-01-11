using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace 專題.Models.ViewModels
{
	public class MembersDTO
	{
		public int Members_Id { get; set; }

		public string Name { get; set; }

		public string Account { get; set; }

		public string Password { get; set; }

		public string Phone { get; set; }

		public string Mail { get; set; }

		public int State { get; set; }

		public bool Subscription { get; set; }
	}
}