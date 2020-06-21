using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteCommerce.DomainModels;

namespace LiteCommerce.DataLayers.SqlServer
{
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

        public bool ChangePassword(string Password,string email)
        {
            throw new NotImplementedException();
        }
    }
}
