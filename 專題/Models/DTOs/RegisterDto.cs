using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using 專題.Models.Infrastructures;

namespace 專題.Models.DTOs
{/// <summary>
 /// 從Controller 傳給Service object 的物件, 不含confirm password
 /// </summary>
	public class RegisterDto
	{
		public const string SALT = "!@#$$DGTEGYT";
		public string Account { get; set; }

		/// <summary>
		/// 密碼,明碼
		/// </summary>
		public string Password { get; set; }

		/// <summary>
		/// 加密之後的密碼
		/// </summary>
		public string EncryptedPassword
		{
			get
			{
				string salt = SALT;
				string result = HashUtility.ToSHA256(this.Password, salt);
				return result;
			}
		}

		public string Mail { get; set; }

		public string Name { get; set; }

		public string Phone { get; set; }

		public string ConfirmCode { get; set; }
	}
}