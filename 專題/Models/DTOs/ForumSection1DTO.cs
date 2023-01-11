using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace 專題.Models.ViewModels
{
	public class ForumSection1DTO
	{
		[Required]
		public int id { get; set; }
		[Required]
		[StringLength(50)]
		public string sectionName { get; set; }

		[Required]
		public string mainBoardAdministrator { get; set; }
		[Required]
		public int mainTopicId { get; set; }
		[Required]
		public int administratorId { get; set; }
	}
}