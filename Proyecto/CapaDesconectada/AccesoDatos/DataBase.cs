using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace AccesoDatos
{
    public class DataBase
    {
        public static string ConnectionString
        {
            get { 
                return ConfigurationManager.Conn


            }

        }

        public static object ConfigurationManager { get; private set; }
    }

    public static SqlConnection GetSqlConnection(){
    
    }
}
