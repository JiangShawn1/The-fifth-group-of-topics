using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using 專題.Models.DTOs;

namespace 專題.Models.ViewModels
{
	
		public class RegisterVM
		{
			public int Id { get; set; }

			[Display(Name = "帳號")]
			[Required]
			[StringLength(30)]
			public string Account { get; set; }

		/// <summary>
		/// 明碼
		/// </summary>
			[Display(Name = "密碼")]
			[Required]
			[StringLength(50)]
			[DataType(DataType.Password)]
			public string Password { get; set; }


			[Display(Name = "確認密碼")]
			[Required]
			[StringLength(50)]
			[Compare(nameof(Password))]
			[DataType(DataType.Password)]
			public string ConfirmPassword { get; set; }

			[Display(Name = "信箱")]
			[Required]
			[StringLength(256)]
			[EmailAddress]
			public string Mail { get; set; }

			[Display(Name = "姓名")]
			[Required]
			[StringLength(30)]
			public string Name { get; set; }

			[Display(Name = "電話")]
			[StringLength(10)]
			public string Phone { get; set; }
		}

		public static class RegisterVMExts
		{
			public static RegisterDto ToRequestDto(this RegisterVM source)
			{
				return new RegisterDto
				{
					Account = source.Account,
					Password = source.Password,
					Mail = source.Mail,
					Name = source.Name,
					Phone = source.Phone
				};
			}
		}
	}
