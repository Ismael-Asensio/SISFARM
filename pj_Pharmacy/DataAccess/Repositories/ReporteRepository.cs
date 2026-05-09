using System.Data;
using System.Windows.Forms;

namespace pj_Pharmacy.DataAccess.Repositories
{
    /// <summary>
    /// Repositorio para consultas del Dashboard/Reportes.
    /// </summary>
    public static class ReporteRepository
    {
        /// <summary>
        /// Obtiene el resumen general del sistema (totales del mes).
        /// </summary>
        public static DataTable ObtenerResumen()
        {
            return DatabaseHelper.ExecuteReader("sp_Dashboard_Resumen");
        }

        /// <summary>
        /// Obtiene el top 10 de productos más vendidos.
        /// </summary>
        public static void TopProductosVendidos(DataGridView dgv)
        {
            DatabaseHelper.FillDataGridView(dgv, "sp_Dashboard_TopProductos");
        }

        /// <summary>
        /// Obtiene los productos con stock menor a 10 unidades.
        /// </summary>
        public static void ProductosStockBajo(DataGridView dgv)
        {
            DatabaseHelper.FillDataGridView(dgv, "sp_Dashboard_StockBajo");
        }

        /// <summary>
        /// Obtiene las últimas 20 ventas registradas.
        /// </summary>
        public static void VentasRecientes(DataGridView dgv)
        {
            DatabaseHelper.FillDataGridView(dgv, "sp_Dashboard_VentasRecientes");
        }

        /// <summary>
        /// Obtiene las últimas 20 compras registradas.
        /// </summary>
        public static void ComprasRecientes(DataGridView dgv)
        {
            DatabaseHelper.FillDataGridView(dgv, "sp_Dashboard_ComprasRecientes");
        }

        /// <summary>
        /// Obtiene el resumen de ventas por mes (últimos 12 meses).
        /// </summary>
        public static void VentasPorMes(DataGridView dgv)
        {
            DatabaseHelper.FillDataGridView(dgv, "sp_Dashboard_VentasPorMes");
        }

        /// <summary>
        /// Obtiene los productos próximos a vencer (90 días).
        /// </summary>
        public static void ProductosProximosVencer(DataGridView dgv)
        {
            DatabaseHelper.FillDataGridView(dgv, "sp_Dashboard_ProximosVencer");
        }
    }
}
