using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DatosLayer
{
    public class CustomerRepository
    {

        public List<Customers> ObtenerTodos() // Método para obtener todos los clientes
        {
            using (var conexion = DataBase.GetSqlConnection()) // Abre una conexión a la base de datos
            {
                String selectFrom = ""; // Inicializa una cadena para la consulta SQL
                selectFrom = selectFrom + "SELECT [CustomerID] " + "\n"; // Añade la selección del campo CustomerID
                selectFrom = selectFrom + "      ,[CompanyName] " + "\n"; // Añade la selección del campo CompanyName
                selectFrom = selectFrom + "      ,[ContactName] " + "\n"; // Añade la selección del campo ContactName
                selectFrom = selectFrom + "      ,[ContactTitle] " + "\n"; // Añade la selección del campo ContactTitle
                selectFrom = selectFrom + "      ,[Address] " + "\n"; // Añade la selección del campo Address
                selectFrom = selectFrom + "      ,[City] " + "\n"; // Añade la selección del campo City
                selectFrom = selectFrom + "      ,[Region] " + "\n"; // Añade la selección del campo Region
                selectFrom = selectFrom + "      ,[PostalCode] " + "\n"; // Añade la selección del campo PostalCode
                selectFrom = selectFrom + "      ,[Country] " + "\n"; // Añade la selección del campo Country
                selectFrom = selectFrom + "      ,[Phone] " + "\n"; // Añade la selección del campo Phone
                selectFrom = selectFrom + "      ,[Fax] " + "\n"; // Añade la selección del campo Fax
                selectFrom = selectFrom + "  FROM [dbo].[Customers]"; // Especifica la tabla de donde se seleccionan los datos

                using (SqlCommand comando = new SqlCommand(selectFrom, conexion)) // Crea un comando SQL con la consulta y la conexión
                {
                    SqlDataReader reader = comando.ExecuteReader(); // Ejecuta el comando y obtiene un lector de datos
                    List<Customers> Customers = new List<Customers>(); // Inicializa una lista para almacenar los clientes

                    while (reader.Read()) // Lee los datos del lector mientras haya registros
                    {
                        var customers = LeerDelDataReader(reader); // Llama al método para leer los datos del cliente
                        Customers.Add(customers); // Agrega el cliente a la lista
                    }
                    return Customers; // Devuelve la lista de clientes
                }
            }
        }

        public Customers ObtenerPorID(string id) // Método para obtener un cliente por su ID
        {
            using (var conexion = DataBase.GetSqlConnection()) // Abre una conexión a la base de datos
            {
                String selectForID = ""; // Inicializa una cadena para la consulta SQL
                selectForID = selectForID + "SELECT [CustomerID] " + "\n"; // Añade la selección del campo CustomerID
                selectForID = selectForID + "      ,[CompanyName] " + "\n"; // Añade la selección del campo CompanyName
                selectForID = selectForID + "      ,[ContactName] " + "\n"; // Añade la selección del campo ContactName
                selectForID = selectForID + "      ,[ContactTitle] " + "\n"; // Añade la selección del campo ContactTitle
                selectForID = selectForID + "      ,[Address] " + "\n"; // Añade la selección del campo Address
                selectForID = selectForID + "      ,[City] " + "\n"; // Añade la selección del campo City
                selectForID = selectForID + "      ,[Region] " + "\n"; // Añade la selección del campo Region
                selectForID = selectForID + "      ,[PostalCode] " + "\n"; // Añade la selección del campo PostalCode
                selectForID = selectForID + "      ,[Country] " + "\n"; // Añade la selección del campo Country
                selectForID = selectForID + "      ,[Phone] " + "\n"; // Añade la selección del campo Phone
                selectForID = selectForID + "      ,[Fax] " + "\n"; // Añade la selección del campo Fax
                selectForID = selectForID + "  FROM [dbo].[Customers] " + "\n"; // Especifica la tabla de donde se seleccionan los datos
                selectForID = selectForID + $"  Where CustomerID = @customerId"; // Filtra por el CustomerID proporcionado

                using (SqlCommand comando = new SqlCommand(selectForID, conexion)) // Crea un comando SQL con la consulta y la conexión
                {
                    comando.Parameters.AddWithValue("customerId", id); // Agrega el parámetro customerId al comando

                    var reader = comando.ExecuteReader(); // Ejecuta el comando y obtiene un lector de datos
                    Customers customers = null; // Inicializa la variable para almacenar el cliente encontrado
                                                // Validamos si hay un registro
                    if (reader.Read()) // Si hay un registro en el lector
                    {
                        customers = LeerDelDataReader(reader); // Llama al método para leer los datos del cliente
                    }
                    return customers; // Devuelve el cliente encontrado o null si no se encontró
                }
            }
        }

        public Customers LeerDelDataReader(SqlDataReader reader) // Método para leer un cliente del SqlDataReader
        {
            Customers customers = new Customers(); // Crea una nueva instancia de Customers
            customers.CustomerID = reader["CustomerID"] == DBNull.Value ? " " : (String)reader["CustomerID"]; // Asigna el CustomerID, manejando valores nulos
            customers.CompanyName = reader["CompanyName"] == DBNull.Value ? "" : (String)reader["CompanyName"]; // Asigna el CompanyName, manejando valores nulos
            customers.ContactName = reader["ContactName"] == DBNull.Value ? "" : (String)reader["ContactName"]; // Asigna el ContactName, manejando valores nulos
            customers.ContactTitle = reader["ContactTitle"] == DBNull.Value ? "" : (String)reader["ContactTitle"]; // Asigna el ContactTitle, manejando valores nulos
            customers.Address = reader["Address"] == DBNull.Value ? "" : (String)reader["Address"]; // Asigna el Address, manejando valores nulos
            customers.City = reader["City"] == DBNull.Value ? "" : (String)reader["City"]; // Asigna el City, manejando valores nulos
            customers.Region = reader["Region"] == DBNull.Value ? "" : (String)reader["Region"]; // Asigna el Region, manejando valores nulos
            customers.PostalCode = reader["PostalCode"] == DBNull.Value ? "" : (String)reader["PostalCode"]; // Asigna el PostalCode, manejando valores nulos
            customers.Country = reader["Country"] == DBNull.Value ? "" : (String)reader["Country"]; // Asigna el Country, manejando valores nulos
            customers.Phone = reader["Phone"] == DBNull.Value ? "" : (String)reader["Phone"]; // Asigna el Phone, manejando valores nulos
            customers.Fax = reader["Fax"] == DBNull.Value ? "" : (String)reader["Fax"]; // Asigna el Fax, manejando valores nulos
            return customers; // Devuelve el objeto Customers con los datos leídos
        }

        //-------------
        public int InsertarCliente(Customers customer) // Método para insertar un nuevo cliente
        {
            using (var conexion = DataBase.GetSqlConnection()) // Abre una conexión a la base de datos
            {
                String insertInto = ""; // Inicializa una cadena para la consulta SQL
                insertInto = insertInto + "INSERT INTO [dbo].[Customers] " + "\n"; // Inicia la consulta de inserción
                insertInto = insertInto + "           ([CustomerID] " + "\n"; // Especifica el campo CustomerID
                insertInto = insertInto + "           ,[CompanyName] " + "\n"; // Especifica el campo CompanyName
                insertInto = insertInto + "           ,[ContactName] " + "\n"; // Especifica el campo ContactName
                insertInto = insertInto + "           ,[ContactTitle] " + "\n"; // Especifica el campo ContactTitle
                insertInto = insertInto + "           ,[Address] " + "\n"; // Especifica el campo Address
                insertInto = insertInto + "           ,[City]) " + "\n"; // Especifica el campo City
                insertInto = insertInto + "     VALUES " + "\n"; // Inicia la sección de valores a insertar
                insertInto = insertInto + "           (@CustomerID " + "\n"; // Especifica el valor para CustomerID
                insertInto = insertInto + "           ,@CompanyName " + "\n"; // Especifica el valor para CompanyName
                insertInto = insertInto + "           ,@ContactName " + "\n"; // Especifica el valor para ContactName
                insertInto = insertInto + "           ,@ContactTitle " + "\n"; // Especifica el valor para ContactTitle
                insertInto = insertInto + "           ,@Address " + "\n"; // Especifica el valor para Address
                insertInto = insertInto + "           ,@City)"; // Especifica el valor para City

                using (var comando = new SqlCommand(insertInto, conexion)) // Crea un comando SQL con la consulta y la conexión
                {
                    int insertados = parametrosCliente(customer, comando); // Llama al método para agregar los parámetros del cliente y ejecuta el comando
                    return insertados; // Devuelve el número de filas insertadas
                }
            }
        }

        //-------------
        public int ActualizarCliente(Customers customer) // Método para actualizar un cliente existente
        {
            using (var conexion = DataBase.GetSqlConnection()) // Abre una conexión a la base de datos
            {
                String ActualizarCustomerPorID = ""; // Inicializa una cadena para la consulta SQL
                ActualizarCustomerPorID = ActualizarCustomerPorID + "UPDATE [dbo].[Customers] " + "\n"; // Inicia la consulta de actualización
                ActualizarCustomerPorID = ActualizarCustomerPorID + "   SET [CustomerID] = @CustomerID " + "\n"; // Especifica el campo CustomerID a actualizar
                ActualizarCustomerPorID = ActualizarCustomerPorID + "      ,[CompanyName] = @CompanyName " + "\n"; // Especifica el campo CompanyName a actualizar
                ActualizarCustomerPorID = ActualizarCustomerPorID + "      ,[ContactName] = @ContactName " + "\n"; // Especifica el campo ContactName a actualizar
                ActualizarCustomerPorID = ActualizarCustomerPorID + "      ,[ContactTitle] = @ContactTitle " + "\n"; // Especifica el campo ContactTitle a actualizar
                ActualizarCustomerPorID = ActualizarCustomerPorID + "      ,[Address] = @Address " + "\n"; // Especifica el campo Address a actualizar
                ActualizarCustomerPorID = ActualizarCustomerPorID + "      ,[City] = @City " + "\n"; // Especifica el campo City a actualizar
                ActualizarCustomerPorID = ActualizarCustomerPorID + " WHERE CustomerID= @CustomerID"; // Especifica la condición para la actualización

                using (var comando = new SqlCommand(ActualizarCustomerPorID, conexion)) // Crea un comando SQL con la consulta y la conexión
                {
                    int actualizados = parametrosCliente(customer, comando); // Llama al método para agregar los parámetros del cliente y ejecuta el comando
                    return actualizados; // Devuelve el número de filas actualizadas
                }
            }
        }

        public int parametrosCliente(Customers customer, SqlCommand comando) // Método para agregar parámetros al comando SQL
        {
            comando.Parameters.AddWithValue("CustomerID", customer.CustomerID); // Agrega el parámetro CustomerID
            comando.Parameters.AddWithValue("CompanyName", customer.CompanyName); // Agrega el parámetro CompanyName
            comando.Parameters.AddWithValue("ContactName", customer.ContactName); // Agrega el parámetro ContactName
            comando.Parameters.AddWithValue("ContactTitle", customer.ContactTitle); // Agrega el parámetro ContactTitle
            comando.Parameters.AddWithValue("Address", customer.Address); // Agrega el parámetro Address
            comando.Parameters.AddWithValue("City", customer.City); // Agrega el parámetro City
            var insertados = comando.ExecuteNonQuery(); // Ejecuta el comando y obtiene el número de filas afectadas
            return insertados; // Devuelve el número de filas afectadas
        }

        public int EliminarCliente(string id) // Método para eliminar un cliente por su ID
        {
            using (var conexion = DataBase.GetSqlConnection()) // Abre una conexión a la base de datos
            {
                String EliminarCliente = ""; // Inicializa una cadena para la consulta SQL
                EliminarCliente = EliminarCliente + "DELETE FROM [dbo].[Customers] " + "\n"; // Inicia la consulta de eliminación
                EliminarCliente = EliminarCliente + "      WHERE CustomerID = @CustomerID"; // Especifica la condición para la eliminación

                using (SqlCommand comando = new SqlCommand(EliminarCliente, conexion)) // Crea un comando SQL con la consulta y la conexión
                {
                    comando.Parameters.AddWithValue("@CustomerID", id); // Agrega el parámetro CustomerID al comando
                    int eliminados = comando.ExecuteNonQuery(); // Ejecuta el comando y obtiene el número de filas eliminadas
                    return eliminados; // Devuelve el número de filas eliminadas
                }
            }
        }
    }
}
