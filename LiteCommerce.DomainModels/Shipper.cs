using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DomainModels
{
    /// <summary>
    /// Người vận chuyển
    /// </summary>
    public class Shipper
    {
        /// <summary>
        /// ID của shipper
        /// </summary>
        public int ShipperID { get; set; }
        /// <summary>
        /// CompanyName của shipper
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// Số phone của shipper
        /// </summary>
        public string Phone { get; set; }
    }
}
