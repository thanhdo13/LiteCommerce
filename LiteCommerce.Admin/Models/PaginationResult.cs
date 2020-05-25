using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiteCommerce.Admin.Models
{
    public abstract class PaginationResult
    {/// <summary>
    /// so dong tren 1 trang
    /// </summary>
        public int Page { get; set; }
        
        public int PageSize { get; set; }
        /// <summary>
        /// tong so dong tim duoc
        /// </summary>
        public int RowCount { get; set; }
        /// <summary>
        ///  tim kiem
        /// </summary>
        public string SearchValue { get; set; }
        /// <summary>
        ///  Tong so trang
        /// </summary>
        public int PageCount {
            get
            {
                int p = RowCount / PageSize;
                if (RowCount % PageSize > 0)
                    p += 1;
                return p;
            }
        }
    }
}