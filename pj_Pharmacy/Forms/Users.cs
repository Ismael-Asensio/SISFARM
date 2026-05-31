using pj_Pharmacy.DataAccess.Repositories;
using pj_Pharmacy.MrControlers;
using pj_Pharmacy.Utilities;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace pj_Pharmacy.Forms
{
    public partial class Users : Form
    {
        private MrButton mrBtnGuardar;

        public Users()
        {
            InitializeComponent();
            ConfigurarBotonGuardar();
            ThemeManager.AplicarTema(this);
            txtDNI.MaxLength = 15;
            txtTel.MaxLength = 8;
            CargarEmpleados();
        }

        private void ConfigurarBotonGuardar()
        {
            mrBtnGuardar = ThemeManager.CrearBotonGuardar(btnInsertar, flpInput);

            var btnNuevo = ThemeManager.CrearBotonNuevo();
            btnNuevo.Click += (s, e) => LimpiarCampos();
            flpInput.Controls.Add(btnNuevo);

            dgvUser.CellClick += DgvUser_CellClick;
        }

        private void DgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvUser.Rows[e.RowIndex];
            if (row.Cells[0].Value == null) return;

            txtDNI.Texts = row.Cells[0].Value?.ToString() ?? "";
            txtFN.Texts = row.Cells[1].Value?.ToString() ?? "";
            txtSN.Texts = row.Cells[2].Value?.ToString() ?? "";
            txtFA.Texts = row.Cells[3].Value?.ToString() ?? "";
            txtSA.Texts = row.Cells[4].Value?.ToString() ?? "";
            txtTel.Texts = row.Cells[5].Value?.ToString() ?? "";
            txtSuc.Texts = row.Cells[7].Value?.ToString() ?? "";
            txtCargo.Texts = row.Cells[8].Value?.ToString() ?? "";

            mrBtnGuardar.Text = "ACTUALIZAR";
            mrBtnGuardar.BackColor = ThemeManager.AccentBlue;
            mrBtnGuardar.BorderColor_ = ThemeManager.AccentBlue;
        }

        private void LimpiarCampos()
        {
            txtDNI.Clear();
            txtFN.Clear();
            txtSN.Clear();
            txtFA.Clear();
            txtSA.Clear();
            txtTel.Clear();
            txtSuc.Clear();
            txtCargo.Clear();
            mrBtnGuardar.Text = "GUARDAR";
            mrBtnGuardar.BackColor = ThemeManager.BtnPrimary;
            mrBtnGuardar.BorderColor_ = ThemeManager.AccentPink;
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
            if (InputValidator.HayCamposVacios(txtDNI.GetText(), txtFN.GetText(), txtFA.GetText(), txtTel.GetText()))
                return;

            string city = cboCity.SelectedValue != null ? cboCity.SelectedValue.ToString() : cboCity.Texts;

            if (mrBtnGuardar.Text == "ACTUALIZAR")
            {
                EmpleadoRepository.Actualizar(
                    txtDNI.GetText(), txtFN.GetText(), txtSN.GetText(),
                    txtFA.GetText(), txtSA.GetText(), txtTel.GetText(),
                    city, txtSuc.GetText(), txtCargo.GetText()
                );
            }
            else
            {
                EmpleadoRepository.Insertar(
                    txtDNI.GetText(), txtFN.GetText(), txtSN.GetText(),
                    txtFA.GetText(), txtSA.GetText(), txtTel.GetText(),
                    cboCity.Texts, txtSuc.GetText(), txtCargo.GetText()
                );
            }

            CargarEmpleados();
            LimpiarCampos();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Legacy — ahora unificado en btnInsertar_Click
        }

        #endregion
    }
}
