using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using 專題.Models.DTOs;
using 專題.Models.EFModels;
using 專題.Models.Infrastructures.ExtensionMethods;
using 專題.Models.Services.Interfaces;

namespace 專題.Models.Infrastructures.Repositories
{
	public class MemberRepository : IMemberRepository
	{
		private AppDbContext db = new AppDbContext();
		public void Create(RegisterDto dto)
		{
			Member member = new Member
			{
				Account = dto.Account,
				Password = dto.Password,
				Mail = dto.Mail,
				Name = dto.Name,
				Phone = dto.Phone,
				IsConfirmed = false, //預設是未確認的會員
				//ConfirmCode = dto.ConfirmCode
			};

			db.Members.Add(member);
			db.SaveChanges();
		}

		public MemberDto Load(int memberId)
		{
			Member entity = db.Members.SingleOrDefault(x => x.Member_Id == memberId);
			if (entity == null) return null;

			MemberDto result = new MemberDto
			{
				Id = entity.Member_Id,
				Account = entity.Account,
				Password = entity.Password,
				Mail = entity.Mail,
				Name = entity.Name,
				Phone = entity.Phone,
				IsConfirmed = entity.IsConfirmed,
				//ConfirmCode = entity.ConfirmCode
			};

			return result;
		}

		public MemberDto GetByAccount(string account)
		{
			return db.Members
				.SingleOrDefault(x => x.Account == account)
				.ToDto();
		}

		public bool IsExist(string account)
		{
			var entity = db.Members.SingleOrDefault(x => x.Account == account);

			return (entity != null);

		}

		public void ActiveRegister(int memberId)
		{
			var member = db.Members.Find(memberId);
			member.IsConfirmed = true;
			//member.ConfirmCode = null;
			db.SaveChanges();
		}

		/// <summary>
		/// 更新記錄,本method不會更新密碼
		/// </summary>
		/// <param name="entity"></param>
		public void Update(MemberDto entity)
		{
			Member member = db.Members.Find(entity.Id);

			member.Mail = entity.Mail;
			member.Name = entity.Name;
			member.Phone = entity.Phone;
			// 在忘記密碼時, 使用者請求重設密碼, 會叫用本method,所以以下二個屬性也要更新
			//member.IsConfirmed = entity.IsConfirmed;
			//member.ConfirmCode = entity.ConfirmCode;

			db.SaveChanges();
		}

		public void UpdatePassword(int memberId, string newEncryptedPassword)
		{
			var member = db.Members.Find(memberId);

			//member.EncryptedPassword = newEncryptedPassword;
			member.Password = newEncryptedPassword;


			db.SaveChanges();
		}
	}
}