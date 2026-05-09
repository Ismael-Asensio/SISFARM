using pj_Pharmacy.DataAccess.Repositories;
using pj_Pharmacy.Utilities;
using System;
using System.Windows.Forms;

namespace pj_Pharmacy.Forms
{
    public partial class Envio : Form
    {
        public Envio()
        {
            InitializeComponent();
            ThemeManager.AplicarTema(this);
            CargarEnvios();
            txtDNI.MaxLength = 15;
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
            if (InputValidator.HayCamposVacios(txtOrigen.Texts, txtDNI.Texts, txtDest.Texts))
                return;

            EnvioRepository.Insertar(txtOrigen.Texts, txtDest.Texts, txtDNI.Texts);
            CargarEnvios();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (InputValidator.HayCamposVacios(txtEnvio.Texts))
                return;

            // Parsear el ID del envío como entero (fix: antes se pasaba como string)
            int idEnvio;
            if (!int.TryParse(txtEnvio.GetText(), out idEnvio))
            {
                MessageBox.Show("El ID del envío debe ser numérico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            EnvioRepository.CambiarEstado(idEnvio);
            CargarEnvios();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (InputValidator.HayCamposVacios(txtEnvio.Texts))
                return;

            int idEnvio;
            if (!int.TryParse(txtEnvio.Texts, out idEnvio))
            {
                MessageBox.Show("El ID del envío debe ser numérico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            EnvioRepository.DarDeBaja(idEnvio);
            CargarEnvios();
        }

        #endregion

        #region Eventos Grid

        private void dgvEnvio_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            txtEnvio.Texts = dgvEnvio.CurrentRow.Cells[0].Value.ToString();
            txtOrigen.Texts = dgvEnvio.CurrentRow.Cells[1].Value.ToString();
            txtDNI.Texts = dgvEnvio.CurrentRow.Cells[2].Value.ToString();
            txtDest.Texts = dgvEnvio.CurrentRow.Cells[3].Value.ToString();
        }

        #endregion
    }
}
