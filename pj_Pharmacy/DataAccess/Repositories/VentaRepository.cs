using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace pj_Pharmacy.DataAccess.Repositories
{
    /// <summary>
    /// Repositorio para operaciones de Ventas y Detalle de Ventas.
    /// </summary>
    public static class VentaRepository
    {
        public static void Listar(DataGridView dgv, int pageNumber = 1, int pageSize = 100)
        {
            int offset = (pageNumber - 1) * pageSize;
            DatabaseHelper.FillDataGridView(dgv, "ListVent",
                new SqlParameter("@Offset", SqlDbType.Int) { Value = offset },
                new SqlParameter("@Fetch", SqlDbType.Int) { Value = pageSize });
        }

        public static int ObtenerTotalPaginas(int pageSize = 100)
        {
            object result = DatabaseHelper.ExecuteScalar("CountVent");
            if (result != null && int.TryParse(result.ToString(), out int totalRecords))
            {
                return (int)System.Math.Ceiling((double)totalRecords / pageSize);
            }
            return 1;
        }

        public static bool GestionarVenta(int idCliente, int vendedorId, int codigoProducto, int cantidadVendida)
        {
            return DatabaseHelper.ExecuteNonQuery("GestionarVentas",
                new SqlParameter("@IDC", SqlDbType.Int) { Value = idCliente },
                new SqlParameter("@VID", SqlDbType.Int) { Value = vendedorId },
                new SqlParameter("@CP", SqlDbType.Int) { Value = codigoProducto },
                new SqlParameter("@cv", SqlDbType.Int) { Value = cantidadVendida }
            );
        }
    }
}
