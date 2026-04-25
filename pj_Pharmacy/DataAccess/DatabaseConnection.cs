using System;
using System.Data;
using System.Data.SqlClient;

namespace pj_Pharmacy.DataAccess
{
    /// <summary>
    /// Gestiona la cadena de conexión y provee conexiones SQL Server.
    /// Cada operación debe abrir y cerrar su propia conexión (patrón using).
    /// </summary>
    public static class DatabaseConnection
    {
        private static string _connectionString;

        /// <summary>
        /// Último error de conexión (para diagnóstico).
        /// </summary>
        public static string UltimoError { get; private set; }

        /// <summary>
        /// Inicializa la conexión con credenciales de usuario SQL Server.
        /// Se llama una vez al autenticarse exitosamente.
        /// </summary>
        public static void Initialize(string server, string user, string password, string database)
        {
            _connectionString = $"Server={server};Database={database};User ID={user};Password={password};Connect Timeout=10;";
        }

        /// <summary>
        /// Verifica si la conexión puede establecerse con las credenciales proporcionadas.
        /// Retorna true si la conexión es exitosa, false en caso contrario.
        /// Guarda el error real en UltimoError para diagnóstico.
        /// </summary>
        public static bool TestConnection(string server, string user, string password, string database)
        {
            string testConnectionString = $"Server={server};Database={database};User ID={user};Password={password};Connect Timeout=10;";
            try
            {
                using (SqlConnection conn = new SqlConnection(testConnectionString))
                {
                    conn.Open();
                    return conn.State == ConnectionState.Open;
                }
            }
            catch (SqlException ex)
            {
                UltimoError = ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                UltimoError = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Detecta automáticamente el nombre del servidor SQL.
        /// Prueba múltiples formatos comunes de instancia.
        /// </summary>
        public static string DetectarServidor()
        {
            string machineName = Environment.MachineName;

            // Lista de formatos comunes de servidor SQL
            string[] servidores = new string[]
            {
                machineName,                        // Instancia default: MAQUINA
                ".",                                 // Instancia default local
                "localhost",                         // Instancia default local
                machineName + "\\SQLEXPRESS",        // SQL Express
                ".\\SQLEXPRESS",                     // SQL Express local
                machineName + "\\MSSQLSERVER",       // Instancia con nombre
                "(local)",                           // Alias local
            };

            foreach (string servidor in servidores)
            {
                try
                {
                    // Probar conexión con Windows Auth para detectar el servidor
                    string testConn = $"Server={servidor};Database=master;Integrated Security=True;Connect Timeout=3;";
                    using (SqlConnection conn = new SqlConnection(testConn))
                    {
                        conn.Open();
                        if (conn.State == ConnectionState.Open)
                            return servidor;
                    }
                }
                catch
                {
                    // Continuar con el siguiente formato
                }
            }

            // Si ninguno funciona, retornar el nombre de la máquina por defecto
            return machineName;
        }

        /// <summary>
        /// Crea una nueva instancia de SqlConnection con la cadena configurada.
        /// SIEMPRE usar dentro de un bloque using.
        /// </summary>
        public static SqlConnection CreateConnection()
        {
            if (string.IsNullOrEmpty(_connectionString))
                throw new InvalidOperationException("La conexión no ha sido inicializada. Llame a Initialize() primero.");

            return new SqlConnection(_connectionString);
        }

        /// <summary>
        /// Retorna la cadena de conexión actual (para diagnóstico).
        /// </summary>
        public static bool IsInitialized => !string.IsNullOrEmpty(_connectionString);

        /// <summary>
        /// Limpia la cadena de conexión (logout).
        /// </summary>
        public static void Reset()
        {
            _connectionString = null;
            UltimoError = null;
        }
    }
}
