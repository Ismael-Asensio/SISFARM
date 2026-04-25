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
    public partial class Sell : Form
    {
        private UtilitiesDGV ut = new UtilitiesDGV();
        private Utility con;
        public Sell(Utility utility)
        {
            this.con = utility;
            InitializeComponent();
            ltSell();
        }

        private void Digit_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;

                MessageBox.Show(this, "Ingresa un Dato Correcto", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            }
        }

        private void ltSell()
        {
            ut.DGV_Format(ref dgvSell);
            con.listarVentas(dgvSell);
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {

            int CodProd = int.Parse(cboProducts.SelectedValue.ToString());
            if (CodProd.Equals("") || txtClient.Texts.Equals("") || txtSeller.Texts.Equals("") || txtCantidad.Texts.Equals("") )
            {
                MessageBox.Show("no podemos insertar campos vacios");
                return;
            }

            con.GestionDeVentas(txtClient.GetIntegerValueUsingIntParse(), txtSeller.GetIntegerValueUsingIntParse(), CodProd, txtCantidad.GetIntegerValueUsingIntParse());
            ltSell();
            txtClient.Clear();
            txtSeller.Clear();
            txtCantidad.Clear();
            txtSeller.Clear();

        }

        private void Sell_Load(object sender, EventArgs e)
        {

            cboProducts.DataSource = con.Productos();
            cboProducts.DisplayMember = "NombreProd";
            cboProducts.ValueMember = "CodProd";


        }
    }
}
