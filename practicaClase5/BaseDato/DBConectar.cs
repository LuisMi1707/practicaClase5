using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDato
{
    // Clase que gestiona la conexión a una base de datos SQL Server
    public class DBConectar
    {
        // Propiedad estática para obtener la cadena de conexión configurada
        public static string ConnectionString
        {
            get {

                // Obtiene la cadena de conexión desde el archivo de configuración (App.config o Web.config)
                string CadenaConexion = ConfigurationManager
                     .ConnectionStrings["NWConnection"]
                     .ConnectionString;

                // Crea un objeto SqlConnectionStringBuilder para manipular la cadena de conexión
                SqlConnectionStringBuilder conexionBuilder =
                    new SqlConnectionStringBuilder(CadenaConexion);

                // Si se ha definido un nombre de aplicación, lo agrega a la cadena de conexión
                conexionBuilder.ApplicationName =
                    ApplicationName ?? conexionBuilder.ApplicationName;

                // Si se ha definido un tiempo de espera (timeout) para la conexión, lo agrega a la cadena de conexión
                conexionBuilder.ConnectTimeout = (ConnectionTimeout > 0)
                    ? ConnectionTimeout : conexionBuilder.ConnectTimeout;

                // Devuelve la cadena de conexión final modificada
                return conexionBuilder.ToString();
            }
        }
        // Propiedad estática para almacenar el tiempo de espera de la conexión
        public static int ConnectionTimeout { get; set; }

        // Propiedad estática para almacenar el nombre de la aplicación
        public static string ApplicationName { get; set; }

        // Método que devuelve una conexión SQL abierta
        public static SqlConnection GetSqlConnection()
        {

            // Crea una nueva conexión SQL utilizando la cadena de conexión
            SqlConnection conexion = new SqlConnection(ConnectionString);

            // Abre la conexión a la base de datos
            conexion.Open();

            // Devuelve la conexión abierta
            return conexion;

        }

    }
}
