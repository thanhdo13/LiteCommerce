using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DataLayers
{
    /// <summary>
    /// interface của thống kê
    /// </summary>
    public interface IDashboard
    {
        /// <summary>
        /// thống kê số tiền theo năm 
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        Dashboard ThongKeTienTheoNam(int year);
        /// <summary>
        /// Liệt kê các năm có trong order
        /// </summary>
        /// <returns></returns>
        List<int> Year();
    }
}
