using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace pj_Pharmacy.DataAccess.Repositories
{
    /// <summary>
    /// Repositorio para operaciones de Compras y Detalle de Compras.
    /// </summary>
    public static class CompraRepository
    {
        public static void Listar(DataGridView dgv, int pageNumber = 1, int pageSize = 100)
        {
            int offset = (pageNumber - 1) * pageSize;
            DatabaseHelper.FillDataGridView(dgv, "ListCompra",
                new SqlParameter("@Offset", SqlDbType.Int) { Value = offset },
                new SqlParameter("@Fetch", SqlDbType.Int) { Value = pageSize });
        }

        public static int ObtenerTotalPaginas(int pageSize = 100)
        {
            object result = DatabaseHelper.ExecuteScalar("CountCompra");
            if (result != null && int.TryParse(result.ToString(), out int totalRecords))
            {
                return (int)System.Math.Ceiling((double)totalRecords / pageSize);
            }
            return 1;
        }

        public static bool GestionarCompra(string rucProveedor, int cantidad, string codigoProducto, float precioCompra)
        {
            return DatabaseHelper.ExecuteNonQuery("GestionDeCompras",
                new SqlParameter("@NR", SqlDbType.VarChar) { Value = rucProveedor },
                new SqlParameter("@cc", SqlDbType.Int) { Value = cantidad },
                new SqlParameter("@CP", SqlDbType.VarChar) { Value = codigoProducto },
                new SqlParameter("@pc", SqlDbType.Float) { Value = precioCompra }
            );
        }
    }
}
