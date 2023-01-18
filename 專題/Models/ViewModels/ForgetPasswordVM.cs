using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace 專題.Models.ViewModels
{
	public class ForgetPasswordVM
	{
		[Required]
		[StringLength(30)]
		public string Account { get; set; }

		[Required]
		[StringLength(256)]
		public string Email { get; set; }
	}
}