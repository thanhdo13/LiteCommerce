using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DomainModels
{
    /// <summary>
    /// các thành phần của dashbord (12 tháng) thống kê tiền
    /// </summary>
    public class Dashboard
    {
        /// <summary>
        /// Năm 
        /// </summary>
        public long Year { get; set; }
        /// <summary>
        /// tháng 1
        /// </summary>
        public long Jan { get; set; }
        /// <summary>
        /// tháng 2
        /// </summary>
        public long Feb { get; set; }
        /// <summary>
        /// tháng 3
        /// </summary>
        public long Mar { get; set; }
        /// <summary>
        /// tháng 4
        /// </summary>
        public long Apr { get; set; }
        /// <summary>
        /// tháng 5
        /// </summary>
        public long May { get; set; }
        /// <summary>
        /// tháng 6
        /// </summary>
        public long Jun { get; set; }
        /// <summary>
        /// tháng 7
        /// </summary>
        public long Jul { get; set; }
        /// <summary>
        /// tháng 8
        /// </summary>
        public long Aug { get; set; }
        /// <summary>
        /// tháng 9
        /// </summary>
        public long Sep { get; set; }
        /// <summary>
        /// tháng 10
        /// </summary>
        public long Oct { get; set; }
        /// <summary>
        /// tháng 11
        /// </summary>
        public long Nov { get; set; }
        /// <summary>
        /// tháng 12
        /// </summary>
        public long Dec { get; set; }
        /// <summary>
        /// Tổng tiền của 12 tháng
        /// </summary>
        /// <returns></returns>
        public long ToTal()
        {
            return Jan + Feb + Mar + Apr + May + Jun + Jul + Aug + Sep + Dec + Oct + Nov;
        }
    }
}
