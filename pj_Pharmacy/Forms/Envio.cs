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
    public partial class Envio : Form
    {
        private UtilitiesDGV ut = new UtilitiesDGV();
        private Utility con;
        public Envio(Utility utility)
        {
            this.con = utility;
            InitializeComponent();
            ltContact();
            txtDNI.MaxLength = 15;
        }

        #region FUNCIONES BASICAS
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
        #endregion

        private void ltContact()
        {
            ut.DGV_Format(ref dgvEnvio);
            con.listarEnvios(dgvEnvio);
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (txtOrigen.Texts.Equals("") || txtDNI.Texts.Equals("") || txtDest.Texts.Equals("") )
            {
                MessageBox.Show("no podemos insertar campos vacios");
                return;
            }

            con.NuevosEnvios(txtOrigen.Texts, txtDest.Texts, txtDNI.Texts);
            ltContact();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtEnvio.Texts.Equals("") )
            {
                MessageBox.Show("no podemos insertar campos vacios");
                return;
            }

            con.ActualizarEnvio(txtEnvio.GetText());
            ltContact();
        }

        private void dgvEnvio_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtEnvio.Texts = dgvEnvio.CurrentRow.Cells[0].Value.ToString();
            txtOrigen.Texts = dgvEnvio.CurrentRow.Cells[1].Value.ToString();
            txtDNI.Texts = dgvEnvio.CurrentRow.Cells[2].Value.ToString();
            txtDest.Texts = dgvEnvio.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtEnvio.Texts.Equals(""))
            {
                MessageBox.Show("no podemos insertar campos vacios");
                return;
            }

            con.ActualizarEnvio(txtEnvio.Texts);
            ltContact();
        }
    }
}
