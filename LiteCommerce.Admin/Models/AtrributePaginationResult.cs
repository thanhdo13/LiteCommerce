using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiteCommerce.Admin.Models
{
    public class AtrributePaginationResult : PaginationResult
    {
        /// <summary>
        /// danh sách các attribute
        /// </summary>
        public List<Attributes> Data { get; set; }
    }
}