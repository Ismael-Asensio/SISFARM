using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace pj_Pharmacy.DataAccess.Repositories
{
    /// <summary>
    /// Repositorio para operaciones CRUD de Productos.
    /// </summary>
    public static class ProductoRepository
    {
        public static void Listar(DataGridView dgv)
        {
            DatabaseHelper.FillDataGridView(dgv, "ListProd");
        }

        public static void ListarInactivos(DataGridView dgv)
        {
            DatabaseHelper.FillDataGridView(dgv, "ListProdIn");
        }

        public static bool Insertar(string nombre, string descripcion, float precio, int existencia, string fechaElab, string rucProveedor)
        {
            return DatabaseHelper.ExecuteNonQuery("NuevoProducto",
                new SqlParameter("@NP", SqlDbType.VarChar) { Value = nombre },
                new SqlParameter("@Desc", SqlDbType.VarChar) { Value = descripcion },
                new SqlParameter("@PP", SqlDbType.Float) { Value = precio },
                new SqlParameter("@Exist", SqlDbType.Int) { Value = existencia },
                new SqlParameter("@FE", SqlDbType.NVarChar) { Value = fechaElab },
                new SqlParameter("@RUC", SqlDbType.NVarChar) { Value = rucProveedor }
            );
        }

        public static bool Actualizar(string nombre, string descripcion, float precio, int existencia, string fechaElab, int codigoProducto)
        {
            return DatabaseHelper.ExecuteNonQuery("ActualizarProducto",
                new SqlParameter("@NP", SqlDbType.VarChar) { Value = nombre },
                new SqlParameter("@Desc", SqlDbType.VarChar) { Value = descripcion },
                new SqlParameter("@PP", SqlDbType.Float) { Value = precio },
                new SqlParameter("@Exist", SqlDbType.Int) { Value = existencia },
                new SqlParameter("@FE", SqlDbType.NVarChar) { Value = fechaElab },
                new SqlParameter("@IDP", SqlDbType.Int) { Value = codigoProducto }
            );
        }

        public static bool DarDeBaja(int codigoProducto)
        {
            return DatabaseHelper.ExecuteNonQuery("DarBProducto",
                new SqlParameter("@CodP", SqlDbType.Int) { Value = codigoProducto }
            );
        }

        public static bool CambiarReceta(int codigoProducto)
        {
            return DatabaseHelper.ExecuteNonQuery("CamRec",
                new SqlParameter("@IDS", SqlDbType.Int) { Value = codigoProducto }
            );
        }
    }
}
