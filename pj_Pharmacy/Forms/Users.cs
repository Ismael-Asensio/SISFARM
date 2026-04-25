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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace pj_Pharmacy.Forms
{
    public partial class Users : Form
    {
        private UtilitiesDGV ut = new UtilitiesDGV();
        private Utility con;
        public Users(Utility utility)
        {
            this.con = utility;
            InitializeComponent();
            txtDNI.MaxLength = 15;
            txtTel.MaxLength = 8;
            ltEmployee();

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

        private void DNI_Validation(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true;

                MessageBox.Show("No puedes ingresar más de 15 dígitos o \n" + " Ingresa un valor correcto", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }
        }

        private void ltEmployee()
        {
            ut.DGV_Format(ref dgvUser);
            con.listarEmpleados(dgvUser);
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (txtFN.Texts.Equals("") || txtFA.Texts.Equals("") || txtTel.Texts.Equals("") || cboCity.Texts.Equals(""))
            {
                MessageBox.Show("no podemos insertar campos vacios");
                return;
            }


            con.InsertarEmpleado(txtDNI.Texts,
                                txtFN.Texts,
                                txtSN.Texts,
                                txtFA.Texts,
                                txtSA.Texts,
                                 txtTel.Texts,
                                 cboCity.Texts,
                                 txtSuc.Texts,
                                 txtCargo.Texts
                                 );
            ltEmployee();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string city = cboCity.SelectedValue.ToString();
            if (txtFN.Texts.Equals("") || txtFA.Texts.Equals("") || txtTel.Texts.Equals("") || cboCity.Texts.Equals(""))
            {
                MessageBox.Show("no podemos insertar campos vacios");
                return;
            }


            con.ActualizarEmpleados(
                                txtFN.Texts,
                                txtSN.Texts,
                                txtFA.Texts,
                                txtSA.Texts,
                                 txtTel.Texts,
                                 city,
                                 txtSuc.Texts,
                                 txtCargo.Texts
                                 );
            ltEmployee();
        }

        private void Users_Load(object sender, EventArgs e)
        {
            cboCity.DataSource = con.Departamentos();
            cboCity.DisplayMember = "NombreDep";
            cboCity.ValueMember = "IdDep";
        }
    }
}
