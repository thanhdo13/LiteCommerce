using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DataLayers
{
    /// <summary>
    /// interface của shipper
    /// </summary>
    public interface IShipperDAL
    {
        /// <summary>
        /// Hiển thị danh sách Suppliers, phân trang cà có thể tìm kiếm
        /// </summary>
        /// <param name="page"> trang</param>
        /// <param name="pageSize"> </param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        List<Shipper> List(int page, int pageSize, string searchValue);
        /// <summary>
        /// đếm số lượng tìm được
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        int Count(string searchValue);
        /// <summary>
        /// lấy ra 1 shipper bằng shipperID 
        /// </summary>
        /// <param name="shipperID"></param>
        /// <returns></returns>
        Shipper Get(int shipperID);
        /// <summary>
        /// Bổ sung 1 shipper , hàn trả về id của shipper được bổ sungg.
        /// Nếu lỗi trả về giá trị nhỏ hơn hoặc bằng 0.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Add(Shipper data);
        /// <summary>
        /// cập nhật lại shipper
        /// </summary>
        /// <param name="shipperID"></param>
        /// <returns></returns>
        bool Update(Shipper shipperID);
        /// <summary>
        /// xóa nhiều shipper
        /// </summary>
        /// <param name="shipperIDs"></param>
        /// <returns></returns>
        int Delete(int[] shipperIDs);
    }
}
