using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 專題.Models.DTOs
{
	public class UpdateProfileDto
	{
		public string Account { get; set; }
		public string Mail { get; set; }

		public string Name { get; set; }

		public string Phone { get; set; }
	}
}