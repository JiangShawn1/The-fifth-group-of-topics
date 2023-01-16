using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using 專題.Models.EFModels;
using 專題.Models.ViewModels;

namespace 專題.Models.CreatViews
{
	public static class CreateForum_MemberVM{
		public  static Forum_SectionBranchTopicsThread_MembersVM ToFSBTTMVM( Forum_SectionBranchTopicsThread_MembersVM contentCreate)
		{
		return new Forum_SectionBranchTopicsThread_MembersVM
		{
			id = contentCreate.id,

			topicId = contentCreate.topicId,

			topicState = contentCreate.topicState,

			replyNumber = contentCreate.replyNumber,

			replyContent = contentCreate.replyContent,

			replyTime = DateTime.Now,

			replyState = contentCreate.replyState,

			replyMemberId = contentCreate.Members_Id,
		};

	}
	}


}