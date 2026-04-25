using pj_Pharmacy.Services;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace pj_Pharmacy.Forms
{
    public partial class Login : Form
    {
        private int intentosFallidos = 0;
        private const int MAX_INTENTOS = 3;
        private Timer timerBloqueo;

        public Login()
        {
            InitializeComponent();
            ConfigurarTimerBloqueo();
        }

        #region Funciones Basicas

        private void pMinimized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wMsg, int wParam, int lParam);

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        #endregion

        #region Autenticación

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            LoginResult resultado = AuthService.Login(txtUser.Texts, txtPassword.Texts);

            if (resultado.Exitoso)
            {
                intentosFallidos = 0;
                AbrirHome();
            }
            else
            {
                Cursor.Current = Cursors.Default;
                intentosFallidos++;
                txtUser.Clear();
                txtPassword.Clear();
                MostrarError(resultado.MensajeError);

                if (intentosFallidos >= MAX_INTENTOS)
                {
                    BloquearLogin();
                }
            }
        }

        private void AbrirHome()
        {
            Home home = new Home();
            home.FormClosed += Logout;
            home.Show();
            this.Hide();
        }

        private void Logout(object sender, FormClosedEventArgs e)
        {
            AuthService.Logout();
            txtUser.Clear();
            txtPassword.Clear();
            lblErrorMessage.Visible = false;
            this.Show();
            txtUser.Focus();
        }

        #endregion

        #region UI Helpers

        private void MostrarError(string msg)
        {
            lblErrorMessage.Text = "   " + msg;
            lblErrorMessage.Visible = true;
        }

        /// <summary>
        /// Configura el timer que desbloquea el login después de 3 segundos.
        /// Reemplaza Thread.Sleep(3000) que bloqueaba la UI.
        /// </summary>
        private void ConfigurarTimerBloqueo()
        {
            timerBloqueo = new Timer();
            timerBloqueo.Interval = 3000;
            timerBloqueo.Tick += (s, ev) =>
            {
                btnLogin.Enabled = true;
                intentosFallidos = 0;
                timerBloqueo.Stop();
            };
        }

        private void BloquearLogin()
        {
            btnLogin.Enabled = false;
            timerBloqueo.Start();
        }

        #endregion
    }
}
