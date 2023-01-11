using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace 專題.Models.ViewModels
{
	public class Forum_S1MainTopicsBranch1ThreadVM
	{
		public int boardId { get; set; }

		public int essayId { get; set; }

		public int replyNumber { get; set; }

		public string replyContent { get; set; }

		public DateTime replyTime { get; set; }

		public int? replyState { get; set; }

		public int? replyMemberId { get; set; }
	}
}