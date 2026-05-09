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
        public static void Listar(DataGridView dgv, int pageNumber = 1, int pageSize = 100)
        {
            int offset = (pageNumber - 1) * pageSize;
            DatabaseHelper.FillDataGridView(dgv, "ListProd",
                new SqlParameter("@Offset", SqlDbType.Int) { Value = offset },
                new SqlParameter("@Fetch", SqlDbType.Int) { Value = pageSize });
        }

        public static void ListarInactivos(DataGridView dgv, int pageNumber = 1, int pageSize = 100)
        {
            int offset = (pageNumber - 1) * pageSize;
            DatabaseHelper.FillDataGridView(dgv, "ListProdIn",
                new SqlParameter("@Offset", SqlDbType.Int) { Value = offset },
                new SqlParameter("@Fetch", SqlDbType.Int) { Value = pageSize });
        }

        public static int ObtenerTotalPaginas(bool activos = true, int pageSize = 100)
        {
            object result = DatabaseHelper.ExecuteScalar("CountProd",
                new SqlParameter("@Estado", SqlDbType.Bit) { Value = activos ? 1 : 0 });
            
            if (result != null && int.TryParse(result.ToString(), out int totalRecords))
            {
                return (int)System.Math.Ceiling((double)totalRecords / pageSize);
            }
            return 1;
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
