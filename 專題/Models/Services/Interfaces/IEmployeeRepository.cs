using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using 專題.Models.DTOs;

namespace 專題.Models.Services.Interfaces
{
    public interface IEmployeeRepository
    {
        bool IsExist(string account);
        void Create(EmployeeRegisterDto dto);

        EmployeeDto Load(int employeeId);
        EmployeeDto GetByAccount(string account);

        void Update(EmployeeDto entity);

        void UpdatePassword(int employeeId, string newEncryptedPassword);
    }
}