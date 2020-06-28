﻿using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiteCommerce.Admin.Models
{
    public class CategoryPaginationResult : PaginationResult
    {
        /// <summary>
        /// danh sách các thể loại
        /// </summary>
        public List<Category> Data { get; set; }
    }
}