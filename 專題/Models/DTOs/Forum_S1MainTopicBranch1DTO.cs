using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace 專題.Models.ViewModels
{
	public class Forum_S1MainTopicBranch1DTO
	{
		[Required]
		public int id { get; set; }
		[Required]
		public int boardNameId { get; set; }
		[Required]
		public int essayId { get; set; }
		[Required]
		[StringLength(100)]
		public string essayTopic { get; set; }
		[Required]
		public int State { get; set; }
	}
}