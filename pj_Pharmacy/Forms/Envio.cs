using pj_Pharmacy.DataAccess.Repositories;
using pj_Pharmacy.MrControlers;
using pj_Pharmacy.Utilities;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace pj_Pharmacy.Forms
{
    public partial class Envio : Form
    {
        private MrButton mrBtnGuardar;

        public Envio()
        {
            InitializeComponent();
            ConfigurarBotonGuardar();
            ThemeManager.AplicarTema(this);
            CargarEnvios();
            txtDNI.MaxLength = 15;
        }

        private void ConfigurarBotonGuardar()
        {
            mrBtnGuardar = ThemeManager.CrearBotonGuardar(btnInsertar, flpInput);
            mrBtnGuardar.Size = new Size(150, 37);

            var btnNuevo = ThemeManager.CrearBotonNuevo();
            btnNuevo.Click += (s, e) => LimpiarCampos();
            flpInput.Controls.Add(btnNuevo);
        }

        private void LimpiarCampos()
        {
            txtEnvio.Clear();
            txtOrigen.Clear();
            txtDNI.Clear();
            txtDest.Clear();
            mrBtnGuardar.Text = "GUARDAR";
            mrBtnGuardar.BackColor = ThemeManager.BtnPrimary;
            mrBtnGuardar.BorderColor_ = ThemeManager.AccentPink;
        }

        #region Carga de Datos

        private void CargarEnvios()
        {
            UtilitiesDGV.FormatearGrid(dgvEnvio);
            EnvioRepository.Listar(dgvEnvio);
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
            if (mrBtnGuardar.Text == "CAMBIAR ESTADO")
            {
                if (InputValidator.HayCamposVacios(txtEnvio.GetText())) return;
                int idEnvio;
                if (!int.TryParse(txtEnvio.GetText(), out idEnvio))
                {
                    MessageBox.Show("El ID del envío debe ser numérico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                EnvioRepository.CambiarEstado(idEnvio);
            }
            else
            {
                if (InputValidator.HayCamposVacios(txtOrigen.GetText(), txtDNI.GetText(), txtDest.GetText()))
                    return;
                EnvioRepository.Insertar(txtOrigen.GetText(), txtDest.GetText(), txtDNI.GetText());
            }

            CargarEnvios();
            LimpiarCampos();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Legacy — ahora unificado en btnInsertar_Click
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Legacy — ahora unificado
        }

        #endregion

        #region Eventos Grid

        private void dgvEnvio_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvEnvio.Rows[e.RowIndex];
            if (row.Cells[0].Value == null) return;

            txtEnvio.Texts = row.Cells[0].Value?.ToString() ?? "";
            txtOrigen.Texts = row.Cells[1].Value?.ToString() ?? "";
            txtDNI.Texts = row.Cells[2].Value?.ToString() ?? "";
            txtDest.Texts = row.Cells[3].Value?.ToString() ?? "";

            mrBtnGuardar.Text = "CAMBIAR ESTADO";
            mrBtnGuardar.BackColor = ThemeManager.AccentBlue;
            mrBtnGuardar.BorderColor_ = ThemeManager.AccentBlue;
        }

        #endregion
    }
}
