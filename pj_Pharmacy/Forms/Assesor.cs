using pj_Pharmacy.DataAccess.Repositories;
using pj_Pharmacy.Utilities;
using System;
using System.Windows.Forms;

namespace pj_Pharmacy.Forms
{
    public partial class Assesor : Form
    {
        public Assesor()
        {
            InitializeComponent();
            CargarContactos();
            txtTel.MaxLength = 8;
        }

        #region Carga de Datos

        private void CargarContactos()
        {
            UtilitiesDGV.FormatearGrid(dgvSupplier);
            ContactoRepository.Listar(dgvSupplier);
        }

        private void Assesor_Load(object sender, EventArgs e)
        {
            cboTypeCN.DataSource = ProveedorRepository.ObtenerParaComboBox();
            cboTypeCN.DisplayMember = "Nombreprov";
            cboTypeCN.ValueMember = "RUC";
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
            if (InputValidator.HayCamposVacios(txtFN.Texts, txtFA.Texts, txtAddress.Texts, txtTel.Texts, txtMail.Texts))
                return;

            if (cboTypeCN.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un proveedor.", "Campos Requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string rucProveedor = cboTypeCN.SelectedValue.ToString();

            ContactoRepository.Insertar(
                txtFN.Texts, txtSN.Texts, txtFA.Texts, txtSA.Texts,
                txtAddress.Texts, txtTel.Texts, txtMail.Texts, rucProveedor
            );

            CargarContactos();
            LimpiarCampos();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (InputValidator.HayCamposVacios(txtFN.Texts, txtFA.Texts, txtAddress.Texts, txtTel.Texts, txtMail.Texts))
                return;

            if (cboTypeCN.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un proveedor.", "Campos Requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string rucProveedor = cboTypeCN.SelectedValue.ToString();

            ContactoRepository.Actualizar(
                txtContacto.Texts, txtFN.Texts, txtSN.Texts,
                txtFA.Texts, txtSA.Texts, txtAddress.Texts,
                txtTel.Texts, txtMail.Texts, rucProveedor
            );

            CargarContactos();
            LimpiarCampos();
        }

        #endregion

        private void LimpiarCampos()
        {
            txtFN.Clear();
            txtFA.Clear();
            txtAddress.Clear();
            txtTel.Clear();
            txtMail.Clear();
            txtSN.Clear();
            txtSA.Clear();
        }
    }
}
