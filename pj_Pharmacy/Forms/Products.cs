using pj_Pharmacy.DataAccess.Repositories;
using pj_Pharmacy.Utilities;
using System;
using System.Windows.Forms;

namespace pj_Pharmacy.Forms
{
    public partial class Products : Form
    {
        private int currentPage = 1;
        private int totalPages = 1;
        private int pageSize = 100;
        private Button btnPrev;
        private Button btnNext;
        private Label lblPage;
        private bool showingActivos = true;

        public Products()
        {
            InitializeComponent();
            InitializePaginationControls();
            ThemeManager.AplicarTema(this);
        }

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

            dgvProducts.Height -= 45;

            FlowLayoutPanel flpPagination = new FlowLayoutPanel
            {
                Location = new System.Drawing.Point(dgvProducts.Left, dgvProducts.Bottom + 5),
                Size = new System.Drawing.Size(dgvProducts.Width, 40),
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
            totalPages = ProductoRepository.ObtenerTotalPaginas(showingActivos, pageSize);
            if (totalPages == 0) totalPages = 1;
            if (currentPage > totalPages) currentPage = totalPages;

            UtilitiesDGV.FormatearGrid(dgvProducts);
            if (showingActivos)
                ProductoRepository.Listar(dgvProducts, currentPage, pageSize);
            else
                ProductoRepository.ListarInactivos(dgvProducts, currentPage, pageSize);

            lblPage.Text = $"Página {currentPage} de {totalPages}";
            btnPrev.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < totalPages;
        }

        private void Products_Load(object sender, EventArgs e)
        {
            cboSupplier.DataSource = ProveedorRepository.ObtenerParaComboBox();
            cboSupplier.DisplayMember = "Nombreprov";
            cboSupplier.ValueMember = "RUC";
            CargarDatosPaginados();
        }

        #region Validaciones

        private void Digit_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputValidator.SoloDigitos(sender, e);
        }

        private void Letter_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputValidator.SoloLetras(sender, e);
        }

        #endregion

        #region CRUD

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (InputValidator.HayCamposVacios(txtName.Texts, txtDesc.Texts, txtCantidad.Texts, txtPrice.Texts, txtFecE.Texts))
                return;

            if (cboSupplier.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un proveedor.", "Campos Requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string rucProveedor = cboSupplier.SelectedValue.ToString();

            ProductoRepository.Insertar(
                txtName.Texts, txtDesc.Texts,
                txtPrice.GetIntegerValueUsingIntParse(),
                txtCantidad.GetIntegerValueUsingIntParse(),
                txtFecE.Texts, rucProveedor
            );

            currentPage = 1;
            CargarDatosPaginados();
            LimpiarCampos();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (InputValidator.HayCamposVacios(txtCod.Texts, txtName.Texts, txtDesc.Texts))
                return;

            ProductoRepository.Actualizar(
                txtName.GetText(), txtDesc.GetText(),
                txtPrice.GetFloatValueUsingFloatParse(),
                txtCantidad.GetIntegerValueUsingIntParse(),
                txtFecE.GetText(),
                txtCod.GetIntegerValueUsingIntParse()
            );

            CargarDatosPaginados();
            LimpiarCampos();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (InputValidator.HayCamposVacios(txtCod.GetText()))
                return;

            ProductoRepository.DarDeBaja(txtCod.GetIntegerValueUsingIntParse());
            CargarDatosPaginados();
            LimpiarCampos();
        }

        #endregion

        #region Eventos Grid y Filtros

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            txtCod.Texts = dgvProducts.CurrentRow.Cells[0].Value.ToString();
            txtName.Texts = dgvProducts.CurrentRow.Cells[1].Value.ToString();
            txtDesc.Texts = dgvProducts.CurrentRow.Cells[2].Value.ToString();
            txtCantidad.Texts = dgvProducts.CurrentRow.Cells[3].Value.ToString();
            txtPrice.Texts = dgvProducts.CurrentRow.Cells[4].Value.ToString();
            txtFecE.Texts = dgvProducts.CurrentRow.Cells[7].Value.ToString();
        }

        private void C_Inactivos_CheckedChanged(object sender, EventArgs e)
        {
            showingActivos = false;
            currentPage = 1;
            CargarDatosPaginados();
        }

        private void C_Activos_CheckedChanged(object sender, EventArgs e)
        {
            showingActivos = true;
            currentPage = 1;
            CargarDatosPaginados();
        }

        #endregion

        private void LimpiarCampos()
        {
            txtCantidad.Clear();
            txtDesc.Clear();
            txtFecE.Clear();
            txtName.Clear();
            txtPrice.Clear();
        }
    }
}
