using pj_Pharmacy.DataAccess.Repositories;
using pj_Pharmacy.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace pj_Pharmacy.Forms
{
    public partial class Dashboard : Form
    {
        private readonly Color[] _paleta = {
            Color.FromArgb(232, 121, 176),
            Color.FromArgb(243, 156,  18),
            Color.FromArgb( 52, 152, 219),
            Color.FromArgb( 46, 204, 113),
            Color.FromArgb(155,  89, 182),
            Color.FromArgb(231,  76,  60),
            Color.FromArgb( 26, 188, 156),
            Color.FromArgb(241, 196,  15),
        };

        // Caché de KPIs para el PDF (se actualiza al cargar)
        private Dictionary<string, string> _kpiCache = new Dictionary<string, string>();

        // Rango de fechas activo
        private DateTime _desde => dtpDesde.Value.Date;
        private DateTime _hasta => dtpHasta.Value.Date;

        public Dashboard()
        {
            InitializeComponent();
            this.Load += (s, e) => CargarTodo();
        }

        // ─────────────────────────────────────────────────────────────
        //  CARGA GENERAL
        // ─────────────────────────────────────────────────────────────

        private void CargarTodo()
        {
            Cursor = Cursors.WaitCursor;
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
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        // ─────────────────────────────────────────────────────────────
        //  KPIs
        // ─────────────────────────────────────────────────────────────

        private void CargarKPIs()
        {
            DataTable dt = ReporteRepository.ObtenerResumenFiltrado(_desde, _hasta);
            if (dt == null || dt.Rows.Count == 0) return;
            DataRow r = dt.Rows[0];

            decimal ventasM  = SafeDecimal(r, "VentasMes");
            decimal comprasM = SafeDecimal(r, "ComprasMes");
            int cantV        = SafeInt(r, "CantVentasMes");
            int cantC        = SafeInt(r, "CantComprasMes");
            int totalProd    = SafeInt(r, "TotalProductos");
            int totalCli     = SafeInt(r, "TotalClientes");

            lblVentasValor.Text   = "C$ " + ventasM.ToString("N2");
            lblVentasCant.Text    = cantV + " transacciones";
            lblComprasValor.Text  = "C$ " + comprasM.ToString("N2");
            lblComprasCant.Text   = cantC + " transacciones";
            lblProdValor.Text     = totalProd.ToString();
            lblClientesValor.Text = totalCli.ToString();

            // Caché para el PDF
            _kpiCache.Clear();
            _kpiCache["VENTAS DEL PERÍODO"]    = "C$ " + ventasM.ToString("N2");
            _kpiCache["COMPRAS DEL PERÍODO"]   = "C$ " + comprasM.ToString("N2");
            _kpiCache["PRODUCTOS ACTIVOS"]     = totalProd.ToString();
            _kpiCache["CLIENTES ACTIVOS"]      = totalCli.ToString();
        }

        // ─────────────────────────────────────────────────────────────
        //  CHART: Ingresos vs Egresos (barras)
        // ─────────────────────────────────────────────────────────────

        private void CargarChartBarras()
        {
            chartBarras.Series["Ventas"].Points.Clear();
            chartBarras.Series["Compras"].Points.Clear();

            DataTable dt = ReporteRepository.VentasPorMesFiltrado(_desde, _hasta);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    string mes    = AbreviarMes(row["Mes"].ToString());
                    double totalV = SafeDouble(row, "TotalVentas");
                    double totalC = dt.Columns.Contains("TotalCompras")
                                    ? SafeDouble(row, "TotalCompras")
                                    : totalV * 0.65;
                    chartBarras.Series["Ventas"].Points.AddXY(mes, totalV);
                    chartBarras.Series["Compras"].Points.AddXY(mes, totalC);
                }
            }
            else
            {
                MostrarSinDatos(chartBarras.Series["Ventas"]);
            }
        }

        // ─────────────────────────────────────────────────────────────
        //  CHART: Top Productos (doughnut)
        // ─────────────────────────────────────────────────────────────

        private void CargarChartDoughnut()
        {
            chartDoughnut.Series["TopProd"].Points.Clear();

            DataTable dt = ReporteRepository.TopProductosFiltrado(_desde, _hasta);
            if (dt != null && dt.Rows.Count > 0)
            {
                int idx = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (idx >= 6) break;
                    string nombre = row["Producto"].ToString();
                    double cant   = SafeDouble(row, "CantidadVendida");

                    DataPoint dp = new DataPoint();
                    dp.SetValueXY(nombre, cant);
                    dp.Color      = _paleta[idx % _paleta.Length];
                    dp.LegendText = nombre + " (" + (int)cant + ")";
                    chartDoughnut.Series["TopProd"].Points.Add(dp);
                    idx++;
                }
            }
            else
            {
                DataPoint dp = new DataPoint();
                dp.SetValueXY("Sin datos", 1);
                dp.Color      = Color.FromArgb(70, 70, 90);
                dp.LegendText = "Sin datos para este período";
                chartDoughnut.Series["TopProd"].Points.Add(dp);
            }
        }

        // ─────────────────────────────────────────────────────────────
        //  CHART: Tendencia de Ventas (línea)
        // ─────────────────────────────────────────────────────────────

        private void CargarChartLinea()
        {
            chartLinea.Series["Tendencia"].Points.Clear();

            DataTable dt = ReporteRepository.VentasPorMesFiltrado(_desde, _hasta);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    string mes    = AbreviarMes(row["Mes"].ToString());
                    double totalV = SafeDouble(row, "TotalVentas");
                    chartLinea.Series["Tendencia"].Points.AddXY(mes, totalV);
                }
            }
            else
            {
                MostrarSinDatos(chartLinea.Series["Tendencia"]);
            }
        }

        // ─────────────────────────────────────────────────────────────
        //  CHART: Stock Bajo (barras horizontales — sin filtro de fecha)
        // ─────────────────────────────────────────────────────────────

        private void CargarChartStock()
        {
            chartStock.Series["Stock"].Points.Clear();

            DataTable dt = ReporteRepository.StockBajo();
            if (dt != null && dt.Rows.Count > 0)
            {
                int idx = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (idx >= 8) break;
                    string nombre = row["Producto"].ToString();
                    int exist     = SafeInt(row, "Existencia");

                    DataPoint dp = new DataPoint();
                    dp.SetValueXY(nombre, exist);
                    dp.Color = exist < 3 ? Color.FromArgb(231, 76, 60) :
                               exist < 5 ? Color.FromArgb(243, 156, 18) :
                               Color.FromArgb(52, 152, 219);
                    dp.Label          = exist.ToString();
                    dp.LabelForeColor = Color.FromArgb(230, 230, 240);
                    chartStock.Series["Stock"].Points.Add(dp);
                    idx++;
                }
            }
            else
            {
                DataPoint dp = new DataPoint();
                dp.SetValueXY("Todo en stock", 10);
                dp.Color          = Color.FromArgb(46, 204, 113);
                dp.Label          = "OK";
                dp.LabelForeColor = Color.FromArgb(230, 230, 240);
                chartStock.Series["Stock"].Points.Add(dp);
            }
        }

        // ─────────────────────────────────────────────────────────────
        //  EVENTO: Aplicar filtro de fechas
        // ─────────────────────────────────────────────────────────────

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            if (_desde > _hasta)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha fin.",
                    "Filtro de fechas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnAplicar.Enabled = false;
            btnAplicar.Text    = "...";
            btnAplicar.Refresh();

            try   { CargarTodo(); }
            finally
            {
                btnAplicar.Enabled = true;
                btnAplicar.Text    = "\u25B6  Aplicar";
            }
        }

        // ─────────────────────────────────────────────────────────────
        //  EVENTO: Exportar PDF
        // ─────────────────────────────────────────────────────────────

        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            if (_desde > _hasta)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha fin.",
                    "Exportar PDF", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var dlg = new SaveFileDialog())
                {
                    dlg.Title       = "Guardar Reporte PDF";
                    dlg.Filter      = "Archivos PDF (*.pdf)|*.pdf";
                    dlg.FileName    = $"Reporte_Dashboard_{_desde:yyyyMMdd}_{_hasta:yyyyMMdd}";
                    dlg.InitialDirectory =
                        Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                    if (dlg.ShowDialog() != DialogResult.OK) return;

                    btnExportPdf.Enabled = false;
                    btnExportPdf.Text    = "Generando...";
                    btnExportPdf.Refresh();

                    // Capturar los 4 charts como Bitmap de alta resolución
                    var graficos = new List<System.Drawing.Bitmap>
                    {
                        CapturarChart(chartBarras),
                        CapturarChart(chartDoughnut),
                        CapturarChart(chartLinea),
                        CapturarChart(chartStock)
                    };

                    PdfReportGenerator.Generar(
                        dlg.FileName, _kpiCache, graficos, _desde, _hasta);

                    foreach (var bmp in graficos) bmp.Dispose();

                    MessageBox.Show(
                        $"Reporte generado correctamente.\n\n{dlg.FileName}",
                        "Exportar PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    System.Diagnostics.Process.Start(dlg.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar PDF: " + ex.Message,
                    "Exportar PDF", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnExportPdf.Enabled = true;
                btnExportPdf.Text    = "\u2193  Exportar PDF";
            }
        }

        /// <summary>Captura un Chart como Bitmap de alta resolución para el PDF.</summary>
        private System.Drawing.Bitmap CapturarChart(Chart chart)
        {
            var bmp = new System.Drawing.Bitmap(
                1200, 700, PixelFormat.Format24bppRgb);
            using (var g = System.Drawing.Graphics.FromImage(bmp))
                g.Clear(Color.FromArgb(45, 45, 65));
            chart.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, 1200, 700));
            return bmp;
        }

        // ─────────────────────────────────────────────────────────────
        //  HELPERS
        // ─────────────────────────────────────────────────────────────

        private void MostrarSinDatos(Series s)
        {
            string[] meses = { "Ene", "Feb", "Mar", "Abr", "May", "Jun" };
            foreach (string m in meses) s.Points.AddXY(m, 0);
        }

        private string AbreviarMes(string mesYYYYMM)
        {
            if (string.IsNullOrEmpty(mesYYYYMM) || mesYYYYMM.Length < 7)
                return mesYYYYMM;
            string[] nombres = {
                "Ene","Feb","Mar","Abr","May","Jun",
                "Jul","Ago","Sep","Oct","Nov","Dic"
            };
            int m;
            if (int.TryParse(mesYYYYMM.Substring(5, 2), out m) && m >= 1 && m <= 12)
                return nombres[m - 1];
            return mesYYYYMM;
        }

        private decimal SafeDecimal(DataRow r, string col)
            => r[col] != DBNull.Value ? Convert.ToDecimal(r[col]) : 0;
        private int SafeInt(DataRow r, string col)
            => r[col] != DBNull.Value ? Convert.ToInt32(r[col]) : 0;
        private double SafeDouble(DataRow r, string col)
            => r[col] != DBNull.Value ? Convert.ToDouble(r[col]) : 0;
    }
}
