using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using 專題.Models.DTOs;
using 專題.Models.EFModels;

namespace 專題.Models.Infrastructures.ExtensionMethods
{
    public static class EmployeeExts
    {
        public static EmployeeDto ToDto(this Employee entity)
        {
            return entity == null
                ? null
                : new EmployeeDto
                {
                    Id = entity.Id,
                    Account = entity.Account,
                    Password = entity.Password,
                    Email = entity.Email,
                    Name = entity.Name,
                    Title = entity.Title,
                    Address = entity.Address,
                    Permission = entity.Permission,
                };
        }
    }
}