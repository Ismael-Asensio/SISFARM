using pj_Pharmacy.DataAccess.Repositories;
using pj_Pharmacy.MrControlers;
using pj_Pharmacy.Utilities;
using System;
using System.Drawing;
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
        private MrButton mrBtnGuardar;

        public Products()
        {
            InitializeComponent();
            InitializePaginationControls();
            ConfigurarBotonGuardar();
            ThemeManager.AplicarTema(this);
        }

        private void ConfigurarBotonGuardar()
        {
            // Crear MrButton redondeado que delega al btnInsertar original
            mrBtnGuardar = ThemeManager.CrearBotonGuardar(btnInsertar, flpInput);

            // Botón NUEVO redondeado
            var btnNuevo = ThemeManager.CrearBotonNuevo();
            btnNuevo.Click += (s, e) => LimpiarCampos();
            flpInput.Controls.Add(btnNuevo);
        }

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

            dgvProducts.Height -= 45;

            FlowLayoutPanel flpPagination = new FlowLayoutPanel
            {
                Location = new Point(dgvProducts.Left, dgvProducts.Bottom + 5),
                Size = new Size(dgvProducts.Width, 40),
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
            // Usar GetText() en vez de Texts para evitar falsos vacíos por placeholder
            if (InputValidator.HayCamposVacios(txtName.GetText(), txtDesc.GetText(), txtCantidad.GetText(), txtPrice.GetText(), txtFecE.GetText()))
                return;

            if (cboSupplier.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un proveedor.", "Campos Requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string rucProveedor = cboSupplier.SelectedValue.ToString();

            // Si txtCod tiene valor real → Actualizar. Si no → Insertar.
            string codText = txtCod.GetText();
            bool esActualizacion = !string.IsNullOrWhiteSpace(codText) && codText != txtCod.PlaceholderText;

            if (esActualizacion)
            {
                ProductoRepository.Actualizar(
                    txtName.GetText(), txtDesc.GetText(),
                    txtPrice.GetFloatValueUsingFloatParse(),
                    txtCantidad.GetIntegerValueUsingIntParse(),
                    txtFecE.GetText(),
                    txtCod.GetIntegerValueUsingIntParse()
                );
            }
            else
            {
                ProductoRepository.Insertar(
                    txtName.GetText(), txtDesc.GetText(),
                    txtPrice.GetIntegerValueUsingIntParse(),
                    txtCantidad.GetIntegerValueUsingIntParse(),
                    txtFecE.GetText(), rucProveedor
                );
            }

            currentPage = 1;
            CargarDatosPaginados();
            LimpiarCampos();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Legacy — ahora el flujo unificado va por btnInsertar_Click
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

            DataGridViewRow row = dgvProducts.Rows[e.RowIndex];
            if (row.Cells[0].Value == null) return;

            // Columnas del grid: CodProd(0), NombreProd(1), DescProd(2), Nombreprov(3), PrecioP(4), ExistP(5), FechaElab(6), FechaVenc(7)
            txtCod.Texts = row.Cells[0].Value?.ToString() ?? "";
            txtName.Texts = row.Cells[1].Value?.ToString() ?? "";
            txtDesc.Texts = row.Cells[2].Value?.ToString() ?? "";
            // Cells[3] = Nombreprov → se omite (viene del cboSupplier)

            // PrecioP en columna 4
            string precio = row.Cells[4].Value?.ToString() ?? "";
            txtPrice.Texts = precio.Replace(",", "");

            // ExistP en columna 5
            txtCantidad.Texts = row.Cells[5].Value?.ToString() ?? "";

            // FechaElab en columna 6
            object fechaVal = row.Cells[6].Value;
            if (fechaVal is DateTime dt)
                txtFecE.Texts = dt.ToString("dd/MM/yyyy");
            else
                txtFecE.Texts = fechaVal?.ToString() ?? "";

            // Cambiar texto del botón visual a ACTUALIZAR
            mrBtnGuardar.Text = "ACTUALIZAR";
            mrBtnGuardar.BackColor = ThemeManager.AccentBlue;
            mrBtnGuardar.BorderColor_ = ThemeManager.AccentBlue;
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
            txtCod.Clear();
            txtCantidad.Clear();
            txtDesc.Clear();
            txtFecE.Clear();
            txtName.Clear();
            txtPrice.Clear();

            // Restaurar botón visual a GUARDAR
            mrBtnGuardar.Text = "GUARDAR";
            mrBtnGuardar.BackColor = ThemeManager.BtnPrimary;
            mrBtnGuardar.BorderColor_ = ThemeManager.AccentPink;
        }
    }
}
