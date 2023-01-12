using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace 專題.Models.ViewModels
{
	public class SendEmailVM
	{
		[Required]
		[EmailAddress]
		public string _emailTo { get; set; }

		[Required]
		public string _subject { get; set; }

		[Required]
		public string _body { get; set; }
	}
}