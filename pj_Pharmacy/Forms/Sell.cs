using pj_Pharmacy.DataAccess.Repositories;
using pj_Pharmacy.MrControlers;
using pj_Pharmacy.Utilities;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace pj_Pharmacy.Forms
{
    public partial class Sell : Form
    {
        private int currentPage = 1;
        private int totalPages = 1;
        private int pageSize = 100;
        private Button btnPrev;
        private Button btnNext;
        private Label lblPage;
        private MrButton mrBtnGuardar;

        public Sell()
        {
            InitializeComponent();
            InitializePaginationControls();
            ConfigurarBotonGuardar();
            ThemeManager.AplicarTema(this);
        }

        private void ConfigurarBotonGuardar()
        {
            mrBtnGuardar = ThemeManager.CrearBotonGuardar(btnInsertar, flpInput);

            var btnNuevo = ThemeManager.CrearBotonNuevo();
            btnNuevo.Click += (s, e) => LimpiarCampos();
            flpInput.Controls.Add(btnNuevo);
        }

        #region Carga de Datos

        private void InitializePaginationControls()
        {
            btnPrev = new Button { Text = "< Anterior", Width = 100, Height = 35, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
            btnNext = new Button { Text = "Siguiente >", Width = 100, Height = 35, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
            lblPage = new Label { Text = "Página 1 de 1", AutoSize = true, Font = new Font("Segoe UI", 11, FontStyle.Bold) };

            btnPrev.BackColor = ThemeManager.BgCard;
            btnPrev.ForeColor = ThemeManager.TextLight;
            btnNext.BackColor = ThemeManager.BgCard;
            btnNext.ForeColor = ThemeManager.TextLight;
            lblPage.ForeColor = ThemeManager.TextLight;

            btnPrev.Click += BtnPrev_Click;
            btnNext.Click += BtnNext_Click;

            dgvSell.Height -= 45;

            FlowLayoutPanel flpPagination = new FlowLayoutPanel
            {
                Location = new Point(dgvSell.Left, dgvSell.Bottom + 5),
                Size = new Size(dgvSell.Width, 40),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(20, 2, 0, 0),
                BackColor = ThemeManager.BgDark
            };

            flpPagination.Controls.Add(btnPrev);
            flpPagination.Controls.Add(lblPage);
            flpPagination.Controls.Add(btnNext);
            lblPage.Margin = new Padding(20, 8, 20, 0);

            this.panel1.Controls.Add(flpPagination);
            flpPagination.BringToFront();
        }

        private void BtnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1) { currentPage--; CargarDatosPaginados(); }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages) { currentPage++; CargarDatosPaginados(); }
        }

        private void CargarDatosPaginados()
        {
            totalPages = VentaRepository.ObtenerTotalPaginas(pageSize);
            if (totalPages == 0) totalPages = 1;
            if (currentPage > totalPages) currentPage = totalPages;

            UtilitiesDGV.FormatearGrid(dgvSell);
            VentaRepository.Listar(dgvSell, currentPage, pageSize);

            lblPage.Text = $"Página {currentPage} de {totalPages}";
            btnPrev.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < totalPages;
        }

        private void Sell_Load(object sender, EventArgs e)
        {
            cboProducts.DataSource = CatalogoRepository.ObtenerProductosParaCombo();
            cboProducts.DisplayMember = "NombreProd";
            cboProducts.ValueMember = "CodProd";
            CargarDatosPaginados();
        }

        #endregion

        #region Validaciones

        private void Digit_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputValidator.SoloDigitos(sender, e);
        }

        #endregion

        #region CRUD

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (cboProducts.SelectedValue == null || cboProducts.SelectedValue == System.DBNull.Value)
            {
                MessageBox.Show("Seleccione un producto.", "Campos Requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (InputValidator.HayCamposVacios(txtClient.GetText(), txtSeller.GetText(), txtCantidad.GetText()))
                return;

            int codProd = int.Parse(cboProducts.SelectedValue.ToString());

            VentaRepository.GestionarVenta(
                txtClient.GetIntegerValueUsingIntParse(),
                txtSeller.GetIntegerValueUsingIntParse(),
                codProd,
                txtCantidad.GetIntegerValueUsingIntParse()
            );

            currentPage = 1;
            CargarDatosPaginados();
            LimpiarCampos();
        }

        #endregion

        private void LimpiarCampos()
        {
            txtClient.Clear();
            txtSeller.Clear();
            txtCantidad.Clear();
            mrBtnGuardar.Text = "GUARDAR";
            mrBtnGuardar.BackColor = ThemeManager.BtnPrimary;
            mrBtnGuardar.BorderColor_ = ThemeManager.AccentPink;
        }
    }
}
