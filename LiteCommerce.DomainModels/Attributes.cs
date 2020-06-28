using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DomainModels
{
    /// <summary>
    /// thuộc tính của sản phẩm
    /// </summary>
    public class Attributes
    {
        /// <summary>
        /// ID của thuộc tính
        /// </summary>
        public int AttributeID { get; set; }
        /// <summary>
        /// ID của sản phẩm
        /// </summary>
        public int ProductID { get; set; }
        /// <summary>
        /// Tên thuộc tính
        /// </summary>
        public string AttributeName { get; set; }
        /// <summary>
        /// kích thước
        /// </summary>
        public string Size { get; set; }
        /// <summary>
        /// màu sắc
        /// </summary>
        public string Color { get; set; }
    }
}
