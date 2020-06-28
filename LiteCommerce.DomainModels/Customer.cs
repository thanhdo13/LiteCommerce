using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DomainModels
{
    /// <summary>
    /// Khách hàng
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// ID của khách hàng
        /// </summary>
        public string CustomerID { get; set; }
        /// <summary>
        ///  tên công ty
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// tên liên lạc
        /// </summary>
        public string ContactName { get; set; }
        /// <summary>
        /// chức vụ
        /// </summary>
        public string ContactTitle { get; set; }
        /// <summary>
        /// địa chỉ
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// thành phố
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// đất nước
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// số điện thoại
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// số Fax
        /// </summary>
        public string Fax { get; set; }
    }
}
