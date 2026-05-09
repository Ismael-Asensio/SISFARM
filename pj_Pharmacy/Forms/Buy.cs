using pj_Pharmacy.DataAccess.Repositories;
using pj_Pharmacy.Utilities;
using System;
using System.Windows.Forms;

namespace pj_Pharmacy.Forms
{
    public partial class Buy : Form
    {
        private int currentPage = 1;
        private int totalPages = 1;
        private int pageSize = 100;
        private Button btnPrev;
        private Button btnNext;
        private Label lblPage;

        public Buy()
        {
            InitializeComponent();
            InitializePaginationControls();
            ThemeManager.AplicarTema(this);
        }

        #region Carga de Datos

        private void InitializePaginationControls()
        {
            btnPrev = new Button { Text = "< Anterior", Width = 100, Height = 35, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
            btnNext = new Button { Text = "Siguiente >", Width = 100, Height = 35, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
            lblPage = new Label { Text = "Página 1 de 1", AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 11, System.Drawing.FontStyle.Bold) };

            btnPrev.BackColor = ThemeManager.BgCard;
            btnPrev.ForeColor = ThemeManager.TextLight;
            btnNext.BackColor = ThemeManager.BgCard;
            btnNext.ForeColor = ThemeManager.TextLight;
            lblPage.ForeColor = ThemeManager.TextLight;

            btnPrev.Click += BtnPrev_Click;
            btnNext.Click += BtnNext_Click;

            dgvBuys.Height -= 45;

            FlowLayoutPanel flpPagination = new FlowLayoutPanel
            {
                Location = new System.Drawing.Point(dgvBuys.Left, dgvBuys.Bottom + 5),
                Size = new System.Drawing.Size(dgvBuys.Width, 40),
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
            totalPages = CompraRepository.ObtenerTotalPaginas(pageSize);
            if (totalPages == 0) totalPages = 1;
            if (currentPage > totalPages) currentPage = totalPages;

            UtilitiesDGV.FormatearGrid(dgvBuys);
            CompraRepository.Listar(dgvBuys, currentPage, pageSize);

            lblPage.Text = $"Página {currentPage} de {totalPages}";
            btnPrev.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < totalPages;
        }

        private void Buy_Load(object sender, EventArgs e)
        {
            cboSupplier.DataSource = ProveedorRepository.ObtenerParaComboBox();
            cboSupplier.DisplayMember = "Nombreprov";
            cboSupplier.ValueMember = "RUC";
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
            if (cboSupplier.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un proveedor.", "Campos Requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (InputValidator.HayCamposVacios(txtCodProd.Texts, txtCantidad.Texts, txtPrecio.Texts))
                return;

            string rucProveedor = cboSupplier.SelectedValue.ToString();

            CompraRepository.GestionarCompra(
                rucProveedor,
                txtCantidad.GetIntegerValueUsingIntParse(),
                txtCodProd.Texts,
                txtPrecio.GetFloatValueUsingFloatParse()
            );

            currentPage = 1;
            CargarDatosPaginados();
            txtCodProd.Clear();
            txtCantidad.Clear();
            txtPrecio.Clear();
        }

        #endregion
    }
}
