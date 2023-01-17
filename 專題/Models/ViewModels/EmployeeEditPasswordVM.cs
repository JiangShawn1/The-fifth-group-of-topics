using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using 專題.Models.DTOs;

namespace 專題.Models.ViewModels
{
    public class EmployeeEditPasswordVM
    {
        [Display(Name = "原始密碼")]
        [Required]
        [StringLength(50)]
        [DataType(DataType.Password)]
        public string OriginalPassword { get; set; }

        [Display(Name = "新密碼")]
        [Required]
        [StringLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "確認密碼")]
        [Required]
        [StringLength(50)]
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
    public static class EmployeeEditPasswordVMExts
    {
        public static EmployeeChangePasswordRequest ToRequest(this EmployeeEditPasswordVM source, string userAccount)
        {
            return new EmployeeChangePasswordRequest
            {
                CurrentUserAccount = userAccount,
                OriginalPassword = source.OriginalPassword,
                NewPassword = source.Password
            };
        }
    }
}