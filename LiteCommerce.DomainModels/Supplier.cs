using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DomainModels
{
    /// <summary>
    /// Nhà cung cấp
    /// </summary>
    public class Supplier
    {/// <summary>
    /// ID Của supplier
    /// </summary>
        public int SupplierID { get; set; }
        /// <summary>
        /// companyName của supplier
        /// 
        /// 
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// contact của supplier
        /// </summary>
        public string ContactName { get; set; }
        /// <summary>
        /// Title của supplier
        /// </summary>
        public string ContactTitle { get; set; }
        /// <summary>
        /// địa chỉ của supplier
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        ///  thành phố của supplier
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Nước của supplier
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// số phone của supplier
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Fax của supplier
        /// </summary>
        public string Fax { get; set; }
        /// <summary>
        /// địa chỉ trang web của supplier
        /// </summary>
        public string HomePage { get; set; }
    }
}
