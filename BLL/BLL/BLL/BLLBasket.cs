using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL;
using FL;

namespace BLL
{
    public class BLLBasket
    {
        public static int AddItem(int client, int product, int count)
        {
            return FLBasket.AddItem(client, product, count);
        }
        public static List<ELBasket> GetBasket()
        {
            return FLBasket.GetBasket();
        }
        public static int DeleteBasket(int id)
        {
            return FLBasket.DeleteBasket(id);
        }
    }
}
