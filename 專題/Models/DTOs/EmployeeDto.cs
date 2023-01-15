using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using 專題.Models.EFModels;

namespace 專題.Models.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public int Permission { get; set; }

    }
}