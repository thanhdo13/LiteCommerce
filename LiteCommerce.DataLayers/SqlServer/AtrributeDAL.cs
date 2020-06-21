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
    public class AtrributeDAL : IAttributeDAL
    {
        private string connectionString;
        public AtrributeDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public int Add(Attributes data)
        {
            int atrributeID = 0;
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"INSERT INTO Attributes
                                          (
	                                          ProductID,
											  AttributeName,
											  Color,
											  Size
                                          )
                                          VALUES
                                          (
	                                          @ProductID,
	                                          @AttributeName,
											  @Color,
											  @Size

                                          );
                                          SELECT @@IDENTITY;";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@ProductID", data.ProductID);
                cmd.Parameters.AddWithValue("@AttributeName", data.AttributeName);
                cmd.Parameters.AddWithValue("@Color", data.Color);
                cmd.Parameters.AddWithValue("@Size", data.Size);
                atrributeID = Convert.ToInt32(cmd.ExecuteScalar());

                connection.Close();
            }

            return atrributeID;
        }

        public List<Attributes> GetListAttribute(int productID)
        {
            List<Attributes> data = new List<Attributes>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"SELECT * FROM Attributes WHERE productID = @productID";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@productID", productID);

                using (SqlDataReader dbReader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (dbReader.Read())
                    {
                        data.Add(new Attributes()
                        {
                            AttributeID = Convert.ToInt32(dbReader["AttributeID"]),
                            AttributeName = Convert.ToString(dbReader["AttributeName"]),
                            Color = Convert.ToString(dbReader["Color"]),
                            ProductID = Convert.ToInt32(dbReader["ProductID"]),
                            Size = Convert.ToString(dbReader["Size"])
                        });
                    }
                }

                connection.Close();
            }
            return data;
        }

        public bool Update(Attributes data)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"UPDATE Attributes
                                           SET AttributeName = @AttributeName
                                              ,Color = @Color
                                              ,Size = @Size
                                          WHERE AttributeID = @AttributeID";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@AttributeName", data.AttributeName);
                cmd.Parameters.AddWithValue("@Color", data.Color);
                cmd.Parameters.AddWithValue("@Size", data.Size);
                cmd.Parameters.AddWithValue("@AttributeID", data.AttributeID);

                rowsAffected = Convert.ToInt32(cmd.ExecuteNonQuery());

                connection.Close();
            }

            return rowsAffected > 0;
        }
    }
}
