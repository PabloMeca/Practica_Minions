using System.Configuration;
using System.Data.SqlClient;
using clsConstantes = BCR.PracticaMinions4.LIL.Constantes;

namespace BCR.PracticaMinions4.DAL
{
    /// <summary>
    ///     <createddate>2020-01-31</createddate>
    ///     <company>Grupo Babel</company>
    ///     <lastmodificationdate>2020-01-31</lastmodificationdate>
    ///     <lastmodificationdescription>
    ///         Se agregaron los comentarios a la clase.
    ///     </lastmodificationdescription>
    ///     <lastmodifierautor>Jeison Jiménez</lastmodifierautor>
    /// </summary>
    public class Conexion
    {
        // Obtiene la cadena de conección desde el archivo .config
        private static string cadenaConexion = ConfigurationManager.ConnectionStrings[clsConstantes.NOMBRECONEXION].ConnectionString;
        public SqlConnection conexion = new SqlConnection(cadenaConexion);

        /// <summary>
        ///     Abre la conección a la BD
        /// </summary>
        public void OpenConexion()
        {
            conexion.Open();
        }
        /// <summary>
        ///     Cierra la conección a la BD
        /// </summary>
        public void CloseConexion()
        {
            conexion.Close();
        }
    }
}
