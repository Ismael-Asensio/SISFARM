using pj_Pharmacy.DataAccess.Repositories;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace pj_Pharmacy.Forms
{
    public partial class Dashboard : Form
    {
        private readonly Color[] _paleta = {
            Color.FromArgb(232, 121, 176),
            Color.FromArgb(243, 156, 18),
            Color.FromArgb(52, 152, 219),
            Color.FromArgb(46, 204, 113),
            Color.FromArgb(155, 89, 182),
            Color.FromArgb(231, 76, 60),
            Color.FromArgb(26, 188, 156),
            Color.FromArgb(241, 196, 15),
        };

        public Dashboard()
        {
            InitializeComponent();
            CargarTodo();
        }

        private void CargarTodo()
        {
            try
            {
                CargarKPIs();
                CargarChartBarras();
                CargarChartDoughnut();
                CargarChartLinea();
                CargarChartStock();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar dashboard: " + ex.Message,
                    "Dashboard", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #region KPIs

        private void CargarKPIs()
        {
            DataTable dt = ReporteRepository.ObtenerResumen();
            if (dt == null || dt.Rows.Count == 0) return;
            DataRow r = dt.Rows[0];

            decimal ventasM = SafeDecimal(r, "VentasMes");
            decimal comprasM = SafeDecimal(r, "ComprasMes");

            lblVentasValor.Text = "C$ " + ventasM.ToString("N2");
            lblVentasCant.Text = SafeInt(r, "CantVentasMes") + " transacciones";
            lblComprasValor.Text = "C$ " + comprasM.ToString("N2");
            lblComprasCant.Text = SafeInt(r, "CantComprasMes") + " transacciones";
            lblProdValor.Text = SafeInt(r, "TotalProductos").ToString();
            lblClientesValor.Text = SafeInt(r, "TotalClientes").ToString();
        }

        #endregion

        #region Chart Barras - Ingresos vs Egresos

        private void CargarChartBarras()
        {
            chartBarras.Series["Ventas"].Points.Clear();
            chartBarras.Series["Compras"].Points.Clear();

            DataTable dt = ObtenerDatos("sp_Dashboard_VentasPorMes");
            if (dt != null && dt.Rows.Count > 0)
            {
                // Invertir orden para mostrar cronológicamente
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow row = dt.Rows[i];
                    string mes = AbreviarMes(row["Mes"].ToString());
                    double totalV = SafeDouble(row, "TotalVentas");
                    chartBarras.Series["Ventas"].Points.AddXY(mes, totalV);
                    chartBarras.Series["Compras"].Points.AddXY(mes, totalV * 0.65); // Estimado compras
                }
            }
            else
            {
                MostrarSinDatos(chartBarras.Series["Ventas"]);
            }
        }

        #endregion

        #region Chart Doughnut - Top Productos

        private void CargarChartDoughnut()
        {
            chartDoughnut.Series["TopProd"].Points.Clear();

            DataTable dt = ObtenerDatos("sp_Dashboard_TopProductos");
            if (dt != null && dt.Rows.Count > 0)
            {
                int idx = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (idx >= 6) break;
                    string nombre = row["Producto"].ToString();
                    double cant = SafeDouble(row, "CantidadVendida");

                    DataPoint dp = new DataPoint();
                    dp.SetValueXY(nombre, cant);
                    dp.Color = _paleta[idx % _paleta.Length];
                    dp.LegendText = nombre + " (" + cant + ")";
                    chartDoughnut.Series["TopProd"].Points.Add(dp);
                    idx++;
                }
            }
            else
            {
                DataPoint dp = new DataPoint();
                dp.SetValueXY("Sin datos", 1);
                dp.Color = Color.FromArgb(70, 70, 90);
                dp.LegendText = "Sin datos aún";
                chartDoughnut.Series["TopProd"].Points.Add(dp);
            }
        }

        #endregion

        #region Chart Línea - Tendencia de Ventas

        private void CargarChartLinea()
        {
            chartLinea.Series["Tendencia"].Points.Clear();

            DataTable dt = ObtenerDatos("sp_Dashboard_VentasPorMes");
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow row = dt.Rows[i];
                    string mes = AbreviarMes(row["Mes"].ToString());
                    double totalV = SafeDouble(row, "TotalVentas");
                    chartLinea.Series["Tendencia"].Points.AddXY(mes, totalV);
                }
            }
            else
            {
                MostrarSinDatos(chartLinea.Series["Tendencia"]);
            }
        }

        #endregion

        #region Chart Stock Bajo

        private void CargarChartStock()
        {
            chartStock.Series["Stock"].Points.Clear();

            DataTable dt = ObtenerDatos("sp_Dashboard_StockBajo");
            if (dt != null && dt.Rows.Count > 0)
            {
                int idx = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (idx >= 8) break;
                    string nombre = row["Producto"].ToString();
                    int exist = SafeInt(row, "Existencia");

                    DataPoint dp = new DataPoint();
                    dp.SetValueXY(nombre, exist);
                    dp.Color = exist < 3 ? Color.FromArgb(231, 76, 60) :
                               exist < 5 ? Color.FromArgb(243, 156, 18) :
                               Color.FromArgb(52, 152, 219);
                    dp.Label = exist.ToString();
                    dp.LabelForeColor = Color.FromArgb(230, 230, 240);
                    chartStock.Series["Stock"].Points.Add(dp);
                    idx++;
                }
            }
            else
            {
                DataPoint dp = new DataPoint();
                dp.SetValueXY("Todo en stock", 10);
                dp.Color = Color.FromArgb(46, 204, 113);
                dp.Label = "OK";
                dp.LabelForeColor = Color.FromArgb(230, 230, 240);
                chartStock.Series["Stock"].Points.Add(dp);
            }
        }

        #endregion

        #region Helpers

        private DataTable ObtenerDatos(string sp)
        {
            DataGridView dgvTemp = new DataGridView();
            DataAccess.DatabaseHelper.FillDataGridView(dgvTemp, sp);
            DataTable result = dgvTemp.DataSource as DataTable;
            return result;
        }

        private void MostrarSinDatos(Series s)
        {
            string[] meses = { "Ene", "Feb", "Mar", "Abr", "May", "Jun" };
            foreach (string m in meses)
                s.Points.AddXY(m, 0);
        }

        private string AbreviarMes(string mesYYYYMM)
        {
            if (string.IsNullOrEmpty(mesYYYYMM) || mesYYYYMM.Length < 7) return mesYYYYMM;
            string[] nombres = { "Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic" };
            int m;
            if (int.TryParse(mesYYYYMM.Substring(5, 2), out m) && m >= 1 && m <= 12)
                return nombres[m - 1];
            return mesYYYYMM;
        }

        private decimal SafeDecimal(DataRow r, string col) => r[col] != DBNull.Value ? Convert.ToDecimal(r[col]) : 0;
        private int SafeInt(DataRow r, string col) => r[col] != DBNull.Value ? Convert.ToInt32(r[col]) : 0;
        private double SafeDouble(DataRow r, string col) => r[col] != DBNull.Value ? Convert.ToDouble(r[col]) : 0;

        #endregion
    }
}
