using pj_Pharmacy.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pj_Pharmacy.Forms
{
    public partial class Buy : Form
    {
        private UtilitiesDGV ut = new UtilitiesDGV();
        private Utility con;
        public Buy(Utility utility)
        {
            this.con = utility;
            InitializeComponent();
            ltBuy();
        }

        private void Digit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;

                MessageBox.Show("Ingresa un Dato Correcto", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            }
        }


        private void ltBuy()
        {
            ut.DGV_Format(ref dgvBuys);
            con.listarCompras(dgvBuys);
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            string rucProveedor = cboSupplier.SelectedValue.ToString();

            if (txtCodProd.Texts.Equals("") || txtCantidad.Texts.Equals("") || txtPrecio.Texts.Equals("") || cboSupplier.Texts.Equals(""))
            {
                MessageBox.Show("no podemos insertar campos vacios");
                return;
            }

            con.GestionDeCompras(rucProveedor, txtCantidad.GetIntegerValueUsingIntParse(),txtCodProd.Texts, txtPrecio.GetFloatValueUsingFloatParse());
            ltBuy();
        }

        private void Buy_Load(object sender, EventArgs e)
        {
            cboSupplier.DataSource = con.cargarcbo();
            cboSupplier.DisplayMember = "Nombreprov";
            cboSupplier.ValueMember = "RUC";
        }
    }
}
