using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 專題.Models.DTOs
{
    public class EmployeeUpdateProfileDto
    {
        public string Account { get; set; }
        public string Email { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }
        public string Address { get; set; }

        public int Permission { get; set; }
    }
}