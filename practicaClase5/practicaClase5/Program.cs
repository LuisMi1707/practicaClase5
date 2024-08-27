using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practicaClase5
{
    // Clase principal de la aplicación
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread] // Indica que el modelo de subprocesos del programa es Single-Threaded Apartment (STA), necesario para Windows Forms.
        static void Main()
        {
            // Habilita estilos visuales para la aplicación (aplicación de estilos modernos de Windows)
            Application.EnableVisualStyles();

            // Establece que se use el motor de renderizado de texto compatible (opción predeterminada para Windows Forms)
            Application.SetCompatibleTextRenderingDefault(false);

            // Inicia la ejecución de la aplicación con el formulario principal (Form1)
            Application.Run(new Form1());
        }
    }
}

