using pj_Pharmacy.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace pj_Pharmacy.Forms
{
    public partial class Login : Form
    {
        private string userName;
        private string userRole;

        public Login()
        {
            InitializeComponent();
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

        int cont = 3;




        Utility ut;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Cursor.Current = Cursors.WaitCursor;

            if (txtUser.Texts.Equals("") || txtPassword.Texts.Equals(""))
            {
                msgerror("HAY CAMPOS VACÍOS");
                return;
            }

            string servidor = Environment.MachineName;
            string usuario = txtUser.Texts;
            string contraseña = txtPassword.Texts;
            string baseDatos = "Pharmacy";   // O puedes obtenerla dinámicamente

            // Crear una instancia de Utility con la cadena de conexión dinámica
            ut = new Utility(servidor, usuario, contraseña, baseDatos);

            if (this.ut.connect.State == ConnectionState.Open)
            {

                VerificarRoles(txtUser.Texts);

            }
            else
            {
                Cursor.Current = Cursors.Default;
                --cont;

                txtUser.Clear();
                txtPassword.Clear();
                msgerror("USUARIO O CONTRASEÑA INCORRECTOS");
                if (cont == 0)
                {
                    cont = 3;
                    btnLogin.Enabled = false;
                    Thread.Sleep(3000);
                    btnLogin.Enabled = true;

                }


            }

        }


        private void msgerror(string msg)
        {
            lblErrorMessage.Text = "   " + msg;
            lblErrorMessage.Visible = true;
        }

        private void logout(object sender, FormClosedEventArgs e)
        {
            txtUser.Clear();
            txtPassword.Clear();
            lblErrorMessage.Visible = false;
            this.Show();
            txtUser.Focus();
        }

        private void VerificarRoles(string usuario)
        {
            // Consulta para obtener roles del usuario
            string query = "SELECT r.name " +
                "FROM sys.server_role_members m " +
                "INNER JOIN sys.server_principals p ON m.member_principal_id = p.principal_id " +
                "INNER JOIN sys.server_principals r ON m.role_principal_id = r.principal_id " +
                "WHERE p.name = @Usuario";

            using (SqlCommand cmd = new SqlCommand(query, ut.connect))
            {
                cmd.Parameters.AddWithValue("@Usuario", usuario);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        userName = usuario;
                        userRole = reader["name"].ToString();
                        // Abre el formulario correspondiente según el rol
                        if (userRole.Equals("sysadmin"))
                        {
                            AbrirFormularioDbDdlAdmin();
                            return;
                        }
                        else if (userRole.Equals("processadmin"))
                        {
                            AbrirFormularioSysAdmin();

                            return;
                        }
                        // Agrega más condiciones según sea necesario para otros roles
                    }
                }
            }
        }

        private void AbrirFormularioSysAdmin()
        {
            Home H = new Home(ut);
            H.NombreUsuario =  userName;
            H.RolUsuario = userRole;

            // Deshabilitar botones según el rol
            H.ProductButton.Enabled = false;
            H.ConButton.Enabled = false;
            H.SupplierButton.Enabled = false;
            H.UserButton.Enabled = false;

            H.Show();
            H.FormClosed += logout;
            this.Hide();
        }

        private void AbrirFormularioDbDdlAdmin()
        {
            Home H = new Home(ut);
            H.NombreUsuario = userName;
            H.RolUsuario = userRole;
            H.Show();
            H.FormClosed += logout;
            this.Hide();
        }


    }
}
