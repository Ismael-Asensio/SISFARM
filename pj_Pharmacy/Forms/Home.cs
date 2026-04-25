using pj_Pharmacy.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pj_Pharmacy.Forms
{

    public partial class Home : Form
    {
        private Utility ut;

        public string NombreUsuario
        {
            get { return lblName.Text; }
            set { lblName.Text = value; }
        }

        public string RolUsuario
        {
            get { return lblCargo.Text; }
            set { lblCargo.Text = value; }
        }

        public Button ProductButton
        {
            get { return btnProduct; }
        }

        public Button ConButton
        {
            get { return btnCon; }
        }

        public Button SupplierButton
        {
            get { return btnSupplier; }
        }

        public Button UserButton
        {
            get { return btnUser; }
        }

        public Home(Utility utility)
        {
            ut = utility;
            InitializeComponent();
        }

        #region Funciones Basicas y Movimiento

        private Form ActiveForm;
        private void OpenForm (Form OForm)
        {
            if(ActiveForm != null)
            {
                ActiveForm.Close();
            }

            ActiveForm = OForm;
            OForm.TopLevel = false;
            OForm.Dock = DockStyle.Fill;
            pContainer.Controls.Add(OForm);
            pContainer.Tag = OForm;
            OForm.FormBorderStyle = FormBorderStyle.None;
            OForm.BringToFront();
            OForm.Show();

            foreach (Control control in OForm.Controls)
            {
                control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                control.Dock = DockStyle.Fill;
            }

        }

        private void pMinimized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pMaximized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            pRestaurar.Visible = true;
            pMaximized.Visible = false;
        }

        private void pExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            pRestaurar.Visible = false;
            pMaximized.Visible = true;
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            OpenForm(new Sell(ut));
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            OpenForm(new Buy(ut));
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            OpenForm(new Users(ut));
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            OpenForm(new supplier(ut));
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            OpenForm(new Products(ut));
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            OpenForm(new Cliente(ut));
        }

        private void btnEnvio_Click(object sender, EventArgs e)
        {
            OpenForm(new Envio(ut));
        }

        private void btnCon_Click(object sender, EventArgs e)
        {
            OpenForm(new Assesor(ut));
        }



        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wMsg, int wParam, int lParam);

        private void pHome_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (ActiveForm != null)
            {
                ActiveForm.Close();
                ActiveForm = null;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro de Salir?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void Hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        #endregion

    }
}
