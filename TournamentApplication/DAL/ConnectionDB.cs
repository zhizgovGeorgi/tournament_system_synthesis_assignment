using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class ConnectionDB
    {
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection("server=studmysql01.fhict.local;database=dbi463263;uid=dbi463263;pwd=userTry;SslMode=none");
        }
    }
}
