// Importa los namespaces necesarios para el funcionamiento de la aplicación.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; // Para trabajar con SQL Server
using DatosLayer; // Capa de datos personalizada
using System.Net;
using System.Reflection; // Para la manipulación de metadatos de clases

// Define el espacio de nombres de la aplicación
namespace ConexionEjemplo
{
    // Define la clase parcial Form1 que hereda de Form, la clase base para formularios de Windows Forms
    public partial class Form1 : Form
    {
        // Instancia un objeto de la clase CustomerRepository para acceder a la capa de datos
        CustomerRepository customerRepository = new CustomerRepository();

        // Constructor de la clase Form1
        public Form1()
        {
            InitializeComponent(); // Inicializa los componentes del formulario
        }

        // Método que se ejecuta cuando se hace clic en el botón "Cargar"
        private void btnCargar_Click(object sender, EventArgs e)
        {
            var Customers = customerRepository.ObtenerTodos(); // Obtiene todos los clientes
            dataGrid.DataSource = Customers; // Asigna los clientes al control dataGrid para mostrar los datos
        }

        // Método que se ejecuta cuando el texto en el textBox1 cambia
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Código comentado que filtra los clientes según el texto ingresado en el TextBox
            // var filtro = Customers.FindAll( X => X.CompanyName.StartsWith(tbFiltro.Text));
            // dataGrid.DataSource = filtro;
        }

        // Método que se ejecuta cuando el formulario se carga
        private void Form1_Load(object sender, EventArgs e)
        {
            // Código comentado que establece configuraciones para la conexión a la base de datos
            /*  DatosLayer.DataBase.ApplicationName = "Programacion 2 ejemplo";
                DatosLayer.DataBase.ConnectionTimeout = 30;
                string cadenaConexion = DatosLayer.DataBase.ConnectionString;
                var conxion = DatosLayer.DataBase.GetSqlConnection();
            */
        }

        // Método que se ejecuta cuando se hace clic en el botón "Buscar"
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var cliente = customerRepository.ObtenerPorID(txtBuscar.Text); // Obtiene un cliente por su ID
            // Muestra la información del cliente en los TextBoxes correspondientes
            tboxCustomerID.Text = cliente.CustomerID;
            tboxCompanyName.Text = cliente.CompanyName;
            tboxContacName.Text = cliente.ContactName;
            tboxContactTitle.Text = cliente.ContactTitle;
            tboxAddress.Text = cliente.Address;
            tboxCity.Text = cliente.City;
        }

        // Método que se ejecuta cuando se hace clic en el label4
        private void label4_Click(object sender, EventArgs e)
        {

        }

        // Método que se ejecuta cuando se hace clic en el botón "Insertar"
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            var resultado = 0; // Variable para almacenar el resultado de la operación

            var nuevoCliente = ObtenerNuevoCliente(); // Obtiene un nuevo cliente desde los TextBoxes

            // Código comentado que valida los campos antes de insertar un nuevo cliente
            /*
            if (tboxCustomerID.Text != "" || 
                  tboxCompanyName.Text !="" ||
                  tboxContacName.Text != "" ||
                  tboxContacName.Text != "" ||
                  tboxAddress.Text != ""    ||
                  tboxCity.Text != "")
              {
                  resultado = customerRepository.InsertarCliente(nuevoCliente);
                  MessageBox.Show("Guardado" + "Filas modificadas = " + resultado);
              }
              else {
                  MessageBox.Show("Debe completar los campos por favor");
              }

            */

            // Validaciones adicionales comentadas para asegurar que no hay campos vacíos
            /*
            if (nuevoCliente.CustomerID == "") {
                MessageBox.Show("El Id en el usuario debe de completarse");
               return;    
            }

            if (nuevoCliente.ContactName == "")
            {
                MessageBox.Show("El nombre de usuario debe de completarse");
                return;
            }
            
            if (nuevoCliente.ContactTitle == "")
            {
                MessageBox.Show("El contacto de usuario debe de completarse");
                return;
            }
            if (nuevoCliente.Address == "")
            {
                MessageBox.Show("la direccion de usuario debe de completarse");
                return;
            }
            if (nuevoCliente.City == "")
            {
                MessageBox.Show("La ciudad de usuario debe de completarse");
                return;
            }

            */

            // Si la validación es correcta, inserta el nuevo cliente en la base de datos
            if (validarCampoNull(nuevoCliente) == false)
            {
                resultado = customerRepository.InsertarCliente(nuevoCliente);
                MessageBox.Show("Guardado" + "Filas modificadas = " + resultado);
            }
            else
            {
                MessageBox.Show("Debe completar los campos por favor");
            }
        }

        // Método que valida si algún campo del objeto está vacío
        public Boolean validarCampoNull(Object objeto)
        {

            // Recorre todas las propiedades del objeto
            foreach (PropertyInfo property in objeto.GetType().GetProperties())
            {
                object value = property.GetValue(objeto, null); // Obtiene el valor de la propiedad
                if ((string)value == "")
                { // Si el valor es una cadena vacía, retorna true
                    return true;
                }
            }
            return false; // Si no hay campos vacíos, retorna false
        }

        // Método que se ejecuta cuando se hace clic en el label5
        private void label5_Click(object sender, EventArgs e)
        {

        }

        // Método que se ejecuta cuando se hace clic en el botón "Modificar"
        private void btModificar_Click(object sender, EventArgs e)
        {
            var actualizarCliente = ObtenerNuevoCliente(); // Obtiene el cliente actualizado desde los TextBoxes
            int actualizadas = customerRepository.ActualizarCliente(actualizarCliente); // Actualiza el cliente en la base de datos
            MessageBox.Show($"Filas actualizadas = {actualizadas}"); // Muestra un mensaje con el número de filas actualizadas
        }

        // Método que obtiene un nuevo cliente a partir de los valores de los TextBoxes
        private Customers ObtenerNuevoCliente()
        {

            var nuevoCliente = new Customers
            {
                CustomerID = tboxCustomerID.Text,
                CompanyName = tboxCompanyName.Text,
                ContactName = tboxContacName.Text,
                ContactTitle = tboxContactTitle.Text,
                Address = tboxAddress.Text,
                City = tboxCity.Text
            };

            return nuevoCliente; // Retorna el objeto cliente
        }

        // Método que se ejecuta cuando se hace clic en el botón "Eliminar"
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int elimindas = customerRepository.EliminarCliente(tboxCustomerID.Text); // Elimina el cliente de la base de datos usando el CustomerID
            MessageBox.Show("Filas eliminadas = " + elimindas); // Muestra un mensaje con el número de filas eliminadas
        }
    }
}

