using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL;
using FL;

namespace BLL
{
    public class BLLPurchase
    {
        public static int CreatePurchase(decimal total, string product, string note, bool type, int cid)
        {
            return FPurchase.CreatePurchase(total,product,note,type,cid);
        }
        public static List<EPurchase> GetPurchase()
        {
            return FPurchase.GetPurchase();
        }
        public static List<EPurchase> GetPurchase_ClientID(int client)
        {
            return FPurchase.GetPurchase_ClientID(client);
        }
    }
}
