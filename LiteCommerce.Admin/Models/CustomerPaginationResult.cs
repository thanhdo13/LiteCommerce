using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiteCommerce.Admin.Models
{
    public class CustomerPaginationResult : PaginationResult
    {
        /// <summary>
        /// danh sách khách hàng
        /// </summary>
        public List<Customer> Data { get; set; }
        /// <summary>
        /// tìm kiếm country của khách hàng
        /// </summary>
        public string Country { get; set; }
    }
}