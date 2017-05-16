using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class EPurchase
    {
        public int id { get; set; }
        public decimal totalPrice { get; set; }
        public string allProducts { get; set; }
        public string purchaseNote { get; set; }
        public bool payment { get; set; }
        public int clientId { get; set; }
        public DateTime orderDate { get; set; }
    }
}
