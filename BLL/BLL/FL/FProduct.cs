using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL;

namespace FL
{
    public class FProduct
    {
        public static List<EProduct> GetProduct()
        {
            SqlCommand com = new SqlCommand("GetProducts", Connection.Con);
            com.CommandType = CommandType.StoredProcedure;

            if (com.Connection.State != ConnectionState.Open)
            {
                com.Connection.Open();
            }

            List<EProduct> lst = new List<EProduct>();
            SqlDataReader rd = com.ExecuteReader();
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    lst.Add(new EProduct
                    {
                        ProductID = Convert.ToInt32(rd["id"]),
                        ProductName = rd["name"].ToString(),
                        CategoryID = Convert.ToInt32(rd["categoryID"]),
                        Price = Convert.ToDecimal(rd["price"]),
                        Stock = Convert.ToBoolean(rd["stock"]),
                        Description = rd["description"].ToString()
                    });
                }

                com.Dispose();
                com.Connection.Close();
                return lst;

            }
            com.Dispose();
            com.Connection.Close();

            return null;
        }
        public static List<EProduct> SelectProduct_Category(int cat)
        {
            SqlCommand com = new SqlCommand("ProductSelect_Category", Connection.Con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@category", cat);

            if (com.Connection.State != ConnectionState.Open)
            {
                com.Connection.Open();
            }

            List<EProduct> lst = new List<EProduct>();
            SqlDataReader rd = com.ExecuteReader();
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    lst.Add(new EProduct
                    {
                        ProductID = Convert.ToInt32(rd["id"]),
                        ProductName = rd["name"].ToString(),
                        CategoryID = Convert.ToInt32(rd["categoryID"]),
                        Price = Convert.ToDecimal(rd["price"]),
                        Stock = Convert.ToBoolean(rd["stock"]),
                        Description = rd["description"].ToString()
                    });
                }

                com.Dispose();
                com.Connection.Close();
                return lst;

            }
            com.Dispose();
            com.Connection.Close();

            return null;
        }
        public static int UpdateProduct(EProduct Product)
        {
            SqlCommand com = new SqlCommand("ProductUpdate", Connection.Con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@Pid", Product.ProductID);
            com.Parameters.AddWithValue("@Pname", Product.ProductName);
            com.Parameters.AddWithValue("@PcategoryID", Product.CategoryID);
            com.Parameters.AddWithValue("@Pprice", Product.Price);
            com.Parameters.AddWithValue("@Pstock", Product.Stock);
            com.Parameters.AddWithValue("@Pdescription", Product.Description);


            if (com.Connection.State != ConnectionState.Open)
            {
                com.Connection.Open();
            }

            int effectedRow = com.ExecuteNonQuery();

            com.Dispose();
            com.Connection.Close();
            return effectedRow;
        }
        public static int DeleteProduct(int ProductID)
        {

            SqlCommand com = new SqlCommand("ProductDelete", Connection.Con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@Pid", ProductID);


            if (com.Connection.State != ConnectionState.Open)
            {
                com.Connection.Open();
            }

            int effectedRow = com.ExecuteNonQuery();

            com.Dispose();
            com.Connection.Close();
            return effectedRow;

        }
        public static int CreateProduct(string name, int cat, decimal price, bool stock, string desc)
        {
            SqlCommand com = new SqlCommand("ProductCreate", Connection.Con);
            com.CommandType = CommandType.StoredProcedure;
            
            com.Parameters.AddWithValue("@Pname", name);
            com.Parameters.AddWithValue("@PcategoryID", cat);
            com.Parameters.AddWithValue("@Pprice", price);
            com.Parameters.AddWithValue("@Pstock", stock);
            com.Parameters.AddWithValue("@Pdescription", desc);

            if (com.Connection.State != ConnectionState.Open)
            {
                com.Connection.Open();
            }

            int effectedRow = com.ExecuteNonQuery();

            com.Dispose();
            com.Connection.Close();
            return effectedRow;
        }
        public static EProduct SelectProduct(int id)
        {
            SqlCommand com = new SqlCommand("ProductSelect", Connection.Con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@id", id);

            if (com.Connection.State != ConnectionState.Open)
            {
                com.Connection.Open();
            }

            SqlDataReader rd = com.ExecuteReader();
            if (rd.HasRows)
            {

                rd.Read();

                return new EProduct
                {
                    ProductID = Convert.ToInt32(rd["id"].ToString()),
                    ProductName = rd["name"].ToString(),
                    CategoryID = Convert.ToInt32(rd["categoryID"].ToString()),
                    Price = Convert.ToDecimal(rd["price"].ToString()),
                    Stock = Convert.ToBoolean(rd["stock"]),
                    Description = rd["description"].ToString()
                };

            }
            com.Dispose();
            com.Connection.Close();

            return null;

        }
    }
}
