using EL;
using FL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLClient
    {
        public static EClient GetUser(string mailAdress, string password)
        {
            return FClient.GetUser(mailAdress, password);
        }
        public static List<EClient> GetClients()
        {
            return FClient.GetClients();
        }
        public static int CreateClient(string name, string surname, string tel, string email, string pass, string addr, bool admin)
        {
            return FClient.CreateClient(name, surname, tel, email, pass, addr, admin);
        }
        public static int DeleteClient(int id)
        {
            return FClient.DeleteClient(id);
        }
        public static int UpdateClient(EClient client)
        {
            return FClient.UpdateClient(client);
        }
    }
}
