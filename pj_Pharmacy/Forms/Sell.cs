using pj_Pharmacy.DataAccess.Repositories;
using pj_Pharmacy.Utilities;
using System;
using System.Windows.Forms;

namespace pj_Pharmacy.Forms
{
    public partial class Sell : Form
    {
        public Sell()
        {
            InitializeComponent();
            CargarVentas();
        }

        #region Carga de Datos

        private void CargarVentas()
        {
            UtilitiesDGV.FormatearGrid(dgvSell);
            VentaRepository.Listar(dgvSell);
        }

        private void Sell_Load(object sender, EventArgs e)
        {
            cboProducts.DataSource = CatalogoRepository.ObtenerProductosParaCombo();
            cboProducts.DisplayMember = "NombreProd";
            cboProducts.ValueMember = "CodProd";
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

            if (InputValidator.HayCamposVacios(txtClient.Texts, txtSeller.Texts, txtCantidad.Texts))
                return;

            int codProd = int.Parse(cboProducts.SelectedValue.ToString());

            VentaRepository.GestionarVenta(
                txtClient.GetIntegerValueUsingIntParse(),
                txtSeller.GetIntegerValueUsingIntParse(),
                codProd,
                txtCantidad.GetIntegerValueUsingIntParse()
            );

            CargarVentas();
            LimpiarCampos();
        }

        #endregion

        private void LimpiarCampos()
        {
            txtClient.Clear();
            txtSeller.Clear();
            txtCantidad.Clear();
        }
    }
}
