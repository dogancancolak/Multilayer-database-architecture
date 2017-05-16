using EL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FL
{
    public class FClient
    {
        public static EClient GetUser(string mailAdress, string password)
        {
            SqlCommand com = new SqlCommand("IsClientValid", Connection.Con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@Mail", mailAdress);
            com.Parameters.AddWithValue("@Pass", password);

            if (com.Connection.State != ConnectionState.Open)
            {
                com.Connection.Open();
            }

            SqlDataReader rd = com.ExecuteReader();
            if (rd.HasRows)
            {

                rd.Read();

                return new EClient
                {
                    id = Convert.ToInt32(rd["id"]),
                    name = rd["name"].ToString(),
                    surname = rd["surname"].ToString(),
                    email = rd["email"].ToString(),
                    password = rd["password"].ToString(),
                    isAdmin = Convert.ToBoolean(rd["isAdmin"])
                };

            }
            com.Dispose();
            com.Connection.Close();

            return null;
        }

        public static List<EClient> GetClients()
        {
            SqlCommand com = new SqlCommand("GetClients", Connection.Con);
            com.CommandType = CommandType.StoredProcedure;

            if (com.Connection.State != ConnectionState.Open)
            {
                com.Connection.Open();
            }
            List<EClient> lst = new List<EClient>();
            SqlDataReader rd = com.ExecuteReader();
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    lst.Add(new EClient
                    {
                        id = Convert.ToInt32(rd["id"]),
                        name = rd["name"].ToString(),
                        surname = rd["surname"].ToString(),
                        telephone = rd["telephone"].ToString(),
                        email = rd["email"].ToString(),
                        password = rd["password"].ToString(),
                        address = rd["address"].ToString(),
                        isAdmin = Convert.ToBoolean(rd["isAdmin"])
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

        public static int CreateClient(string name, string surname, string tel, string email, string pass, string addr,bool admin)
        {
            SqlCommand com = new SqlCommand("ClientCreate", Connection.Con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@Name", name);
            com.Parameters.AddWithValue("@Surname", surname);
            com.Parameters.AddWithValue("@Telephone", tel);
            com.Parameters.AddWithValue("@Mail", email);
            com.Parameters.AddWithValue("@Pass", pass);
            com.Parameters.AddWithValue("@Adress", addr);
            com.Parameters.AddWithValue("@Date", DateTime.Today);
            com.Parameters.AddWithValue("@isAdmin", admin);

            if (com.Connection.State != ConnectionState.Open)
            {
                com.Connection.Open();
            }

            int effectedRow = com.ExecuteNonQuery();

            com.Dispose();
            com.Connection.Close();
            return effectedRow;
        }
        public static int DeleteClient(int id)
        {
            SqlCommand com = new SqlCommand("ClientDelete", Connection.Con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@Cid", id);


            if (com.Connection.State != ConnectionState.Open)
            {
                com.Connection.Open();
            }

            int effectedRow = com.ExecuteNonQuery();

            com.Dispose();
            com.Connection.Close();
            return effectedRow;
        }
        public static int UpdateClient(EClient client)
        {
            SqlCommand com = new SqlCommand("ClientUpdate", Connection.Con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@Cid", client.id);
            com.Parameters.AddWithValue("@Cname", client.name);
            com.Parameters.AddWithValue("@Csurname", client.surname);
            com.Parameters.AddWithValue("@Ctelephone", client.telephone);
            com.Parameters.AddWithValue("@Cemail", client.email);
            com.Parameters.AddWithValue("@Cpassword", client.password);
            com.Parameters.AddWithValue("@Caddress", client.address);
            com.Parameters.AddWithValue("@Cadmin", client.isAdmin);


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
