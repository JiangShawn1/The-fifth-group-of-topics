using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using 專題.Models.DTOs;
using 專題.Models.Infrastructures;
using 專題.Models.Services.Interfaces;

namespace 專題.Models.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository repository;
        public EmployeeService(IEmployeeRepository repo)
        {
            this.repository = repo;
        }

        public (bool IsSuccess, string ErrorMessage) CreateNewEmployee(EmployeeRegisterDto dto)
        {
            // todo 判斷各欄位是否正確

            // 判斷帳號是否已存在
            if (repository.IsExist(dto.Account))
            {
                return (false, "帳號已存在");
            }

            #region 建立一個會員記錄


            repository.Create(dto);

            #endregion

            return (true, null);
        }


        public (bool IsSuccess, string ErrorMessage) Login(string account, string password)
        {
            EmployeeDto employee = repository.GetByAccount(account);

            if (employee == null)
            {
                return (false, "帳密有誤");
            }

            

            string encryptedPwd = EmployeeHashUtility.ToSHA256(password, EmployeeRegisterDto.SALT);

            return (String.CompareOrdinal(employee.Password, encryptedPwd) == 0)
                ? (true, null)
                : (false, "帳密有誤");
        }

        public void UpdateProfile(EmployeeUpdateProfileDto request)
        {
            // todo 驗證傳入的屬性值是否正確

            // 取得在db裡的原始記錄
            EmployeeDto entity = repository.GetByAccount(request.Account);
            if (entity == null) throw new Exception("找不到要修改的會員記錄");

            // 更新記錄
            entity.Name = request.Name;
            entity.Email = request.Email;
            entity.Title = request.Title;
            entity.Account = request.Account;
            entity.Address = request.Address;
            entity.Permission = request.Permission;

            repository.Update(entity);

        }

        public void ChangePassword(EmployeeChangePasswordRequest request)
        {
            // todo 驗證傳入的屬性值是否正確

            // 取得在db裡的原始記錄
            EmployeeDto entity = repository.GetByAccount(request.CurrentUserAccount);
            if (entity == null) throw new Exception("找不到要修改的會員記錄");

            // 判斷原始密碼是否相同
            string encryptedPassword = EmployeeHashUtility.ToSHA256(request.OriginalPassword, EmployeeRegisterDto.SALT);

            bool isSamePassword = string.Compare(encryptedPassword, entity.Password) == 0;

            if (!isSamePassword) throw new Exception("原始密碼不符,無法變更");

            // 更新記錄
            var newEncryptedPassword = EmployeeHashUtility.ToSHA256(request.NewPassword, EmployeeRegisterDto.SALT);

            repository.UpdatePassword(entity.Id, newEncryptedPassword);
        }

  

        /// <summary>
        /// 重設密碼
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="confirmCode"></param>
        /// <param name="newPassword"></param>
        /// <exception cref="Exception"></exception>
        public void ResetPassword(int memberId, string confirmCode, string plainTextPassword)
        {
            // todo 檢查傳入參數值是否合理


            string encryptedPassword = EmployeeHashUtility.ToSHA256(plainTextPassword, EmployeeRegisterDto.SALT);

            EmployeeDto entity = repository.Load(memberId);
            // 檢查有沒有記錄
            if (entity == null) throw new Exception("找不到對應的會員記錄");



            // 更新密碼
            repository.UpdatePassword(memberId, encryptedPassword);

            repository.Update(entity);
        }
    }
}