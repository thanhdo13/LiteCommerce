using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DataLayers
{
    /// <summary>
    /// interface của country 
    /// </summary>
    public interface IHelperDAL
    {
        /// <summary>
        /// đếm số lượng tìm được
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        int Count(string searchValue);
        /// <summary>
        /// lấy ra danh sách các nước tìm được
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        List<Country> ListofCountry(int page, int pageSize, string searchValue);
        /// <summary>
        /// lấy ra thông tin của 1 nước
        /// </summary>
        /// <param name="countryID"></param>
        /// <returns></returns>
        Country Get(int countryID);
        /// <summary>
        /// bổ sung thêm 1 nước
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Add(Country data);
        /// <summary>
        /// cập nhật lại thông tin của nước đó
        /// </summary>
        /// <param name="countryID"></param>
        /// <returns></returns>
        bool Update(Country countryID);
        /// <summary>
        /// xóa nhiều nước 
        /// </summary>
        /// <param name="countryIDs"></param>
        /// <returns></returns>
        int Delete(int[] countryIDs);

    }
}
