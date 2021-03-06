﻿using System;
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
    /// các chức năng liên quan đến hóa đơn 
    /// </summary>
    public class OrderDAL : IOrderDAL
    {
        private string connectionString;
        /// <summary>
        /// kết nối
        /// </summary>
        /// <param name="connectionString"></param>
        public OrderDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        /// <summary>
        /// thêm 1 order SQL
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Add(Order data)
        {
            //TODO: add order
            throw new NotImplementedException();
        }
        /// <summary>
        /// đếm số lượng order SQL
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
                cmd.CommandText = @"select COUNT(*)    	
	                                from Orders 
					                inner join Customers on Orders.CustomerID = Customers.CustomerID
					                inner join Employees on Orders.EmployeeID = Employees.EmployeeID
					                inner join Shippers on Orders.ShipperID = Shippers.ShipperID
					
                                   where (@searchValue = N'') or (Customers.CompanyName like @searchValue) or (Employees.FirstName like @searchValue) or (Employees.LastName like @searchValue) or (Shippers.CompanyName like @searchValue)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@searchValue", searchValue);
                count = Convert.ToInt32(cmd.ExecuteScalar());
                connection.Close();
            }
            return count;
        }
        /// <summary>
        /// xóa nhiều order SQL
        /// </summary>
        /// <param name="orderIDs"></param>
        /// <returns></returns>
        public int Delete(int[] orderIDs)
        {
            //TODO: delete order
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// lấy ra 1 order SQL
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public Order Get(int orderID)
        {
            //TODO: get order
            throw new NotImplementedException();
        }
        /// <summary>
        /// Liệt kê danh sách các order SQL
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public List<Order> List(int page, int pageSize, string searchValue)
        {
            List<Order> data = new List<Order>();
            if (!string.IsNullOrEmpty(searchValue))
                searchValue = "%" + searchValue + "%";
            // taoj ket noi
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // Tạo lệnh thực thi truy vấn dữ liệu
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"select * 
                                    from
                                    (

	                                    select ROW_NUMBER() over (order by ShipAddress) as RowNumber,
		                                    Orders.OrderID,Customers.CompanyName as b,(Employees.FirstName + ' '+ Employees.LastName) as d,OrderDate,RequiredDate,ShippedDate,Shippers.CompanyName as c,Freight,ShipAddress,ShipCity,ShipCountry
	                                    from Orders 
					                    inner join Customers on Orders.CustomerID = Customers.CustomerID
					                    inner join Employees on Orders.EmployeeID = Employees.EmployeeID
					                    inner join Shippers on Orders.ShipperID = Shippers.ShipperID
					 
	                                    where (@searchValue = N'') or (Customers.CompanyName like @searchValue) or (Employees.FirstName like @searchValue) or (Employees.LastName like @searchValue) or (Shippers.CompanyName like @searchValue)

                                    ) as t
                                where t.RowNumber between (@page-1)* @pageSize +1 and @page*@pageSize";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@page", page);
                cmd.Parameters.AddWithValue("@pageSize", pageSize);
                cmd.Parameters.AddWithValue("@searchValue", searchValue);
                // thuc hien
                using (SqlDataReader dbReader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (dbReader.Read())
                    {
                        data.Add(new Order()
                        {
                            OrderID = Convert.ToInt32(dbReader["OrderID"]),
                            Customer = Convert.ToString(dbReader["b"]),
                            Employee = Convert.ToString(dbReader["d"]),
                            OrderDate = Convert.ToDateTime(dbReader["OrderDate"]),
                            RequiredDate = Convert.ToDateTime(dbReader["RequiredDate"]),
                            ShippedDate = Convert.ToString(dbReader["ShippedDate"]),
                            Shipper = Convert.ToString(dbReader["c"]),
                            Freight = Convert.ToInt64(dbReader["Freight"]),
                            ShipAddress = Convert.ToString(dbReader["ShipAddress"]),
                            ShipCity = Convert.ToString(dbReader["ShipCity"]),
                            ShipCountry = Convert.ToString(dbReader["ShipCountry"])
                        });
                    }
                }
                connection.Close();
            }
            return data;
        }
        /// <summary>
        /// update 1 order
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public bool Update(Order orderID)
        {
            //TODO: update order
            throw new NotImplementedException();
        }
    }
}
