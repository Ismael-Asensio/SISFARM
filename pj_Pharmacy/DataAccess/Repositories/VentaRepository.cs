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
        public static void Listar(DataGridView dgv)
        {
            DatabaseHelper.FillDataGridView(dgv, "ListVent");
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
