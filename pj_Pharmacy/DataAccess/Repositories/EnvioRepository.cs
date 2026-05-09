using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace pj_Pharmacy.DataAccess.Repositories
{
    /// <summary>
    /// Repositorio para operaciones CRUD de Envíos.
    /// </summary>
    public static class EnvioRepository
    {
        public static void Listar(DataGridView dgv)
        {
            DatabaseHelper.FillDataGridView(dgv, "ListEnv");
        }

        public static bool Insertar(string origen, string destinatario, string dni)
        {
            return DatabaseHelper.ExecuteNonQuery("NuevoEnvio",
                new SqlParameter("@Origen", SqlDbType.VarChar) { Value = origen },
                new SqlParameter("@Destinatario", SqlDbType.VarChar) { Value = destinatario },
                new SqlParameter("@DNI", SqlDbType.VarChar) { Value = dni }
            );
        }

        public static bool CambiarEstado(int idEnvio)
        {
            return DatabaseHelper.ExecuteNonQuery("CambiarEstadoEnvio",
                new SqlParameter("@IdEnvio", SqlDbType.Int) { Value = idEnvio }
            );
        }

        public static bool DarDeBaja(int idEnvio)
        {
            return DatabaseHelper.ExecuteNonQuery("DarBEnv",
                new SqlParameter("@IDS", SqlDbType.Int) { Value = idEnvio }
            );
        }
    }
}
