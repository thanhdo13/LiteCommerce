using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DataLayers
{
    /// <summary>
    /// interface của nhân viên
    /// </summary>
    public interface IEmployeeDAL
    {
        /// <summary>
        /// Hiển thị danh sách Employees, phân trang cà có thể tìm kiếm
        /// </summary>
        /// <param name="page"> trang</param>
        /// <param name="pageSize"> </param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        List<Employee> List(int page, int pageSize, string searchValue);
        /// <summary>
        /// đếm số lượng nhân viên tìm được
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        int Count(string searchValue);
        /// <summary>
        /// lấy ra thông tin của 1 nhân viên đó
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        Employee Get(int employeeID);
        /// <summary>
        /// Bổ sung 1 supplier , hàn trả về id của supplier được bổ sungg.
        /// Nếu lỗi trả về giá trị nhỏ hơn hoặc bằng 0.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Add(Employee data);
        /// <summary>
        /// cập nhật thông tin cho 1 nhân viên
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        bool Update(Employee employeeID);
        /// <summary>
        /// xóa nhiều nhân viên
        /// </summary>
        /// <param name="employeeIDs"></param>
        /// <returns></returns>
        int Delete(int[] employeeIDs);
        /// <summary>
        /// kiem tra email co trung khong?
        /// co thi tra ve 1 
        /// khong co thi tra ve 0
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        int CheckEmail(string email);
    }
}
