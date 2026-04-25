using pj_Pharmacy.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static pj_Pharmacy.Utilities.Utility;

namespace pj_Pharmacy.Forms
{
    public partial class Cliente : Form
    {

        private UtilitiesDGV ut = new UtilitiesDGV();
        private Utility con;
        public Cliente(Utility utility)
        {
            this.con = utility;
            InitializeComponent();
            txtTel.MaxLength = 8;
        }

        #region Funciones Básicas

        private void Cliente_Load(object sender, EventArgs e)
        {

            cboType.Items.Add("Cliente Jurídico");
            cboType.Items.Add("Cliente Natural");

            cboTypeCN.Items.Add("Regular");
            cboTypeCN.Items.Add("Asegurado");

            cboCity.DataSource = con.Departamentos();
            cboCity.DisplayMember = "NombreDep";
            cboCity.ValueMember = "IdDep";
        }

        private void cboType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboType.SelectedItem.ToString() == "Cliente Natural")
            {
                cboTypeCN.Visible = true;
                txtCargo.Visible = false;
                ltClientsN();
            }
            else if (cboType.SelectedItem.ToString() == "Cliente Jurídico")
            {
                txtCargo.Visible = true;
                cboTypeCN.Visible = false;
                ltClientsJ();
            }
        }

        private void Digit_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;

                MessageBox.Show(this, "Ingresa un Dato Correcto", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            }
        }

        private void Letter_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;

                MessageBox.Show(this, "Ingresa un Dato Correcto", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            }
        }

        #endregion

        #region LISTAR
        private void ltClientsN()
        {
            ut.DGV_Format(ref dgvClient);
            con.listarClientesN(dgvClient);
        }

        private void ltClientsJ()
        {
            ut.DGV_Format(ref dgvClient);
            con.listarClientesJ(dgvClient);
        }
        #endregion

        #region InsertarCliente
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            string city = cboCity.SelectedValue.ToString();

            if (cboType.SelectedItem.ToString() == "Cliente Natural")
            {
                cboTypeCN.Visible = true;
                txtCargo.Visible = false;

                if (cboTypeCN.SelectedItem.ToString() == "Regular")
                {

                    if (txtFN.Texts.Equals("") || txtFA.Texts.Equals("") || txtAddress.Texts.Equals("") || txtTel.Texts.Equals("") || cboCity.Texts.Equals(""))
                    {
                        MessageBox.Show("no podemos insertar campos vacios");
                        return;
                    }
                    con.InsertarClienteNat(txtAddress.Texts, txtTel.Texts, city, txtFN.Texts, txtSN.Texts, txtFA.Texts, txtSA.Texts, 'R');
                    ltClientsN();
                }
                else if (cboTypeCN.SelectedItem.ToString() == "Asegurado")
                {
                    if (txtFN.Texts.Equals("") || txtFA.Texts.Equals("") || txtAddress.Texts.Equals("") || txtTel.Texts.Equals("") || cboCity.Texts.Equals(""))
                    {
                        MessageBox.Show("no podemos insertar campos vacios");
                        return;
                    }
                    con.InsertarClienteNat(txtAddress.Texts, txtTel.Texts, city, txtFN.Texts, txtSN.Texts, txtFA.Texts, txtSA.Texts, 'A');
                    ltClientsN();
                }

            }
            else if (cboType.SelectedItem.ToString() == "Cliente Jurídico")
            {
                if (txtFN.Texts.Equals("") || txtFA.Texts.Equals("") || txtAddress.Texts.Equals("") || txtTel.Texts.Equals("") || txtCargo.Texts.Equals("") || cboCity.Texts.Equals(""))
                {
                    MessageBox.Show("no podemos insertar campos vacios");
                    return;
                }
                con.InsertarClienteJur(txtAddress.Texts, txtTel.Texts, city, txtFN.Texts, txtSN.Texts, txtFA.Texts, txtSA.Texts, txtCargo.Texts);
                ltClientsJ();
            }

        }
        #endregion

    }

}
