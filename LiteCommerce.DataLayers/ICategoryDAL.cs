using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DataLayers
{
    /// <summary>
    /// interface của thể loại
    /// </summary>
    public interface ICategoryDAL
    {
        /// <summary>
        /// Hiển thị danh sách Categories, phân trang cà có thể tìm kiếm
        /// </summary>
        /// <param name="page"> trang</param>
        /// <param name="pageSize"> </param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        List<Category> List(int page, int pageSize, string searchValue);
        /// <summary>
        /// đếm số lượng thể loại tìm được
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        int Count(string searchValue);
        /// <summary>
        /// lấy ra thông tin của 1 thể loại
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        Category Get(int categoryID);
        /// <summary>
        /// Bổ sung 1 category , hàn trả về id của category được bổ sungg.
        /// Nếu lỗi trả về giá trị nhỏ hơn hoặc bằng 0.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Add(Category data);
        /// <summary>
        /// cập nhật lại thông tin của thể loại đó
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        bool Update(Category categoryID);
        /// <summary>
        /// xóa nhiều thể loại
        /// </summary>
        /// <param name="categoryIDs"></param>
        /// <returns></returns>
        int Delete(int[] categoryIDs);
    }
}
