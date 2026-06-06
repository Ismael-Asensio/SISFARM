using System;
using System.Data;
using System.Data.SqlClient;

namespace pj_Pharmacy.DataAccess.Repositories
{
    /// <summary>
    /// Repositorio para consultas del Dashboard/Reportes.
    /// </summary>
    public static class ReporteRepository
    {
        // ── Sin filtro (valores actuales del sistema) ────────────────────────────

        /// <summary>Resumen general del sistema (totales del mes en curso).</summary>
        public static DataTable ObtenerResumen()
        {
            return DatabaseHelper.ExecuteReader("sp_Dashboard_Resumen");
        }

        // ── Con filtro de fechas ─────────────────────────────────────────────────

        /// <summary>Resumen KPIs para el rango de fechas indicado.</summary>
        public static DataTable ObtenerResumenFiltrado(DateTime desde, DateTime hasta)
        {
            return DatabaseHelper.ExecuteReader(
                "sp_Dashboard_Resumen_Filtro",
                new SqlParameter("@FechaInicio", desde.Date),
                new SqlParameter("@FechaFin",    hasta.Date));
        }

        /// <summary>Ventas agrupadas por mes dentro del rango indicado.</summary>
        public static DataTable VentasPorMesFiltrado(DateTime desde, DateTime hasta)
        {
            return DatabaseHelper.ExecuteReader(
                "sp_Dashboard_VentasPorMes_Filtro",
                new SqlParameter("@FechaInicio", desde.Date),
                new SqlParameter("@FechaFin",    hasta.Date));
        }

        /// <summary>Top 10 productos más vendidos dentro del rango indicado.</summary>
        public static DataTable TopProductosFiltrado(DateTime desde, DateTime hasta)
        {
            return DatabaseHelper.ExecuteReader(
                "sp_Dashboard_TopProductos_Filtro",
                new SqlParameter("@FechaInicio", desde.Date),
                new SqlParameter("@FechaFin",    hasta.Date));
        }

        /// <summary>Productos con stock bajo (no depende de fechas).</summary>
        public static DataTable StockBajo()
        {
            return DatabaseHelper.ExecuteReader("sp_Dashboard_StockBajo");
        }

        // ── Métodos legacy con DataGridView ──────────────────────────────────────

        public static void TopProductosVendidos(System.Windows.Forms.DataGridView dgv)
            => DatabaseHelper.FillDataGridView(dgv, "sp_Dashboard_TopProductos");

        public static void ProductosStockBajo(System.Windows.Forms.DataGridView dgv)
            => DatabaseHelper.FillDataGridView(dgv, "sp_Dashboard_StockBajo");

        public static void VentasRecientes(System.Windows.Forms.DataGridView dgv)
            => DatabaseHelper.FillDataGridView(dgv, "sp_Dashboard_VentasRecientes");

        public static void ComprasRecientes(System.Windows.Forms.DataGridView dgv)
            => DatabaseHelper.FillDataGridView(dgv, "sp_Dashboard_ComprasRecientes");

        public static void VentasPorMes(System.Windows.Forms.DataGridView dgv)
            => DatabaseHelper.FillDataGridView(dgv, "sp_Dashboard_VentasPorMes");

        public static void ProductosProximosVencer(System.Windows.Forms.DataGridView dgv)
            => DatabaseHelper.FillDataGridView(dgv, "sp_Dashboard_ProximosVencer");
    }
}
