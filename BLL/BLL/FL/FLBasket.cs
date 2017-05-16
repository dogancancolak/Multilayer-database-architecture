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
    public class FLBasket
    {
        public static int AddItem(int client, int product , int count)
        {
            SqlCommand com = new SqlCommand("BasketInsert", Connection.Con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@clientId", client);
            com.Parameters.AddWithValue("@productId", product);
            com.Parameters.AddWithValue("@count", count);

            if (com.Connection.State != ConnectionState.Open)
            {
                com.Connection.Open();
            }

            int effectedRow = com.ExecuteNonQuery();

            com.Dispose();
            com.Connection.Close();
            return effectedRow;
        }
        public static List<ELBasket> GetBasket()
        {
            SqlCommand com = new SqlCommand("GetBasket", Connection.Con);
            com.CommandType = CommandType.StoredProcedure;

            if (com.Connection.State != ConnectionState.Open)
            {
                com.Connection.Open();
            }
            List<ELBasket> lst = new List<ELBasket>();
            SqlDataReader rd = com.ExecuteReader();
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    lst.Add(new ELBasket
                    {
                        id = Convert.ToInt32(rd["id"]),
                        clientID = Convert.ToInt32(rd["clientID"]),
                        productId = Convert.ToInt32(rd["productID"]),
                        productCount = Convert.ToInt32(rd["productCount"]),
                        condition = Convert.ToBoolean(rd["condition"])
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
        public static int DeleteBasket(int id)
        {
            SqlCommand com = new SqlCommand("BasketDelete", Connection.Con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@Bid", id);

            if (com.Connection.State != ConnectionState.Open)
            {
                com.Connection.Open();
            }

            int effectedRow = com.ExecuteNonQuery();

            com.Dispose();
            com.Connection.Close();
            return effectedRow;
        }
    }
}
