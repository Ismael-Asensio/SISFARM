using pj_Pharmacy.DataAccess.Repositories;
using pj_Pharmacy.Utilities;
using System;
using System.Windows.Forms;

namespace pj_Pharmacy.Forms
{
    public partial class Cliente : Form
    {
        public Cliente()
        {
            InitializeComponent();
            ThemeManager.AplicarTema(this);
            txtTel.MaxLength = 8;
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

            if (InputValidator.HayCamposVacios(txtFN.Texts, txtFA.Texts, txtAddress.Texts, txtTel.Texts))
                return;

            char tipoCliente = cboTypeCN.SelectedItem.ToString() == "Asegurado" ? 'A' : 'R';

            ClienteRepository.InsertarNatural(
                txtAddress.Texts, txtTel.Texts, city,
                txtFN.Texts, txtSN.Texts, txtFA.Texts, txtSA.Texts,
                tipoCliente
            );
            CargarClientesNaturales();
        }

        private void InsertarClienteJuridico(string city)
        {
            if (InputValidator.HayCamposVacios(txtFN.Texts, txtFA.Texts, txtAddress.Texts, txtTel.Texts, txtCargo.Texts))
                return;

            ClienteRepository.InsertarJuridico(
                txtAddress.Texts, txtTel.Texts, city,
                txtFN.Texts, txtSN.Texts, txtFA.Texts, txtSA.Texts,
                txtCargo.Texts
            );
            CargarClientesJuridicos();
        }

        #endregion
    }
}
