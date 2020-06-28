using LiteCommerce.DataLayers;
using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.BusinessLayers
{
    /// <summary>
    /// Các chứa năng xử lú nghiệp vụ liên quan đến
    /// quản lý dữ liêu : thống kê
    /// </summary>
    public static class DashboardBLL
    {
        /// <summary>
        /// Hamf phai duoc goi de khoi tao chuc nang tac nhghiep
        /// </summary>
        /// <param name="connectionString"></param>
        public static void Initialize(string connectionString)
        {
            DashboardBD = new DataLayers.SqlServer.DashboardDAL(connectionString);

        }
        #region Khai báo các thuộc tính giao tiếp với DAL
       /// <summary>
       /// 
       /// </summary>
        private static IDashboard DashboardBD { get; set; }
        #endregion
        #region Khai báo các chức năng xử ký nghiệp vụ
        /// <summary>
        /// Trả về hàm thống kê tiền theo năm (12 tháng)
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static Dashboard ThongKeTienTheoNam(int year)
        {
            return DashboardBD.ThongKeTienTheoNam(year);
        }
        public static List<int> Year()
        {
            return DashboardBD.Year();
        }
        #endregion
    }
}
