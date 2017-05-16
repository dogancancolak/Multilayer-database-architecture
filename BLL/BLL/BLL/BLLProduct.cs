using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL;
using FL;

namespace BLL
{
    public class BLLProduct
    {
        public static List<EProduct> GetProduct()
        {
            return FProduct.GetProduct();
        }
        public static int DeleteProduct(int ProductID)
        {
            return FProduct.DeleteProduct(ProductID);
        }
        public static int UpdateProduct(EProduct Product)
        {
            return FProduct.UpdateProduct(Product);
        }
        public static int CreateProduct(string name, int cat, decimal price, bool stock, string desc)
        {
            return FProduct.CreateProduct(name, cat, price, stock, desc);
        }
        public static EProduct SelectProduct(int id)
        {
            return FProduct.SelectProduct(id);
        }
        public static List<EProduct> SelectProduct_Category(int cat)
        {
            return FProduct.SelectProduct_Category(cat);
        }
    }
}
