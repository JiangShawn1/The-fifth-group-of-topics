using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace 專題.Models.ViewModels
{
	public class Forum_S1MainTopicDTO
	{
		[Required]
		public int id { get; set; }
		[Required]
		public int boardId { get; set; }
		[Required]
		[StringLength(100)]
		public string boardName { get; set; }

		[Required]
		public string boardAdministrator { get; set; }
		[Required]
		public int boardAdministratorId { get; set; }

	}
}