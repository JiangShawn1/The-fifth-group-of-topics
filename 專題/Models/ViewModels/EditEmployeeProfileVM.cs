using Microsoft.Owin.BuilderProperties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using 專題.Models.DTOs;

namespace 專題.Models.ViewModels
{
    public class EditEmployeeProfileVM
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Email { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(30)]
        public string Title { get; set; }
        [StringLength(60)]
        public string Address { get; set; }
        public int Permission { get; set; }
    }
    public static class EmployeeDtoExts
    {
        public static EditEmployeeProfileVM ToEditProfileVM(this EmployeeDto source)
        {
            return new EditEmployeeProfileVM
            {
                Id = source.Id,
                // Account = source.Account,
                Email = source.Email,
                Name = source.Name,
                Permission = source.Permission,
                Address = source.Address,
                Title = source.Title,
            };
        }

        public static EmployeeUpdateProfileDto ToDto(this EditEmployeeProfileVM source, string currentUserAccount)
        {
            return new EmployeeUpdateProfileDto
            {
                //CurrentUserAccount = currentUserAccount,
                Email = source.Email,
                Name = source.Name,
                Permission = source.Permission,
                Address = source.Address,
                Title = source.Title,
            };
        }
    }
}