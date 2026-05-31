using pj_Pharmacy.DataAccess.Repositories;
using pj_Pharmacy.MrControlers;
using pj_Pharmacy.Utilities;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace pj_Pharmacy.Forms
{
    public partial class Cliente : Form
    {
        private MrButton mrBtnGuardar;

        public Cliente()
        {
            InitializeComponent();
            ConfigurarBotonGuardar();
            ThemeManager.AplicarTema(this);
            txtTel.MaxLength = 8;
        }

        private void ConfigurarBotonGuardar()
        {
            mrBtnGuardar = ThemeManager.CrearBotonGuardar(btnInsertar, flpInput);

            var btnNuevo = ThemeManager.CrearBotonNuevo();
            btnNuevo.Click += (s, e) => LimpiarCampos();
            flpInput.Controls.Add(btnNuevo);

            dgvClient.CellClick += DgvClient_CellClick;
        }

        private void DgvClient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvClient.Rows[e.RowIndex];
            if (row.Cells[0].Value == null) return;

            for (int i = 0; i < row.Cells.Count && i < 7; i++)
            {
                string val = row.Cells[i].Value?.ToString() ?? "";
                switch (i)
                {
                    case 0: break; // ID
                    case 1: txtFN.Texts = val; break;
                    case 2: txtSN.Texts = val; break;
                    case 3: txtFA.Texts = val; break;
                    case 4: txtSA.Texts = val; break;
                    case 5: txtAddress.Texts = val; break;
                    case 6: txtTel.Texts = val; break;
                }
            }

            mrBtnGuardar.Text = "ACTUALIZAR";
            mrBtnGuardar.BackColor = ThemeManager.AccentBlue;
            mrBtnGuardar.BorderColor_ = ThemeManager.AccentBlue;
        }

        private void LimpiarCampos()
        {
            txtFN.Clear();
            txtSN.Clear();
            txtFA.Clear();
            txtSA.Clear();
            txtAddress.Clear();
            txtTel.Clear();
            txtCargo.Clear();
            mrBtnGuardar.Text = "GUARDAR";
            mrBtnGuardar.BackColor = ThemeManager.BtnPrimary;
            mrBtnGuardar.BorderColor_ = ThemeManager.AccentPink;
        }

        #region Carga de Datos

        private void Cliente_Load(object sender, EventArgs e)
        {
            cboType.Items.Add("Cliente Jurídico");
            cboType.Items.Add("Cliente Natural");

            cboTypeCN.Items.Add("Regular");
            cboTypeCN.Items.Add("Asegurado");

            cboCity.DataSource = CatalogoRepository.ObtenerDepartamentos();
            cboCity.DisplayMember = "NombreDep";
            cboCity.ValueMember = "IdDep";
        }

        private void cboType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboType.SelectedItem == null) return;

            if (cboType.SelectedItem.ToString() == "Cliente Natural")
            {
                cboTypeCN.Visible = true;
                txtCargo.Visible = false;
                CargarClientesNaturales();
            }
            else if (cboType.SelectedItem.ToString() == "Cliente Jurídico")
            {
                txtCargo.Visible = true;
                cboTypeCN.Visible = false;
                CargarClientesJuridicos();
            }
        }

        private void CargarClientesNaturales()
        {
            UtilitiesDGV.FormatearGrid(dgvClient);
            ClienteRepository.ListarNaturales(dgvClient);
        }

        private void CargarClientesJuridicos()
        {
            UtilitiesDGV.FormatearGrid(dgvClient);
            ClienteRepository.ListarJuridicos(dgvClient);
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

        #region Insertar Cliente

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (cboType.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un tipo de cliente.", "Campos Requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string city = cboCity.SelectedValue.ToString();

            if (cboType.SelectedItem.ToString() == "Cliente Natural")
            {
                InsertarClienteNatural(city);
            }
            else if (cboType.SelectedItem.ToString() == "Cliente Jurídico")
            {
                InsertarClienteJuridico(city);
            }
        }

        private void InsertarClienteNatural(string city)
        {
            cboTypeCN.Visible = true;
            txtCargo.Visible = false;

            if (cboTypeCN.SelectedItem == null) return;

            if (InputValidator.HayCamposVacios(txtFN.GetText(), txtFA.GetText(), txtAddress.GetText(), txtTel.GetText()))
                return;

            char tipoCliente = cboTypeCN.SelectedItem.ToString() == "Asegurado" ? 'A' : 'R';

            ClienteRepository.InsertarNatural(
                txtAddress.GetText(), txtTel.GetText(), city,
                txtFN.GetText(), txtSN.GetText(), txtFA.GetText(), txtSA.GetText(),
                tipoCliente
            );
            CargarClientesNaturales();
            LimpiarCampos();
        }

        private void InsertarClienteJuridico(string city)
        {
            if (InputValidator.HayCamposVacios(txtFN.GetText(), txtFA.GetText(), txtAddress.GetText(), txtTel.GetText(), txtCargo.GetText()))
                return;

            ClienteRepository.InsertarJuridico(
                txtAddress.GetText(), txtTel.GetText(), city,
                txtFN.GetText(), txtSN.GetText(), txtFA.GetText(), txtSA.GetText(),
                txtCargo.GetText()
            );
            CargarClientesJuridicos();
            LimpiarCampos();
        }

        #endregion
    }
}
