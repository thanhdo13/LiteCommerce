using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteCommerce.DomainModels;

namespace LiteCommerce.DataLayers.SqlServer
{
    /// <summary>
    /// Các chức năng liên quan đến tài khoản của khách hàng
    /// </summary>
    public class CustomerUserAccountDAL : IUserAccountDAL
    {
        private string connectionString;
        public CustomerUserAccountDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        /// <summary>
        /// Kiem tra thong tin dang nhap tu bang Customer
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public UserAccount Authorize(string userName, string password)
        {
            ///TODO : kiem tra thong tin dang nhap vao bang Customer 
            return new UserAccount()
            {
                UserID = userName,
                FullName = "cc",
                Photo = "cc.jpg" ,
                Title ="Sale vs Sale",
                Roles = "Roles"
            };
        }
        /// <summary>
        /// thay đổi mật khẩu cho khách hàng
        /// </summary>
        /// <param name="Password"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool ChangePassword(string Password,string email)
        {
            //TODO: Thay đổi mật khẩu
            throw new NotImplementedException();
        }
    }
}
