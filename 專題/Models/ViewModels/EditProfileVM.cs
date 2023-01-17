using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using 專題.Models.DTOs;

namespace 專題.Models.ViewModels
{
	public class EditProfileVM
	{
		public int Member_Id { get; set; }

		[Required]
		[StringLength(256)]
		public string Mail { get; set; }

		[Required]
		[StringLength(30)]
		public string Name { get; set; }

		[StringLength(10)]
		public string Phone { get; set; }
	}

	public static class MemberDtoExts
	{
		public static EditProfileVM ToEditProfileVM(this MemberDto source)
		{
			return new EditProfileVM
			{
				Member_Id = source.Member_Id,
				// Account = source.Account,
				Mail = source.Mail,
				Name = source.Name,
				Phone = source.Phone
			};
		}

		public static UpdateProfileDto ToDto(this EditProfileVM source, string currentUserAccount)
		{
			return new UpdateProfileDto
			{
				//CurrentUserAccount = currentUserAccount,
				Account = currentUserAccount,
				Mail = source.Mail,
				Phone = source.Phone,
				Name = source.Name
			};
		}
	}
}