using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using 專題.Models.DTOs;
using 專題.Models.EFModels;

namespace 專題.Models.Infrastructures.ExtensionMethods
{
	public static class MemberExts
	{
		public static MemberDto ToDto(this Member entity)
		{
			return entity == null
				? null
				: new MemberDto
				{
					Id = entity.Member_Id,
					Account = entity.Account,
					//EncryptedPassword = entity.EncryptedPassword,
					Password = entity.Password,
					Mail = entity.Mail,
					Name = entity.Name,
					Phone = entity.Phone,
					IsConfirmed = entity.IsConfirmed,
					//ConfirmCode = entity.ConfirmCode
			};
		}
	}
}
