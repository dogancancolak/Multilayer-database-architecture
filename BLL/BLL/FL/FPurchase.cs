using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL;
using System.Data.SqlClient;
using System.Data;

namespace FL
{
    public class FPurchase
    {
        public static int CreatePurchase(decimal total, string product, string note, bool type, int cid)
        {
            SqlCommand com = new SqlCommand("PurchaseCreate", Connection.Con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@Ptotal", total);
            com.Parameters.AddWithValue("@Ppro", product);
            com.Parameters.AddWithValue("@Pnote", note);
            com.Parameters.AddWithValue("@Ptype", type);
            com.Parameters.AddWithValue("@Pcid", cid);
            com.Parameters.AddWithValue("@date", DateTime.Now);

            if (com.Connection.State != ConnectionState.Open)
            {
                com.Connection.Open();
            }

            int effectedRow = com.ExecuteNonQuery();

            com.Dispose();
            com.Connection.Close();
            return effectedRow;
        }
        public static List<EPurchase> GetPurchase()
        {
            SqlCommand com = new SqlCommand("GetPurchase", Connection.Con);
            com.CommandType = CommandType.StoredProcedure;

            if (com.Connection.State != ConnectionState.Open)
            {
                com.Connection.Open();
            }

            List<EPurchase> lst = new List<EPurchase>();
            SqlDataReader rd = com.ExecuteReader();
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    lst.Add(new EPurchase
                    {
                        id = Convert.ToInt32(rd["id"]),
                        totalPrice = Convert.ToDecimal(rd["totalPrice"].ToString()),
                        allProducts = rd["allproducts"].ToString(),
                        purchaseNote = rd["orderNote"].ToString(),
                        payment = Convert.ToBoolean(rd["paymentType"]),
                        clientId = Convert.ToInt32(rd["clientID"].ToString()),
                        orderDate = Convert.ToDateTime(rd["orderDate"])
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
        public static List<EPurchase> GetPurchase_ClientID(int client)
        {
            SqlCommand com = new SqlCommand("PurchaseSelect_ClientID", Connection.Con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@client", client);

            if (com.Connection.State != ConnectionState.Open)
            {
                com.Connection.Open();
            }

            List<EPurchase> lst = new List<EPurchase>();
            SqlDataReader rd = com.ExecuteReader();
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    lst.Add(new EPurchase
                    {
                        id = Convert.ToInt32(rd["id"]),
                        totalPrice = Convert.ToDecimal(rd["totalPrice"].ToString()),
                        allProducts = rd["allproducts"].ToString(),
                        purchaseNote = rd["orderNote"].ToString(),
                        payment = Convert.ToBoolean(rd["paymentType"]),
                        clientId = Convert.ToInt32(rd["clientID"].ToString()),
                        orderDate = Convert.ToDateTime(rd["orderDate"])
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
    }
}
