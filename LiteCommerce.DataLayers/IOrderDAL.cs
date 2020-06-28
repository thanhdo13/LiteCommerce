using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DataLayers
{
    /// <summary>
    /// interface của hóa đơn
    /// </summary>
    public interface IOrderDAL
    {
        /// <summary>
        /// Hiển thị danh sách Order, phân trang cà có thể tìm kiếm
        /// </summary>
        /// <param name="page"> trang</param>
        /// <param name="pageSize"> </param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        List<Order> List(int page, int pageSize, string searchValue);
        /// <summary>
        /// đếm số lượng tìm được
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        int Count(string searchValue);
        /// <summary>
        /// lấy ra thông tin của 1 hóa đơn
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        Order Get(int orderID);
        /// <summary>
        /// Bổ sung 1 order , hàn trả về id của supplier được bổ sungg.
        /// Nếu lỗi trả về giá trị nhỏ hơn hoặc bằng 0.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Add(Order data);
        /// <summary>
        /// cập nhật thông tin của hóa đơn
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        bool Update(Order orderID);
        /// <summary>
        /// xóa nhiều hóa đơn
        /// </summary>
        /// <param name="orderIDs"></param>
        /// <returns></returns>
        int Delete(int[] orderIDs);
    }
}
