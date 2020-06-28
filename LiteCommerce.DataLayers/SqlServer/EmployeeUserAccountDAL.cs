using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DataLayers.SqlServer
{
    /// <summary>
    /// các chức năng liên quan đến tài khoản của nhân viên
    /// </summary>
    public class EmployeeUserAccountDAL : IUserAccountDAL
    {
        private string connectionString;
        public EmployeeUserAccountDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        /// <summary>
        /// Lấy thông tin của người đăng nhập
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public UserAccount Authorize(string email, string password)
        {
            UserAccount user = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"select EmployeeID,LastName +' '+FirstName as FullName,PhotoPath,Title,Roles from Employees
                                          WHERE Email = @email and Password=@password";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password);
                    using (SqlDataReader dbReader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (dbReader.Read())
                        {
                            user = new UserAccount()
                            {
                                UserID = Convert.ToString(dbReader["EmployeeID"]),
                                FullName = Convert.ToString(dbReader["FullName"]),
                                Photo = Convert.ToString(dbReader["PhotoPath"]),
                                Title = Convert.ToString(dbReader["Title"]),
                                Roles = Convert.ToString(dbReader["Roles"])
                            };
                        }
                    }
                }
                connection.Close();
            }
            return user;
        }
        /// <summary>
        /// Thay đổi mật khẩu 
        /// </summary>
        /// <param name="Password"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool ChangePassword(string Password,string email)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"UPDATE Employees
                                           SET Password = @Password
                                          WHERE Email = @email";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@Password",Password);
                cmd.Parameters.AddWithValue("@email", email);
                rowsAffected = Convert.ToInt32(cmd.ExecuteNonQuery());

                connection.Close();
            }

            return rowsAffected > 0;
        }
    }
    
}
