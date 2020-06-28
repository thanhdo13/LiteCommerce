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
   /// các chức naawnh liên quan đến các quốc gia SQL
   /// </summary>
    public class HelperDAL : IHelperDAL
    {
        /// <summary>
        /// 
        /// </summary>
        private string connectionString;
        public HelperDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        /// <summary>
        /// Thêm 1 quốc gia
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Add(Country data)
        {
            int countryID = 0;
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"INSERT INTO Countries
                                          (
	                                          CountryName
                                          )
                                          VALUES
                                          (
	                                          @CountryName
                                          );
                                          SELECT @@IDENTITY;";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@CountryName", data.CountryName);
                countryID = Convert.ToInt32(cmd.ExecuteScalar());

                connection.Close();
            }

            return countryID;
        }
        /// <summary>
        /// đếm số lượng quốc gia SQL
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public int Count(string searchValue)
        {
            int count = 0;
            if (!string.IsNullOrEmpty(searchValue))
                searchValue = "%" + searchValue + "%";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"select COUNT(*) from Countries
                                     where 
                                   ((@searchValue = N'') or (CountryName like @searchValue))";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@searchValue", searchValue);
                count = Convert.ToInt32(cmd.ExecuteScalar());
                connection.Close();
            }
            return count;
        }
        /// <summary>
        /// Xóa nhiều quốc gia quốc gia SQL theeo các ID
        /// </summary>
        /// <param name="countryIDs"></param>
        /// <returns></returns>
        public int Delete(int[] countryIDs)
        {
            int countDeleted = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"DELETE FROM Countries
                                            WHERE(CountryID = @CountryID)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.Add("@CountryID", SqlDbType.Int);
                foreach (int CountryID in countryIDs)
                {
                    cmd.Parameters["@CountryID"].Value = CountryID;
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        countDeleted += 1;
                }

                connection.Close();
            }
            return countDeleted;
        }
        /// <summary>
        /// Lấy ra thông tin của 1 quốc gia SQL
        /// </summary>
        /// <param name="countryID"></param>
        /// <returns></returns>
        public Country Get(int countryID)
        {
            Country data = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"SELECT * FROM Countries WHERE CountryID = @CountryID";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@CountryID", countryID);

                using (SqlDataReader dbReader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (dbReader.Read())
                    {
                        data = new Country()
                        {
                            CountryID = Convert.ToInt32(dbReader["CountryID"]),
                            CountryName = Convert.ToString(dbReader["CountryName"])
                        };
                    }
                }

                connection.Close();
            }
            return data;
        }
        /// <summary>
        /// Liệt kê danh sách các quốc gia SQL 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public List<Country> ListofCountry(int page, int pageSize, string searchValue)
        {
            if (!string.IsNullOrEmpty(searchValue))
                searchValue = "%" + searchValue + "%";
            List<Country> data = new List<Country>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"select * 
                                        from
                                        (
	                                        select ROW_NUMBER() over (order by CountryName) as RowNumber,
		                                        Countries.*
	                                        from Countries
	                                        where ((@searchValue = N'') or (CountryName like @searchValue)) 
                                        ) as t
                                        where (@pageSize <0) or
                                        t.RowNumber between (@page-1)* @pageSize +1 and @page*@pageSize";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@page", page);
                cmd.Parameters.AddWithValue("@pageSize", pageSize);
                cmd.Parameters.AddWithValue("@searchValue", searchValue);

                using (SqlDataReader dbReader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (dbReader.Read())
                    {
                        data.Add(new Country()
                        {
                            CountryID = Convert.ToInt32(dbReader["CountryID"]),
                            CountryName = Convert.ToString(dbReader["CountryName"])
                        });
                    }
                    
                }

                connection.Close();
            }
            return data;
        }
        /// <summary>
        /// cập nhật quốc gia SQL
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Update(Country data)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"UPDATE Countries
                                           SET CountryName = @CountryName
                                          WHERE CountryID = @CountryID";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@CountryID", data.CountryID);
                cmd.Parameters.AddWithValue("@CountryName", data.CountryName);

                rowsAffected = Convert.ToInt32(cmd.ExecuteNonQuery());

                connection.Close();
            }

            return rowsAffected > 0;
        }
    }
    
}
