using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace 專題.Models.ViewModels
{
	public class ForumSection1DTO
	{
		public int id { get; set; }

		public string sectionName { get; set; }

	
		public string mainBoardAdministrator { get; set; }

		public int mainTopicId { get; set; }

		public int administratorId { get; set; }

		public virtual Member Member { get; set; }
	}
}