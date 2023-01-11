using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace 專題.Models.ViewModels
{
	public class Forum_S1MainTopicsBranch1ThreadDTO
	{
		[Required]
		public int id { get; set; }
		[Required]
		public int boardId { get; set; }
		[Required]
		public int essayId { get; set; }
		[Required]
		public int topicState { get; set; }

	
		public int replyNumber { get; set; }
		[Required]
		[StringLength(500)]
		public string replyContent { get; set; }

		public DateTime replyTime { get; set; }
		[Required]
		public int? replyState { get; set; }
		
		public int? replyMemberId { get; set; }
	}
}