using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteCommerce.DomainModels;
using System.Data.SqlClient;
using System.Data;

namespace LiteCommerce.DataLayers.SqlServer
{
    /// <summary>
    /// các chức năng được hoàn thiện của thống kê
    /// </summary>
    public class DashboardDAL : IDashboard
    {
        /// <summary>
        /// 
        /// </summary>
        private string connectionString;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        public DashboardDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        /// <summary>
        /// thống kê tiền theo năm SQL
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public Dashboard ThongKeTienTheoNam(int year)
        {
            Dashboard data = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"SELECT Year, COALESCE([1] , 0) AS January, COALESCE([2] , 0) AS February, COALESCE([3] , 0) AS March, COALESCE([4] , 0) AS April, COALESCE([5] , 0) AS May, COALESCE([6] , 0) AS June, COALESCE([7] , 0) AS July, COALESCE([8] , 0) AS August, COALESCE([9] , 0) AS September, COALESCE([10], 0) AS October, COALESCE([11], 0) AS November, COALESCE([12], 0) AS December 
                                    FROM 
                                    (SELECT YEAR(OrderDate) as Year  , MONTH(OrderDate) AS Month ,(CT.Quantity*CT.UnitPrice)-(CT.Quantity*CT.UnitPrice)*CT.Discount AS ToTal FROM Orders HD JOIN OrderDetails CT ON CT.OrderID = HD.OrderID WHERE YEAR(HD.OrderDate) = @Year)  TEMP PIVOT( SUM(ToTal) FOR Month IN ([1], [2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12])) AS PivotTable";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@Year", year);
                using (SqlDataReader dbReader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (dbReader.Read())
                    {
                        data = new Dashboard()
                        {
                            Jan = Convert.ToInt32(dbReader["January"]),
                            Feb = Convert.ToInt32(dbReader["February"]),
                            Mar = Convert.ToInt32(dbReader["March"]),
                            Apr = Convert.ToInt32(dbReader["April"]),
                            May = Convert.ToInt32(dbReader["May"]),
                            Jun = Convert.ToInt32(dbReader["June"]),
                            Jul = Convert.ToInt32(dbReader["July"]),
                            Aug = Convert.ToInt32(dbReader["August"]),
                            Sep = Convert.ToInt32(dbReader["September"]),
                            Oct = Convert.ToInt32(dbReader["October"]),
                            Nov = Convert.ToInt32(dbReader["November"]),
                            Dec = Convert.ToInt32(dbReader["December"])
                        };
                    }
                }
                connection.Close();
            }
            return data;
        }

        public List<int> Year()
        {
            List<int> data = new List<int>();
            // taoj ket noi
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // Tạo lệnh thực thi truy vấn dữ liệu
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"select distinct YEAR(OrderDate) as Year from Orders";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                // thuc hien
                using (SqlDataReader dbReader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (dbReader.Read())
                    {
                        int year = Convert.ToInt32(dbReader["Year"]);
                        data.Add(year);
                    }
                }
                connection.Close();
            }
            return data;
        }
    }
}
