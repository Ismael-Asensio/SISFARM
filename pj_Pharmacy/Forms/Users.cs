using pj_Pharmacy.DataAccess.Repositories;
using pj_Pharmacy.Utilities;
using System;
using System.Windows.Forms;

namespace pj_Pharmacy.Forms
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
            txtDNI.MaxLength = 15;
            txtTel.MaxLength = 8;
            CargarEmpleados();
        }

        #region Carga de Datos

        private void CargarEmpleados()
        {
            UtilitiesDGV.FormatearGrid(dgvUser);
            EmpleadoRepository.Listar(dgvUser);
        }

        private void Users_Load(object sender, EventArgs e)
        {
            cboCity.DataSource = CatalogoRepository.ObtenerDepartamentos();
            cboCity.DisplayMember = "NombreDep";
            cboCity.ValueMember = "IdDep";
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

        private void DNI_Validation(object sender, KeyPressEventArgs e)
        {
            InputValidator.LetrasYDigitos(sender, e);
        }

        #endregion

        #region CRUD

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (InputValidator.HayCamposVacios(txtDNI.Texts, txtFN.Texts, txtFA.Texts, txtTel.Texts))
                return;

            EmpleadoRepository.Insertar(
                txtDNI.Texts, txtFN.Texts, txtSN.Texts,
                txtFA.Texts, txtSA.Texts, txtTel.Texts,
                cboCity.Texts, txtSuc.Texts, txtCargo.Texts
            );
            CargarEmpleados();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (InputValidator.HayCamposVacios(txtDNI.Texts, txtFN.Texts, txtFA.Texts, txtTel.Texts))
                return;

            string city = cboCity.SelectedValue != null ? cboCity.SelectedValue.ToString() : cboCity.Texts;

            EmpleadoRepository.Actualizar(
                txtDNI.Texts, txtFN.Texts, txtSN.Texts,
                txtFA.Texts, txtSA.Texts, txtTel.Texts,
                city, txtSuc.Texts, txtCargo.Texts
            );
            CargarEmpleados();
        }

        #endregion
    }
}
