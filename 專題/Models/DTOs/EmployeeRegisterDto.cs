using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using 專題.Models.Infrastructures;

namespace 專題.Models.DTOs
{
    public class EmployeeRegisterDto
    {
        public const string SALT = "!@#$$DGTEGYT";
        public string Account { get; set; }

        /// <summary>
        /// 密碼,明碼
        /// </summary>
        public string _Password { get; set; }

        /// <summary>
        /// 加密之後的密碼
        /// </summary>
        public string Password
        {
            get
            {
                string salt = SALT;
                string result = EmployeeHashUtility.ToSHA256(this._Password, salt);
                return result;
            }
        }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }
        public string Address { get; set; }

        public int Permission { get; set; }
    }
}
