using System; // Importa el espacio de nombres para funcionalidades básicas de C#
using System.Collections.Generic; // Importa el espacio de nombres para colecciones genéricas
using System.Linq; // Importa el espacio de nombres para LINQ (Language Integrated Query)
using System.Threading.Tasks; // Importa el espacio de nombres para programación asíncrona
using System.Windows.Forms; // Importa el espacio de nombres para formularios de Windows

namespace DataSourceDemo // Define el espacio de nombres para la aplicación
{
    internal static class Program // Define la clase estática Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread] // Indica que el modelo de subprocesos de la aplicación es de un solo subproceso de apartamento (STA)
        static void Main() // Método principal que inicia la aplicación
        {
            Application.EnableVisualStyles(); // Habilita los estilos visuales para la aplicación
            Application.SetCompatibleTextRenderingDefault(false); // Establece el modo de renderizado de texto compatible
            Application.Run(new Form2()); // Inicia la aplicación y muestra el formulario Form2
        }
    }
}
