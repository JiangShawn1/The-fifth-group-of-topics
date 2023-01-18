using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;
using 專題.Models.EFModels;


namespace 專題.Models.ViewModels
{
	public  class Forum_SectionBranchTopicsThread_MembersVM
	{
		public int id { get; set; }

		public int BranchId { get;}
		public int State { get; set; }
		public int topicId { get; set; }

		public int topicState { get; set; }

		public int replyNumber { get; set; }

		[Required]
		[StringLength(500)]
		public string replyContent { get; set; }

		public DateTime replyTime { get; set; }

		public int replyState { get; set; }

		public int? replyMemberId { get; set; }

		public int Members_Id { get; set; }

		[Required]
		[StringLength(50)]
		public string Name { get; set; }

		[Required]
		[StringLength(50)]
		public string Account { get; set; }


		public virtual Forum_SectionBranch1Topics Forum_SectionBranch1Topics { get; set; }

		public virtual Member Member { get; }
	}
}