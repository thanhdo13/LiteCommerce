using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiteCommerce.Admin.Models
{
    public class ProductPaginationResult : PaginationResult
    {
        public Category Category { get; set; }
        public Supplier Supplier { get; set; }
        public Attributes Attribute { get; set; }
        public List<Product> Data { get; set; }
    }
}