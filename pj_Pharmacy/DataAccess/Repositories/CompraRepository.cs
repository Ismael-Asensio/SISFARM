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
        public static void Listar(DataGridView dgv)
        {
            DatabaseHelper.FillDataGridView(dgv, "ListCompra");
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
