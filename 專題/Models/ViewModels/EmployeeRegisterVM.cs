using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using 專題.Models.DTOs;

namespace 專題.Models.ViewModels
{
    public class EmployeeRegisterVM
    {
        public int Id { get; set; }

        [Display(Name = "帳號")]
        [Required]
        [StringLength(200)]
        public string Account { get; set; }

        [Required]
        [StringLength(200)]
        [DataType(DataType.Password)]
        public string _Password { get; set; }

        [Required]
        [StringLength(50)]
        [Compare(nameof(_Password))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(30)]
        public string Title { get; set; }

        [StringLength(60)]
        public string Address { get; set; }

        [Required]
        [StringLength(200)]
        [EmailAddress]
        public string Email { get; set; }

        public int Permission { get; set; }
    }
    public static class EmployeeRegisterVMExts
    {
        public static EmployeeRegisterDto ToRequestDto(this EmployeeRegisterVM source)
        {
            return new EmployeeRegisterDto
            {
                Account = source.Account,
                _Password = source._Password,
                Email = source.Email,
                Name = source.Name,
                Address = source.Address,
                Title = source.Title,
                Permission = source.Permission
            };
        }
    }
}