using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using X.PagedList;
using 專題.Models.EFModels;

namespace 專題.Models.ViewModels
{
	public class PageVM
	{
		// Properties
		public string Name { get; set; } 

		

		public IPagedList<Member> Members { get; set; }  // 符合條件資料


		
	}
}
