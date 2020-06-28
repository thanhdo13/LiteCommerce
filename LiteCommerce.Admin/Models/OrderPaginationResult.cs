using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiteCommerce.Admin.Models
{
    public class OrderPaginationResult : PaginationResult
    {
        /// <summary>
        /// danh sách các hóa đơn
        /// </summary>
        public List<Order> Data { get; set; }
    }
}