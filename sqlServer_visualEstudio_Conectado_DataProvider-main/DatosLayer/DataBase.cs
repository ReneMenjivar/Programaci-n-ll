using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace DatosLayer
{
    public class DataBase // Define la clase pública DataBase
    {
        public static string ConnectionString // Propiedad estática para obtener la cadena de conexión
        {
            get // Getter de la propiedad ConnectionString
            {
                // Obtiene la cadena de conexión desde el archivo de configuración
                string CadenaConexion = ConfigurationManager
                    .ConnectionStrings["NWConnection"]
                    .ConnectionString;

                // Crea un SqlConnectionStringBuilder para construir la cadena de conexión
                SqlConnectionStringBuilder conexionBuilder =
                    new SqlConnectionStringBuilder(CadenaConexion);

                // Establece el nombre de la aplicación en la cadena de conexión
                conexionBuilder.ApplicationName =
                    ApplicationName ?? conexionBuilder.ApplicationName;

                // Establece el tiempo de espera de conexión, si es mayor que 0
                conexionBuilder.ConnectTimeout = (ConnectionTimeout > 0)
                    ? ConnectionTimeout : conexionBuilder.ConnectTimeout;

                return conexionBuilder.ToString(); // Devuelve la cadena de conexión construida
            }
        }

        public static int ConnectionTimeout { get; set; } // Propiedad estática para establecer el tiempo de espera de conexión
        public static string ApplicationName { get; set; } // Propiedad estática para establecer el nombre de la aplicación

        public static SqlConnection GetSqlConnection() // Método estático para obtener una nueva conexión SQL
        {
            SqlConnection conexion = new SqlConnection(ConnectionString); // Crea una nueva instancia de SqlConnection con la cadena de conexión
            conexion.Open(); // Abre la conexión
            return conexion; // Devuelve la conexión abierta
        }
    }
}
