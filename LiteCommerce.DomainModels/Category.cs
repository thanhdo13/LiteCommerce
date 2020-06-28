using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DomainModels
{
    /// <summary>
    /// Thể loại
    /// </summary>
    public class Category
    {
        /// <summary>
        /// ID của thể loại
        /// </summary>
        public int CategoryID { get; set; }
        /// <summary>
        /// Tên thể loại
        /// </summary>
        public string CategoryName { get; set; }
        /// <summary>
        /// nội dung
        /// </summary>
        public string Description { get; set; }
    }
}
