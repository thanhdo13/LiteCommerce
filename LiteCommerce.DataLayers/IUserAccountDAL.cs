using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DataLayers
{
    /// <summary>
    /// interface của tài khoản 
    /// </summary>
    public interface IUserAccountDAL
    {
        /// <summary>
        /// Kiem tra userName , password co hop le hay k?
        /// Neu hop le thi tra ve thong tin cua User,
        /// nguoc lai thi trar ve gia tri null
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        UserAccount Authorize(string userName, string password);
        /// <summary>
        /// Thay đổi mật khẩu 
        /// </summary>
        /// <param name="Password"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        bool ChangePassword(string Password,string email);

    }
}
