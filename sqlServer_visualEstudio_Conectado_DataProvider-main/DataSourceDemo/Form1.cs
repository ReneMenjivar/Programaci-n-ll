using System; 
using System.Windows.Forms;

namespace DataSourceDemo // Define el espacio de nombres para la aplicación
{
    public partial class Form1 : Form // Define la clase Form1 que hereda de la clase base Form
    {
        public Form1() // Constructor de la clase Form1
        {
            InitializeComponent(); // Inicializa los componentes del formulario
        }

        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e) // Evento que se dispara al hacer clic en el botón de guardar
        {
            SaveData(); // Llama al método SaveData para guardar los datos
        }

        private void Form1_Load(object sender, EventArgs e) // Evento que se dispara al cargar el formulario
        {
            // Carga los datos en la tabla 'Customers' del dataset 'northwindDataSet'
            this.customersTableAdapter.Fill(this.northwindDataSet.Customers);
        }

        private void customersDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e) // Evento que se dispara al hacer clic en una celda del DataGridView
        {
            // Aquí se puede manejar la acción al hacer clic en una celda, si es necesario
        }

        private void SaveData() // Método para guardar los datos
        {
            try // Inicia un bloque de código que puede generar excepciones
            {
                this.Validate(); // Valida los datos del formulario
                this.customersBindingSource.EndEdit(); // Finaliza la edición del origen de datos de clientes
                this.tableAdapterManager.UpdateAll(this.northwindDataSet); // Actualiza todos los cambios en el dataset a la base de datos
                MessageBox.Show("Data saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); // Muestra un mensaje de éxito al usuario
            }
            catch (Exception ex) // Captura cualquier excepción que ocurra en el bloque try
            {
                MessageBox.Show($"Error saving data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Muestra un mensaje de error al usuario
            }
        }
    }
}
