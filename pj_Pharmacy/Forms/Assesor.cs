using pj_Pharmacy.DataAccess.Repositories;
using pj_Pharmacy.MrControlers;
using pj_Pharmacy.Utilities;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace pj_Pharmacy.Forms
{
    public partial class Assesor : Form
    {
        private MrButton mrBtnGuardar;

        public Assesor()
        {
            InitializeComponent();
            ConfigurarBotonGuardar();
            ThemeManager.AplicarTema(this);
            CargarContactos();
            txtTel.MaxLength = 8;
        }

        private void ConfigurarBotonGuardar()
        {
            mrBtnGuardar = ThemeManager.CrearBotonGuardar(btnInsertar, flpInput);

            var btnNuevo = ThemeManager.CrearBotonNuevo();
            btnNuevo.Click += (s, e) => LimpiarCampos();
            flpInput.Controls.Add(btnNuevo);

            dgvSupplier.CellClick += DgvSupplier_CellClick;
        }

        private void DgvSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvSupplier.Rows[e.RowIndex];
            if (row.Cells[0].Value == null) return;

            txtContacto.Texts = row.Cells[0].Value?.ToString() ?? "";
            txtFN.Texts = row.Cells[1].Value?.ToString() ?? "";
            txtSN.Texts = row.Cells[2].Value?.ToString() ?? "";
            txtFA.Texts = row.Cells[3].Value?.ToString() ?? "";
            txtSA.Texts = row.Cells[4].Value?.ToString() ?? "";
            txtAddress.Texts = row.Cells[5].Value?.ToString() ?? "";
            txtTel.Texts = row.Cells[6].Value?.ToString() ?? "";
            txtMail.Texts = row.Cells[7].Value?.ToString() ?? "";

            mrBtnGuardar.Text = "ACTUALIZAR";
            mrBtnGuardar.BackColor = ThemeManager.AccentBlue;
            mrBtnGuardar.BorderColor_ = ThemeManager.AccentBlue;
        }

        private void LimpiarCampos()
        {
            txtContacto.Clear();
            txtFN.Clear();
            txtFA.Clear();
            txtAddress.Clear();
            txtTel.Clear();
            txtMail.Clear();
            txtSN.Clear();
            txtSA.Clear();
            mrBtnGuardar.Text = "GUARDAR";
            mrBtnGuardar.BackColor = ThemeManager.BtnPrimary;
            mrBtnGuardar.BorderColor_ = ThemeManager.AccentPink;
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
            if (InputValidator.HayCamposVacios(txtFN.GetText(), txtFA.GetText(), txtAddress.GetText(), txtTel.GetText(), txtMail.GetText()))
                return;

            if (cboTypeCN.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un proveedor.", "Campos Requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string rucProveedor = cboTypeCN.SelectedValue.ToString();

            if (mrBtnGuardar.Text == "ACTUALIZAR" && !string.IsNullOrWhiteSpace(txtContacto.GetText()))
            {
                ContactoRepository.Actualizar(
                    txtContacto.GetText(), txtFN.GetText(), txtSN.GetText(),
                    txtFA.GetText(), txtSA.GetText(), txtAddress.GetText(),
                    txtTel.GetText(), txtMail.GetText(), rucProveedor
                );
            }
            else
            {
                ContactoRepository.Insertar(
                    txtFN.GetText(), txtSN.GetText(), txtFA.GetText(), txtSA.GetText(),
                    txtAddress.GetText(), txtTel.GetText(), txtMail.GetText(), rucProveedor
                );
            }

            CargarContactos();
            LimpiarCampos();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Legacy — ahora unificado en btnInsertar_Click
        }

        #endregion
    }
}
