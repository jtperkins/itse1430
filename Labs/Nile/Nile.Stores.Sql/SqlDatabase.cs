
/**********************************************************
 * 
 * Taylor Perkins
 * ITSE 1430
 * 4/13/2019
 * 
 * ********************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile.Stores.Sql
{
    public class SqlDatabase : ProductDatabase
    {
        

        public SqlDatabase(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override Product AddCore(Product product)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                //var cmd = new SqlCommand("", connection);
                var cmd = connection.CreateCommand();
                cmd.CommandText = "AddProduct";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //Add parameter 1 - long way when you need control over parameter
                var parameter = new SqlParameter("@name", System.Data.SqlDbType.NVarChar);
                parameter.Value = product.Name;
                cmd.Parameters.Add(parameter);

                //Add parameter 2 - quick way when you just need type/value
                cmd.Parameters.AddWithValue("@description", product.Description);
                cmd.Parameters.AddWithValue("@price", product.Price);

                // (int)cmd.ExecuteScalar();
                // cmd.ExecuteScalar() as int;  //reference types 
                var result = Convert.ToInt32(cmd.ExecuteScalar());

                product.Id = result;
                return product;
            };
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        protected override IEnumerable<Product> GetAllCore()
        {
            var ds = new DataSet();

            using (var conn = GetConnection())
            {
                var cmd = new SqlCommand("GetAllProducts", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                var da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                //If you wanted to update
                //da.Update(ds);
            };

            //Disconnected from DB
            //ds.Tables[0].Rows[0][0] = "Old";
            //ds.Tables[0].Rows[0]["Name"] = "Old";
            var table = ds.Tables.OfType<DataTable>().FirstOrDefault();
            if (table != null)
            {
                return from r in table.Rows.OfType<DataRow>()
                       orderby r["Name"]
                       select new Product()
                       {
                           Id = Convert.ToInt32(r[0]),  //Ordinal, convert
                           Name = r["Name"].ToString(), //By name, convert
                           Description = r.IsNull("description") ? "" : r["description"].ToString(), //handle DB nulls
                           Price = r.Field<decimal>("Price")
                       };
            };

            return Enumerable.Empty<Product>();
        }

        protected override Product GetCore(int id)
        {
            using (var conn = GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "GetAllProducts";
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var gameId = reader.GetInt32(0);
                    if (gameId == id)
                    {
                        return new Product()
                        {
                            Id = gameId,
                            Name = GetString(reader, "Name"),
                            Description = GetString(reader, "description"),
                        
                            Price = reader.GetFieldValue<decimal>(3),
                        };
                    };
                };
            };

            return null;
        }

        private string GetString(SqlDataReader reader, string v)
        {
            var ordinal = reader.GetOrdinal(v);

            if (reader.IsDBNull(ordinal))
                return "";

            return reader.GetString(ordinal);
        }

        protected override void DeleteCore(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                //var cmd = new SqlCommand("", connection);
                var cmd = connection.CreateCommand();
                cmd.CommandText = "RemoveProduct";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                //No results
                cmd.ExecuteNonQuery();
            };
        }

        protected override Product UpdateCore(Product existing, Product newItem)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                //var cmd = new SqlCommand("", connection);
                var cmd = connection.CreateCommand();
                cmd.CommandText = "UpdateProduct";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //Add parameter 1 - long way when you need control over parameter
                var parameter = new SqlParameter("@name", System.Data.SqlDbType.NVarChar);
                parameter.Value = newItem.Name;
                cmd.Parameters.Add(parameter);

                //Add parameter 2 - quick way when you just need type/value
                cmd.Parameters.AddWithValue("@description", newItem.Description);
                cmd.Parameters.AddWithValue("@price", newItem.Price);
                cmd.Parameters.AddWithValue("@id", existing.Id);

                //No results
                cmd.ExecuteNonQuery();
            };

            return newItem;
        }

        private readonly string _connectionString;
    }
}
