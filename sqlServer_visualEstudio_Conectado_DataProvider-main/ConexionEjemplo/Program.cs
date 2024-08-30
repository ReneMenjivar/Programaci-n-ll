using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConexionEjemplo
{
    internal static class Program // Define la clase estática Program, accesible solo dentro del ensamblado
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread] // Indica que el modelo de subprocesos de la aplicación es de un solo subproceso de apartamento (STA)
        static void Main() // Método principal que inicia la aplicación
        {
            Application.EnableVisualStyles(); // Habilita los estilos visuales para la aplicación, permitiendo un aspecto más moderno
            Application.SetCompatibleTextRenderingDefault(false); // Establece el modo de renderizado de texto compatible con versiones anteriores
            Application.Run(new Form1()); // Inicia el bucle de mensajes de la aplicación y muestra el formulario Form1
        }
    }
}
