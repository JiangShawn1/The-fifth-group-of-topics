﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace 專題.Models.ViewModels
{
	public class MembersVM
	{
		public int Members_Id { get; set; }

		public string Name { get; set; }

		public string Phone { get; set; }

		public string Mail { get; set; }

		public int State { get; set; }
	}
}