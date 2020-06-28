using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiteCommerce.Admin.Models
{
    public class ProductPaginationResult : PaginationResult
    {
        /// <summary>
        /// thể loại của sản phẩm
        /// </summary>
        public Category Category { get; set; }
        /// <summary>
        /// nhà cung cấp của sản phẩm
        /// </summary>
        public Supplier Supplier { get; set; }
        /// <summary>
        /// các thuộc tính của sản phẩm
        /// </summary>
        public Attributes Attribute { get; set; }
        /// <summary>
        /// danh sách các sản phẩm
        /// </summary>
        public List<Product> Data { get; set; }
    }
}