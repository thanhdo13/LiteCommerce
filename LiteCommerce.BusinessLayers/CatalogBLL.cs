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
    /// quản lý dữ liêu chung của hệ thống như : nhà cung cấp,...
    /// </summary>
    public static class CatalogBLL
    {
        /// <summary>
        /// Hamf phai duoc goi de khoi tao chuc nang tac nhghiep
        /// </summary>
        /// <param name="connectionString"></param>
        public static void Initialize(string connectionString)
        {
            SupplierDB = new DataLayers.SqlServer.SupplierDAL(connectionString);
        }
        #region Khai báo các thuộc tính giao tiếp với DAL
        private static  ISupplierDAL SupplierDB { get; set; }
        #endregion
        #region Khai báo các chức năng xử ký nghiệp vụ
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <param name=""></param>
        /// <returns></returns>
        public static List<Supplier> ListOfSupplier(int page, int pageSize, string searchValue, out int rowCount)
        {
            if (page < 1)
                page = 1;
            if (pageSize < 0)
                pageSize = 20;
            rowCount = SupplierDB.Count(searchValue);
            return SupplierDB.List(page,pageSize,searchValue);
        }
        #endregion
    }
}
