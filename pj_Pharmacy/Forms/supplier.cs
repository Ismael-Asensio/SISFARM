using pj_Pharmacy.DataAccess.Repositories;
using pj_Pharmacy.Utilities;
using System;
using System.Windows.Forms;

namespace pj_Pharmacy.Forms
{
    public partial class supplier : Form
    {
        public supplier()
        {
            InitializeComponent();
            txtTel.MaxLength = 8;
            CargarProveedores();
        }

        #region Carga de Datos

        private void CargarProveedores()
        {
            UtilitiesDGV.FormatearGrid(dgvSupplier);
            ProveedorRepository.Listar(dgvSupplier);
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
            if (InputValidator.HayCamposVacios(txtRUC.Texts, txtName.Texts, txtAddress.Texts, txtTel.Texts))
                return;

            ProveedorRepository.Insertar(txtRUC.Texts, txtName.Texts, txtAddress.Texts, txtTel.Texts);
            CargarProveedores();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (InputValidator.HayCamposVacios(txtRUC.Texts, txtName.Texts, txtAddress.Texts, txtTel.Texts))
                return;

            ProveedorRepository.Actualizar(txtRUC.Texts, txtName.Texts, txtAddress.Texts, txtTel.Texts);
            CargarProveedores();
        }

        #endregion
    }
}
