using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace pj_Pharmacy.Forms
{
    partial class Dashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            // === COLORES TEMA OSCURO ===
            Color bgDark = Color.FromArgb(30, 30, 46);
            Color bgCard = Color.FromArgb(45, 45, 65);
            Color textLight = Color.FromArgb(230, 230, 240);
            Color textDim = Color.FromArgb(160, 160, 180);
            Color accentGreen = Color.FromArgb(46, 204, 113);
            Color accentRed = Color.FromArgb(231, 76, 60);
            Color accentBlue = Color.FromArgb(52, 152, 219);
            Color accentOrange = Color.FromArgb(243, 156, 18);

            // === ROOT CONTAINER (único hijo del form) ===
            this.rootLayout = new TableLayoutPanel();
            this.rootLayout.SuspendLayout();
            this.SuspendLayout();

            this.rootLayout.Dock = DockStyle.Fill;
            this.rootLayout.BackColor = bgDark;
            this.rootLayout.ColumnCount = 1;
            this.rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.rootLayout.RowCount = 3;
            this.rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));  // KPIs
            this.rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));    // Charts fila 1
            this.rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));    // Charts fila 2
            this.rootLayout.Padding = new Padding(5);
            this.rootLayout.Name = "rootLayout";

            // ==========================================
            // FILA 0: KPI CARDS
            // ==========================================
            this.pnlCards = new FlowLayoutPanel();
            this.pnlCards.Dock = DockStyle.Fill;
            this.pnlCards.BackColor = bgDark;
            this.pnlCards.Padding = new Padding(5);

            int cardW = 195, cardH = 100;
            Padding cMargin = new Padding(6, 5, 6, 5);

            // -- Card Ventas --
            this.pnlCardVentas = new Panel { Size = new Size(cardW, cardH), BackColor = bgCard, Margin = cMargin };
            this.pnlVentasAccent = new Panel { Dock = DockStyle.Left, Width = 4, BackColor = accentGreen };
            this.lblVentasTitulo = new Label { Text = "VENTAS DEL MES", Font = new Font("Segoe UI", 7.5F, FontStyle.Bold), ForeColor = textDim, Location = new Point(14, 8), AutoSize = true };
            this.lblVentasValor = new Label { Text = "C$ 0.00", Font = new Font("Segoe UI Semibold", 18F), ForeColor = accentGreen, Location = new Point(10, 28), AutoSize = true };
            this.lblVentasCant = new Label { Text = "0 transacciones", Font = new Font("Segoe UI", 7.5F), ForeColor = textDim, Location = new Point(14, 78), AutoSize = true };
            this.pnlCardVentas.Controls.AddRange(new Control[] { lblVentasTitulo, lblVentasValor, lblVentasCant, pnlVentasAccent });

            // -- Card Compras --
            this.pnlCardCompras = new Panel { Size = new Size(cardW, cardH), BackColor = bgCard, Margin = cMargin };
            this.pnlComprasAccent = new Panel { Dock = DockStyle.Left, Width = 4, BackColor = accentRed };
            this.lblComprasTitulo = new Label { Text = "COMPRAS DEL MES", Font = new Font("Segoe UI", 7.5F, FontStyle.Bold), ForeColor = textDim, Location = new Point(14, 8), AutoSize = true };
            this.lblComprasValor = new Label { Text = "C$ 0.00", Font = new Font("Segoe UI Semibold", 18F), ForeColor = accentRed, Location = new Point(10, 28), AutoSize = true };
            this.lblComprasCant = new Label { Text = "0 transacciones", Font = new Font("Segoe UI", 7.5F), ForeColor = textDim, Location = new Point(14, 78), AutoSize = true };
            this.pnlCardCompras.Controls.AddRange(new Control[] { lblComprasTitulo, lblComprasValor, lblComprasCant, pnlComprasAccent });

            // -- Card Productos --
            this.pnlCardProd = new Panel { Size = new Size(cardW, cardH), BackColor = bgCard, Margin = cMargin };
            this.pnlProdAccent = new Panel { Dock = DockStyle.Left, Width = 4, BackColor = accentBlue };
            this.lblProdTitulo = new Label { Text = "PRODUCTOS ACTIVOS", Font = new Font("Segoe UI", 7.5F, FontStyle.Bold), ForeColor = textDim, Location = new Point(14, 8), AutoSize = true };
            this.lblProdValor = new Label { Text = "0", Font = new Font("Segoe UI Semibold", 26F), ForeColor = accentBlue, Location = new Point(10, 30), AutoSize = true };
            this.pnlCardProd.Controls.AddRange(new Control[] { lblProdTitulo, lblProdValor, pnlProdAccent });

            // -- Card Clientes --
            this.pnlCardClientes = new Panel { Size = new Size(cardW, cardH), BackColor = bgCard, Margin = cMargin };
            this.pnlClientesAccent = new Panel { Dock = DockStyle.Left, Width = 4, BackColor = accentOrange };
            this.lblClientesTitulo = new Label { Text = "CLIENTES ACTIVOS", Font = new Font("Segoe UI", 7.5F, FontStyle.Bold), ForeColor = textDim, Location = new Point(14, 8), AutoSize = true };
            this.lblClientesValor = new Label { Text = "0", Font = new Font("Segoe UI Semibold", 26F), ForeColor = accentOrange, Location = new Point(10, 30), AutoSize = true };
            this.pnlCardClientes.Controls.AddRange(new Control[] { lblClientesTitulo, lblClientesValor, pnlClientesAccent });

            this.pnlCards.Controls.AddRange(new Control[] { pnlCardVentas, pnlCardCompras, pnlCardProd, pnlCardClientes });

            // ==========================================
            // FILA 1: BARRAS + DOUGHNUT
            // ==========================================
            this.pnlChartRow1 = new TableLayoutPanel();
            this.pnlChartRow1.Dock = DockStyle.Fill;
            this.pnlChartRow1.BackColor = bgDark;
            this.pnlChartRow1.ColumnCount = 2;
            this.pnlChartRow1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            this.pnlChartRow1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            this.pnlChartRow1.RowCount = 1;
            this.pnlChartRow1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.pnlChartRow1.Padding = new Padding(5, 0, 5, 5);

            // Chart Barras: Ingresos vs Egresos
            this.chartBarras = CrearChart("Ingresos vs Egresos", bgCard, textLight, textDim);
            this.chartBarras.Dock = DockStyle.Fill;
            this.chartBarras.Margin = new Padding(0, 0, 5, 0);

            ChartArea areaBar = new ChartArea("BarArea");
            EstiloArea(areaBar, bgCard, textDim);
            areaBar.AxisY.LabelStyle.Format = "C0";
            this.chartBarras.ChartAreas.Add(areaBar);

            Series sVentas = new Series("Ventas") { ChartType = SeriesChartType.Column, Color = Color.FromArgb(232, 121, 176) };
            Series sCompras = new Series("Compras") { ChartType = SeriesChartType.Column, Color = Color.FromArgb(120, 120, 160) };
            this.chartBarras.Series.Add(sVentas);
            this.chartBarras.Series.Add(sCompras);
            AgregarLeyenda(this.chartBarras, textDim);

            // Chart Doughnut: Top Productos
            this.chartDoughnut = CrearChart("Top Productos", bgCard, textLight, textDim);
            this.chartDoughnut.Dock = DockStyle.Fill;
            this.chartDoughnut.Margin = new Padding(5, 0, 0, 0);

            ChartArea areaPie = new ChartArea("PieArea");
            areaPie.BackColor = bgCard;
            this.chartDoughnut.ChartAreas.Add(areaPie);

            Series sPie = new Series("TopProd") { ChartType = SeriesChartType.Doughnut };
            sPie["DoughnutRadius"] = "35";
            sPie["PieLabelStyle"] = "Disabled";
            this.chartDoughnut.Series.Add(sPie);
            AgregarLeyenda(this.chartDoughnut, textDim);

            this.pnlChartRow1.Controls.Add(this.chartBarras, 0, 0);
            this.pnlChartRow1.Controls.Add(this.chartDoughnut, 1, 0);

            // ==========================================
            // FILA 2: LINEA TENDENCIA + BARRAS STOCK
            // ==========================================
            this.pnlChartRow2 = new TableLayoutPanel();
            this.pnlChartRow2.Dock = DockStyle.Fill;
            this.pnlChartRow2.BackColor = bgDark;
            this.pnlChartRow2.ColumnCount = 2;
            this.pnlChartRow2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
            this.pnlChartRow2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            this.pnlChartRow2.RowCount = 1;
            this.pnlChartRow2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.pnlChartRow2.Padding = new Padding(5, 0, 5, 5);

            // Chart Línea: Tendencia de Ventas
            this.chartLinea = CrearChart("Tendencia de Ventas", bgCard, textLight, textDim);
            this.chartLinea.Dock = DockStyle.Fill;
            this.chartLinea.Margin = new Padding(0, 0, 5, 0);

            ChartArea areaLine = new ChartArea("LineArea");
            EstiloArea(areaLine, bgCard, textDim);
            areaLine.AxisY.LabelStyle.Format = "C0";
            this.chartLinea.ChartAreas.Add(areaLine);

            Series sLine = new Series("Tendencia") { ChartType = SeriesChartType.SplineArea, Color = Color.FromArgb(100, 232, 121, 176), BorderColor = Color.FromArgb(232, 121, 176), BorderWidth = 2 };
            this.chartLinea.Series.Add(sLine);

            // Chart Barras Horizontales: Stock Bajo
            this.chartStock = CrearChart("Productos con Stock Bajo", bgCard, textLight, textDim);
            this.chartStock.Dock = DockStyle.Fill;
            this.chartStock.Margin = new Padding(5, 0, 0, 0);

            ChartArea areaStock = new ChartArea("StockArea");
            EstiloArea(areaStock, bgCard, textDim);
            this.chartStock.ChartAreas.Add(areaStock);

            Series sStock = new Series("Stock") { ChartType = SeriesChartType.Bar, Color = Color.FromArgb(231, 76, 60) };
            sStock["BarLabelStyle"] = "Right";
            this.chartStock.Series.Add(sStock);

            this.pnlChartRow2.Controls.Add(this.chartLinea, 0, 0);
            this.pnlChartRow2.Controls.Add(this.chartStock, 1, 0);

            // ==========================================
            // ENSAMBLAR
            // ==========================================
            this.rootLayout.Controls.Add(this.pnlCards, 0, 0);
            this.rootLayout.Controls.Add(this.pnlChartRow1, 0, 1);
            this.rootLayout.Controls.Add(this.pnlChartRow2, 0, 2);

            // FORM
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = bgDark;
            this.ClientSize = new Size(910, 560);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.Controls.Add(this.rootLayout);

            this.rootLayout.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        // Helpers de estilo para charts
        private Chart CrearChart(string titulo, Color bgCard, Color textLight, Color textDim)
        {
            Chart c = new Chart();
            c.BackColor = bgCard;
            c.BorderlineColor = Color.Transparent;

            Title t = new Title(titulo);
            t.ForeColor = textLight;
            t.Font = new Font("Segoe UI Semibold", 10F);
            t.Alignment = ContentAlignment.TopLeft;
            c.Titles.Add(t);

            return c;
        }

        private void EstiloArea(ChartArea area, Color bgCard, Color textDim)
        {
            Color gridLine = Color.FromArgb(50, 50, 70);
            Color axisLine = Color.FromArgb(70, 70, 90);

            area.BackColor = bgCard;
            area.AxisX.LabelStyle.ForeColor = textDim;
            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 7.5F);
            area.AxisX.LineColor = axisLine;
            area.AxisX.MajorGrid.LineColor = gridLine;
            area.AxisX.MajorTickMark.LineColor = axisLine;
            area.AxisY.LabelStyle.ForeColor = textDim;
            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 7.5F);
            area.AxisY.LineColor = axisLine;
            area.AxisY.MajorGrid.LineColor = gridLine;
            area.AxisY.MajorTickMark.LineColor = axisLine;
        }

        private void AgregarLeyenda(Chart c, Color textDim)
        {
            Legend leg = new Legend();
            leg.ForeColor = textDim;
            leg.BackColor = Color.Transparent;
            leg.Font = new Font("Segoe UI", 7.5F);
            leg.Docking = Docking.Bottom;
            c.Legends.Add(leg);
        }

        #endregion

        // Controles
        private TableLayoutPanel rootLayout;
        private FlowLayoutPanel pnlCards;

        private Panel pnlCardVentas, pnlVentasAccent;
        private Label lblVentasTitulo, lblVentasValor, lblVentasCant;

        private Panel pnlCardCompras, pnlComprasAccent;
        private Label lblComprasTitulo, lblComprasValor, lblComprasCant;

        private Panel pnlCardProd, pnlProdAccent;
        private Label lblProdTitulo, lblProdValor;

        private Panel pnlCardClientes, pnlClientesAccent;
        private Label lblClientesTitulo, lblClientesValor;

        private TableLayoutPanel pnlChartRow1;
        private Chart chartBarras;
        private Chart chartDoughnut;

        private TableLayoutPanel pnlChartRow2;
        private Chart chartLinea;
        private Chart chartStock;
    }
}
