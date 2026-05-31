using pj_Pharmacy.DataAccess.Repositories;
using pj_Pharmacy.MrControlers;
using pj_Pharmacy.Utilities;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace pj_Pharmacy.Forms
{
    public partial class supplier : Form
    {
        private MrButton mrBtnGuardar;

        public supplier()
        {
            InitializeComponent();
            ConfigurarBotonGuardar();
            ThemeManager.AplicarTema(this);
            txtTel.MaxLength = 8;
            CargarProveedores();
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

            txtRUC.Texts = row.Cells[0].Value?.ToString() ?? "";
            txtName.Texts = row.Cells[1].Value?.ToString() ?? "";
            txtAddress.Texts = row.Cells[2].Value?.ToString() ?? "";
            txtTel.Texts = row.Cells[3].Value?.ToString() ?? "";

            mrBtnGuardar.Text = "ACTUALIZAR";
            mrBtnGuardar.BackColor = ThemeManager.AccentBlue;
            mrBtnGuardar.BorderColor_ = ThemeManager.AccentBlue;
        }

        private void LimpiarCampos()
        {
            txtRUC.Clear();
            txtName.Clear();
            txtAddress.Clear();
            txtTel.Clear();
            mrBtnGuardar.Text = "GUARDAR";
            mrBtnGuardar.BackColor = ThemeManager.BtnPrimary;
            mrBtnGuardar.BorderColor_ = ThemeManager.AccentPink;
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
            if (InputValidator.HayCamposVacios(txtRUC.GetText(), txtName.GetText(), txtAddress.GetText(), txtTel.GetText()))
                return;

            if (mrBtnGuardar.Text == "ACTUALIZAR")
            {
                ProveedorRepository.Actualizar(txtRUC.GetText(), txtName.GetText(), txtAddress.GetText(), txtTel.GetText());
            }
            else
            {
                ProveedorRepository.Insertar(txtRUC.GetText(), txtName.GetText(), txtAddress.GetText(), txtTel.GetText());
            }

            CargarProveedores();
            LimpiarCampos();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Legacy — ahora unificado en btnInsertar_Click
        }

        #endregion
    }
}
