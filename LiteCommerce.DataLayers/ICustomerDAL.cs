﻿using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DataLayers
{
    /// <summary>
    /// interface của khách hàng
    /// </summary>
    public interface ICustomerDAL
    {
        /// <summary>
        /// Hiển thị danh sách Customers, phân trang cà có thể tìm kiếm
        /// </summary>
        /// <param name="page"> trang</param>
        /// <param name="pageSize"> </param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        List<Customer> List(int page, int pageSize, string searchValue,string country);
        /// <summary>
        /// đếm số lượng nhân viên mà tìm được
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        int Count(string searchValue, string country);
        /// <summary>
        /// lấy ra thông tin của nhân viên đó
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        Customer Get(string customerID);
        /// <summary>
        /// Bổ sung 1 Customer , hàn trả về id của supplier được bổ sungg.
        /// Nếu lỗi trả về giá trị nhỏ hơn hoặc bằng 0.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        string Add(Customer data);
        /// <summary>
        /// cập nhật lại thông tin của nhân viên đó
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        bool Update(Customer customerID);
        /// <summary>
        /// xóa nhiều nhân viên
        /// </summary>
        /// <param name="customerIDs"></param>
        /// <returns></returns>
        int Delete(string[] customerIDs);
    }
}
