using pj_Pharmacy.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace pj_Pharmacy.Forms
{
    public partial class Products : Form
    {
        private UtilitiesDGV ut = new UtilitiesDGV();
        private Utility con;
        public Products(Utility utility)
        {
            this.con = utility;
            InitializeComponent();
            ltBuy();
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

        #endregion

        private void ltBuy()
        {
            ut.DGV_Format(ref dgvProducts);
            con.listarProductos(dgvProducts);
        }

        private void ltBuyIn()
        {
            ut.DGV_Format(ref dgvProducts);
            con.listarProductosIn(dgvProducts);
        }
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (txtName.Texts.Equals("") || txtDesc.Texts.Equals("") || txtCantidad.Texts.Equals("") || txtPrice.Texts.Equals("") || txtFecE.Texts.Equals("") || cboSupplier.Equals(""))
            {
                MessageBox.Show("no podemos insertar campos vacios");
                return;
            }

            string rucProveedor = cboSupplier.SelectedValue.ToString();

            con.InsertarProductos(txtName.Texts, txtDesc.Texts, txtPrice.GetIntegerValueUsingIntParse(),txtCantidad.GetIntegerValueUsingIntParse(),txtFecE.Texts, rucProveedor);

            ltBuy();

            txtCantidad.Clear();
            txtDesc.Clear();
            txtFecE.Clear();
            txtName.Clear();
            txtPrice.Clear();

        }

        private void Products_Load(object sender, EventArgs e)
        {
            cboSupplier.DataSource = con.cargarcbo();
            cboSupplier.DisplayMember = "Nombreprov";
            cboSupplier.ValueMember = "RUC";
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCod.Texts = dgvProducts.CurrentRow.Cells[0].Value.ToString();
            txtName.Texts = dgvProducts.CurrentRow.Cells[1].Value.ToString();
            txtDesc.Texts = dgvProducts.CurrentRow.Cells[2].Value.ToString();
            txtCantidad.Texts = dgvProducts.CurrentRow.Cells[3].Value.ToString();
            txtPrice.Texts = dgvProducts.CurrentRow.Cells[4].Value.ToString();
            txtFecE.Texts = dgvProducts.CurrentRow.Cells[7].Value.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            con.ActualizarProducto(txtName.GetText(), txtDesc.GetText(), txtPrice.GetFloatValueUsingFloatParse(),
                                    txtCantidad.GetIntegerValueUsingIntParse(), txtFecE.GetText(),
                                    txtCod.GetIntegerValueUsingIntParse());
            ltBuy();

            // Clearing the custom TextBox
            txtCantidad.Clear();
            txtDesc.Clear();
            txtFecE.Clear();
            txtName.Clear();
            txtPrice.Clear();


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           
            if (txtCod.GetText()=="")
            {
                MessageBox.Show("no podemos insertar campos vacios");
                return;
            }
            con.CambiarEstadoProducto(txtCod.GetIntegerValueUsingIntParse());
            ltBuy();
            txtCantidad.Clear();
            txtDesc.Clear();
            txtFecE.Clear();
            txtName.Clear();
            txtPrice.Clear();

        }

        private void C_Inactivos_CheckedChanged(object sender, EventArgs e)
        {
            ltBuyIn();
        }

        private void C_Activos_CheckedChanged(object sender, EventArgs e)
        {
            ltBuy();
        }
    }
}
