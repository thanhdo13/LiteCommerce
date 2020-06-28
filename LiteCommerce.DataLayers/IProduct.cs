using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DataLayers
{
    /// <summary>
    /// interface của sản phẩm
    /// </summary>
    public interface IProduct
    {
        /// <summary>
        /// Hiển thị danh sách Products, phân trang cà có thể tìm kiếm
        /// </summary>
        /// <param name="page"> trang</param>
        /// <param name="pageSize"> </param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        List<Product> List(int page, int pageSize, string searchValue, int supplier, int category);
        /// <summary>
        /// đếm số lượng tìm được
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        int Count(string searchValue, int supplier, int category);
        /// <summary>
        /// lấy ra 1 sản phẩm bằng ID của sản phẩm đó
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        Product Get(int productID);
        /// <summary>
        /// Bổ sung 1 category , hàn trả về id của category được bổ sungg.
        /// Nếu lỗi trả về giá trị nhỏ hơn hoặc bằng 0.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Add(Product data);
        /// <summary>
        /// cập nhật lại sản phẩm
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        bool Update(Product productID);
        /// <summary>
        /// xóa nhiều sản phẩm
        /// </summary>
        /// <param name="productIDs"></param>
        /// <returns></returns>
        int Delete(int[] productIDs);
    }
}
