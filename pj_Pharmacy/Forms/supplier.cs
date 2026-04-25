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

namespace pj_Pharmacy.Forms
{
    public partial class supplier : Form
    {
        private UtilitiesDGV ut = new UtilitiesDGV();
        private Utility con;
        public supplier(Utility utility)
        {
            this.con = utility;
            InitializeComponent();
            txtTel.MaxLength = 8;
            ltSupply();
        }

        private void Digit_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;

                MessageBox.Show(this, "Ingresa un Dato Correcto", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            }
        }

        private void ltSupply()
        {
            ut.DGV_Format(ref dgvSupplier);
            con.listarProveedores(dgvSupplier);
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (txtRUC.Texts.Equals("") || txtName.Texts.Equals("") || txtAddress.Texts.Equals("") || txtTel.Texts.Equals(""))
            {
                MessageBox.Show("no podemos insertar campos vacios");
                return;
            }

            con.InsertarProveedores(txtRUC.Texts, txtName.Texts, txtAddress.Texts, txtTel.Texts);
            ltSupply();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtRUC.Texts.Equals("") || txtName.Texts.Equals("") || txtAddress.Texts.Equals("") || txtTel.Texts.Equals(""))
            {
                MessageBox.Show("no podemos insertar campos vacios");
                return;
            }

            con.ActualizarProveedores(txtRUC.Texts, txtName.Texts, txtAddress.Texts, txtTel.Texts);
            ltSupply();
        }
    }
}
