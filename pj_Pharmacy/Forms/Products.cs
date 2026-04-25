using pj_Pharmacy.DataAccess.Repositories;
using pj_Pharmacy.Utilities;
using System;
using System.Windows.Forms;

namespace pj_Pharmacy.Forms
{
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
            CargarProductos();
        }

        #region Carga de Datos

        private void CargarProductos()
        {
            UtilitiesDGV.FormatearGrid(dgvProducts);
            ProductoRepository.Listar(dgvProducts);
        }

        private void CargarProductosInactivos()
        {
            UtilitiesDGV.FormatearGrid(dgvProducts);
            ProductoRepository.ListarInactivos(dgvProducts);
        }

        private void Products_Load(object sender, EventArgs e)
        {
            cboSupplier.DataSource = ProveedorRepository.ObtenerParaComboBox();
            cboSupplier.DisplayMember = "Nombreprov";
            cboSupplier.ValueMember = "RUC";
        }

        #endregion

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

            CargarProductos();
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

            CargarProductos();
            LimpiarCampos();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (InputValidator.HayCamposVacios(txtCod.GetText()))
                return;

            ProductoRepository.DarDeBaja(txtCod.GetIntegerValueUsingIntParse());
            CargarProductos();
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
            CargarProductosInactivos();
        }

        private void C_Activos_CheckedChanged(object sender, EventArgs e)
        {
            CargarProductos();
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
