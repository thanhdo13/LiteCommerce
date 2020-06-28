using LiteCommerce.DataLayers;
using LiteCommerce.DataLayers.SqlServer;
using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.BusinessLayers
{
    /// <summary>
    /// Tac nghiep lien quan den tai khoan
    /// </summary>
    public class UserAccountBLL
    {
        private static IUserAccountDAL userAccountDB { get; set; }
        private static string _connectionString;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        public static void Initialize(string connectionString)
        {
            _connectionString = connectionString;   
        }
        /// <summary>
        /// Phân chia tài khoản kết nối là nhân viên, khách hàng , shipper để trả về thông tin liên quan
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="userType"></param>
        /// <returns></returns>
        public static UserAccount Authorize(string userName, string password,UserAccountTypes userType)
        {
            switch (userType)
            {
                case UserAccountTypes.Employee:
                    userAccountDB = new EmployeeUserAccountDAL(_connectionString);
                    break;
                case UserAccountTypes.Customer:
                    userAccountDB = new CustomerUserAccountDAL(_connectionString);
                    break;
                default:
                    return null;  
            }
            return userAccountDB.Authorize(userName, password);
        }
        /// <summary>
        /// gọi hàm trả về thay đổi mật khẩu 
        /// </summary>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool ChangePassword(string password,string email)
        {
            return userAccountDB.ChangePassword(password,email);
        }
    }
}
