using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DomainModels
{
    /// <summary>
    /// Sản phẩm
    /// </summary>
    public class Product
    {
        /// <summary>
        /// ID Của Product
        /// </summary>
        public int ProductID { get; set; }
        /// <summary>
        /// Tên của Product
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// ID của nhà cung cấp
        /// </summary>
        public int SupplierID { get; set; }
        /// <summary>
        /// ID của thể loại
        /// </summary>
        public int CategoryID { get; set; }
        /// <summary>
        /// kích cỡ
        /// </summary>
        public string QuantityPerUnit { get; set; }
        /// <summary>
        /// giá
        /// </summary>
        public long UnitPrice { get; set; }
        /// <summary>
        /// nội dung
        /// </summary>
        public string Descriptions { get; set; }
        /// <summary>
        /// ảnh
        /// </summary>
        public string PhotoPath { get; set; }
    }
}
