using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DataLayers
{
    /// <summary>
    /// interface của nhà cung cấp
    /// </summary>
    public interface ISupplierDAL
    {
        /// <summary>
        /// Hiển thị danh sách Suppliers, phân trang cà có thể tìm kiếm
        /// </summary>
        /// <param name="page"> trang</param>
        /// <param name="pageSize"> </param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        List<Supplier> List(int page, int pageSize, string searchValue);
        /// <summary>
        /// đếm số dòng tìm kiếm được
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        int Count(string searchValue);
        /// <summary>
        /// lấy ra nhà cung cấp bằng supplierID
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        Supplier Get(int supplierID);
        /// <summary>
        /// Bổ sung 1 supplier , hàn trả về id của supplier được bổ sungg.
        /// Nếu lỗi trả về giá trị nhỏ hơn hoặc bằng 0.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Add(Supplier data);
        /// <summary>
        /// thêm 1 supplier
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        bool Update(Supplier supplierID);
        /// <summary>
        /// Xóa nhiều nhà cung cấp 
        /// </summary>
        /// <param name="supplierIDs"></param>
        /// <returns></returns>
        int Delete(int[] supplierIDs);
    }
}
