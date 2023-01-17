using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 專題.Models.DTOs
{
	public class ChangePasswordRequest
	{
		public string CurrentUserAccount { get; set; }
		public string NewPassword { get; set; }
		public string OriginalPassword { get; set; }
	}
}