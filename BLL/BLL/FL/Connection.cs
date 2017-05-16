using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FL
{
    class Connection
    {
        public static SqlConnection Con = new SqlConnection(@"server=(localdb)\MSSQLLocalDB;database=Restaurant;Trusted_Connection=true;MultipleActiveResultSets=True;");
    }
}
