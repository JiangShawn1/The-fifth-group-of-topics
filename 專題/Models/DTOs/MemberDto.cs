using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 專題.Models.DTOs
{
	public class MemberDto
	{
		public int Id { get; set; }

		public string Account { get; set; }

		public string EncryptedPassword { get; set; }

		public string Password { get; set; }

		public string Mail { get; set; }

		public string Name { get; set; }

		public string Phone { get; set; }

		public bool? Freeze { get; set; }

		public bool? IsConfirmed { get; set; }

		public string ConfirmCode { get; set; }
	}
}