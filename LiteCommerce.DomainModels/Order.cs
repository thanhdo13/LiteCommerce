using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DomainModels
{
    /// <summary>
    /// Hóa đơn
    /// </summary>
    public class Order
    {
        /// <summary>
        /// ID của hóa đơn
        /// </summary>
        public int OrderID { get; set; }
        /// <summary>
        /// khách hàng
        /// </summary>
        public string Customer { get; set; }
        /// <summary>
        /// nhân viên
        /// </summary>
        public String Employee { get; set; }
        /// <summary>
        /// ngày lập
        /// </summary>
        public DateTime OrderDate { get; set; }
        /// <summary>
        ///  ngày bắt buộc
        /// </summary>
        public DateTime RequiredDate { get; set; }
        /// <summary>
        /// ngày gửi
        /// </summary>
        public string ShippedDate { get; set; }
        /// <summary>
        /// người gửi
         /// </summary>
        public string Shipper { get; set; }
        /// <summary>
        /// vận chuyển hàng hóa
        /// </summary>
        public long Freight { get; set; }
        /// <summary>
        /// địa chỉ gửi
        /// </summary>
        public string ShipAddress { get; set; }
        /// <summary>
        /// thành phố gửi
        /// </summary>
        public string ShipCity { get; set; }
        /// <summary>
        /// đất nước gửi
        /// </summary>
        public string ShipCountry { get; set; }
    }
}
