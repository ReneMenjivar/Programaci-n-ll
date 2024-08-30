using System; 
using System.Collections.Generic;
using System.ComponentModel; 
using System.Data; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace DataSourceDemo // Define el espacio de nombres para la aplicación
{
    public partial class Form2 : Form // Define la clase Form2 que hereda de la clase base Form
    {
        public Form2() // Constructor de la clase Form2
        {
            InitializeComponent(); // Inicializa los componentes del formulario
        }

        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e) // Evento que se dispara al hacer clic en el botón de guardar
        {
            this.Validate(); // Valida los datos del formulario
            this.customersBindingSource.EndEdit(); // Finaliza la edición del origen de datos de clientes
            this.tableAdapterManager.UpdateAll(this.northwindDataSet); // Actualiza todos los cambios en el dataset a la base de datos
        }

        private void Form2_Load(object sender, EventArgs e) // Evento que se dispara al cargar el formulario
        {
            // Carga los datos en la tabla 'Customers' del dataset 'northwindDataSet'
            this.customersTableAdapter.Fill(this.northwindDataSet.Customers);
        }

        private void cajaTextoID_Click(object sender, EventArgs e) // Evento que se dispara al hacer clic en el cuadro de texto ID
        {
            // Este evento puede ser utilizado para manejar acciones al hacer clic en el cuadro de texto
        }

        private void cajaTextoID_KeyPress(object sender, KeyPressEventArgs e) // Evento que se dispara al presionar una tecla en el cuadro de texto ID
        {
            if (e.KeyChar == (char)13) // Verifica si la tecla presionada es 'Enter' (código ASCII 13)
            {
                // Busca el índice del cliente en el origen de datos usando el valor del cuadro de texto
                var index = customersBindingSource.Find("customerID", cajaTextoID.Text); // Asegúrate de usar cajaTextoID.Text para obtener el valor
                if (index > -1) // Verifica si se encontró el índice
                {
                    customersBindingSource.Position = index; // Establece la posición del origen de datos al índice encontrado
                    return; // Sale del método si se encontró el elemento
                }
                else // Si no se encontró el elemento
                {
                    MessageBox.Show("Elemento no encontrado"); // Muestra un mensaje de error al usuario
                }
            };
        }
    }
}
