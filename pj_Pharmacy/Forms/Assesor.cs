using pj_Pharmacy.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace pj_Pharmacy.Forms
{
    public partial class Assesor : Form
    {
        private UtilitiesDGV ut = new UtilitiesDGV();
        private Utility con;
        public Assesor(Utility utility)
        {
            this.con = utility;
            InitializeComponent();
            ltContact();
            txtTel.MaxLength = 8;
        }

        #region Funciones Básicas

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
        private void ltContact()
        {
            ut.DGV_Format(ref dgvSupplier);
            con.listarContactos(dgvSupplier);
        }

        private void btnInsertar_Click(object sender, EventArgs e)

        {
            if (txtFN.Texts.Equals("") || txtFA.Texts.Equals("") || txtAddress.Texts.Equals("") || txtTel.Texts.Equals("") || txtMail.Texts.Equals("") || cboTypeCN.Equals(""))
            {
                MessageBox.Show("no podemos insertar campos vacios");
                return;
            }

            string rucProveedor = cboTypeCN.SelectedValue.ToString();

            con.InsertarContactos(txtFN.Texts, txtSN.Texts, txtFA.Texts, txtSA.Texts, txtAddress.Texts, txtTel.Texts, txtMail.Texts, rucProveedor);
            ltContact();
            txtFN.Clear();
            txtFA.Clear();
            txtAddress.Clear();
            txtTel.Clear();
            txtMail.Clear();
            txtSN.Clear();
            txtSA.Clear();

        }

        private void Assesor_Load(object sender, EventArgs e)
        {
            cboTypeCN.DataSource = con.cargarcbo();
            cboTypeCN.DisplayMember = "Nombreprov";
            cboTypeCN.ValueMember = "RUC";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtFN.Texts.Equals("") || txtFA.Texts.Equals("") || txtAddress.Texts.Equals("") || txtTel.Texts.Equals("") || txtMail.Texts.Equals("") || cboTypeCN.Equals(""))
            {
                MessageBox.Show("no podemos insertar campos vacios");
                return;
            }

            string rucProveedor = cboTypeCN.SelectedValue.ToString();

            con.ActualizarContactos(txtContacto.Texts,txtFN.Texts, txtSN.Texts, txtFA.Texts, txtSA.Texts, txtAddress.Texts, txtTel.Texts, txtMail.Texts, rucProveedor);
            ltContact();
            txtFN.Clear();
            txtFA.Clear();
            txtAddress.Clear();
            txtTel.Clear();
            txtMail.Clear();
            txtSN.Clear();
            txtSA.Clear();
        }
    }


    }
