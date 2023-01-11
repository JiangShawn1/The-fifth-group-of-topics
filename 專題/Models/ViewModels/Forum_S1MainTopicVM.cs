using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace 專題.Models.ViewModels
{
	public class Forum_S1MainTopicVM
	{

		public int boardId { get; set; }

		public string boardName { get; set; }

	
		public string boardAdministrator { get; set; }

		public int boardAdministratorId { get; set; }

	}
}