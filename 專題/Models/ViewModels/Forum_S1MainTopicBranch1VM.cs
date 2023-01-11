using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace 專題.Models.ViewModels
{
	public class Forum_S1MainTopicBranch1VM
	{
		public int id { get; set; }

		public int boardNameId { get; set; }

		public int essayId { get; set; }

		public string essayTopic { get; set; }

		public int State { get; set; }
	}
}