using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using 專題.Models.DTOs;

namespace 專題.Models.Services.Interfaces
{
	public interface IMemberRepository
	{
		bool IsExist(string account);
		void Create(RegisterDto dto);

		MemberDto Load(int memberId);
		MemberDto GetByAccount(string account);
		void ActiveRegister(int memberId);

		void Update(MemberDto entity);

		void UpdatePassword(int memberId, string newEncryptedPassword);
	}
}