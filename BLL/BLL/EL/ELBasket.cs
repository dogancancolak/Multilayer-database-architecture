using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class ELBasket
    {
        public int id { get; set; }
        public int clientID { get; set; }
        public int productId { get; set; }
        public int productCount { get; set; }
        public bool condition { get; set; }
    }
}
