using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using 專題.Models.EFModels;
using 專題.Models.ViewModels;

namespace 專題.Models.Extensions
{
	public static class Forum_SectionBranch1TopicsThreadExt
	{
		public static Forum_SectionBranch1TopicsThread ToFM(this Forum_SectionBranchTopicsThread_MembersVM fRCreate)
		{
			return new Forum_SectionBranch1TopicsThread
			{
				id = fRCreate.id,

				topicId = fRCreate.topicId,

				topicState = fRCreate.topicState,

				replyNumber = fRCreate.replyNumber,

				replyContent = fRCreate.replyContent,

				replyTime = DateTime.Now,

				replyState = fRCreate.replyState,

				replyMemberId = fRCreate.Members_Id,

			};

		}




	}
}