using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DomainModels
{
    /// <summary>
    /// Nhân viên
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// ID của nhân viên
        /// </summary>
        public int EmployeeID { get; set; }
        /// <summary>
        /// họ
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Tên
        /// </summary>
        public string FirstName { get; set; }
        // chức vụ
        public string Title { get; set; }
        // ngày sinh
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// ngày bắt đầu làm
        /// </summary>
        public DateTime HireDate { get; set; }
        /// <summary>
        /// email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        ///  địa chỉ
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// thành phố
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// số điện thoại bàn
        /// </summary>
        public string HomePhone { get; set; }
        /// <summary>
        /// đất nước
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// ghi chú
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        /// ảnh 
        /// </summary>
        public string PhotoPath { get; set; }
        /// <summary>
        /// mật khẩu
        /// </summary>
        public string Password { get; set; }
    }
}
