using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using 專題.Models.DTOs;
using 專題.Models.EFModels;
using 專題.Models.Infrastructures.ExtensionMethods;

namespace 專題.Models.Services.Interfaces.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private AppDbContext db = new AppDbContext();
        public void Create(EmployeeRegisterDto dto)
        {
            Employee member = new Employee
            {
                Account = dto.Account,
                Password = dto.Password,
                Email = dto.Email,
                Name = dto.Name,
                Title = dto.Title,
                Address = dto.Address,
                Permission = dto.Permission,

            };

            db.Employees.Add(member);
            db.SaveChanges();
        }

        public EmployeeDto Load(int employeeId)
        {
            Employee entity = db.Employees.SingleOrDefault(x => x.Id == employeeId);
            if (entity == null) return null;

            EmployeeDto result = new EmployeeDto
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

            return result;
        }

        public EmployeeDto GetByAccount(string account)
        {
            return db.Employees
                .SingleOrDefault(x => x.Account == account)
                .ToDto();
        }

        public bool IsExist(string account)
        {
            var entity = db.Employees.SingleOrDefault(x => x.Account == account);

            return (entity != null);

        }



        /// <summary>
        /// 更新記錄,本method不會更新密碼
        /// </summary>
        /// <param name="entity"></param>
        public void Update(EmployeeDto entity)
        {
            Employee employee = db.Employees.Find(entity.Id);

            employee.Email = entity.Email;
            employee.Name = entity.Name;
            employee.Title = entity.Title;
            employee.Address = entity.Address;
            employee.Permission = entity.Permission;

            db.SaveChanges();
        }

        public void UpdatePassword(int employeeId, string newEncryptedPassword)
        {
            var employee = db.Employees.Find(employeeId);

            employee.Password = newEncryptedPassword;

            db.SaveChanges();
        }

    }
}