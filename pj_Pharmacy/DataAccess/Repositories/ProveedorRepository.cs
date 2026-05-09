using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace pj_Pharmacy.DataAccess.Repositories
{
    /// <summary>
    /// Repositorio para operaciones CRUD de Proveedores.
    /// </summary>
    public static class ProveedorRepository
    {
        public static void Listar(DataGridView dgv)
        {
            DatabaseHelper.FillDataGridView(dgv, "ListSupp");
        }

        /// <summary>
        /// Retorna DataTable para llenar ComboBox de proveedores.
        /// </summary>
        public static DataTable ObtenerParaComboBox()
        {
            return DatabaseHelper.ExecuteReader("ListSupp");
        }

        public static bool Insertar(string ruc, string nombre, string direccion, string telefono)
        {
            return DatabaseHelper.ExecuteNonQuery("NuevosProveedores",
                new SqlParameter("@RUC", SqlDbType.VarChar) { Value = ruc },
                new SqlParameter("@NP", SqlDbType.VarChar) { Value = nombre },
                new SqlParameter("@Dir", SqlDbType.VarChar) { Value = direccion },
                new SqlParameter("@Tel", SqlDbType.VarChar) { Value = telefono }
            );
        }

        public static bool Actualizar(string ruc, string nombre, string direccion, string telefono)
        {
            return DatabaseHelper.ExecuteNonQuery("ActualizarProveedores",
                new SqlParameter("@RUC", SqlDbType.Char) { Value = ruc },
                new SqlParameter("@NP", SqlDbType.NVarChar) { Value = nombre },
                new SqlParameter("@Dir", SqlDbType.NVarChar) { Value = direccion },
                new SqlParameter("@Tel", SqlDbType.Char) { Value = telefono }
            );
        }
    }
}
