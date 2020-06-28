using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DomainModels
{
    /// <summary>
    /// Đất nước
    /// </summary>
    public class Country
    {
        /// <summary>
        /// ID của nước
        /// </summary>
        public int CountryID { get; set; }
        /// <summary>
        /// tên của đất nước
        /// </summary>
        public string CountryName { get; set; }
    }
}
