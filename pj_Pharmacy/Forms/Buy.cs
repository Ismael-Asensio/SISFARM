using pj_Pharmacy.DataAccess.Repositories;
using pj_Pharmacy.Utilities;
using System;
using System.Windows.Forms;

namespace pj_Pharmacy.Forms
{
    public partial class Buy : Form
    {
        public Buy()
        {
            InitializeComponent();
            CargarCompras();
        }

        #region Carga de Datos

        private void CargarCompras()
        {
            UtilitiesDGV.FormatearGrid(dgvBuys);
            CompraRepository.Listar(dgvBuys);
        }

        private void Buy_Load(object sender, EventArgs e)
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

            CargarCompras();
        }

        #endregion
    }
}
