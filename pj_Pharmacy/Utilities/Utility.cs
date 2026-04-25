using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace pj_Pharmacy.Utilities
{
    public class Utility
    {
        public SqlConnection connect = new SqlConnection();

        public Utility(string server, string user, string pass, string database)
        {
            try
            {
                string connectionString = $"Server={server};Database={database};User ID={user};Password={pass}";
                connect = new SqlConnection(connectionString);
                connect.Open();
            }
            catch (Exception)
            {



            }
        }

        #region LISTAS
        public void listarClientesJ(DataGridView GridView1)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataReader leer;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ListClientJ";
            cmd.Connection = connect;


            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);

            GridView1.DataSource = dt;

        }

        public void listarClientesN(DataGridView GridView1)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataReader leer;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ListClientN";
            cmd.Connection = connect;


            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);

            GridView1.DataSource = dt;

        }

        public void listarCompras(DataGridView GridView1)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataReader leer;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ListCompra";
            cmd.Connection = connect;


            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);

            GridView1.DataSource = dt;

        }

        public void listarProductos(DataGridView GridView1)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataReader leer;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ListProd";
            cmd.Connection = connect;


            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);

            GridView1.DataSource = dt;

        }

        public void listarProductosIn(DataGridView GridView1)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataReader leer;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ListProdIn";
            cmd.Connection = connect;


            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);

            GridView1.DataSource = dt;

        }

        public void listarVentas(DataGridView GridView1)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataReader leer;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ListVent";
            cmd.Connection = connect;


            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);

            GridView1.DataSource = dt;

        }

        public void listarEmpleados(DataGridView GridView1)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataReader leer;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ListEmp";
            cmd.Connection = connect;


            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);

            GridView1.DataSource = dt;

        }

        public void listarProveedores(DataGridView GridView1)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataReader leer;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ListSupp";
            cmd.Connection = connect;


            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);

            GridView1.DataSource = dt;

        }


        public void listarContactos(DataGridView GridView1)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataReader leer;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ListCA";
            cmd.Connection = connect;


            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);

            GridView1.DataSource = dt;

        }

        public void listarEnvios(DataGridView GridView1)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataReader leer;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ListEnv";
            cmd.Connection = connect;


            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);

            GridView1.DataSource = dt;

        }
        #endregion


        #region INSERSION


        public void InsertarClienteNat(string dir, string tel, string codDep, string pn, string sn, string pa, string sa, char tpc)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();

                SqlParameter[] param = new SqlParameter[8];
                param[0] = new SqlParameter("@Dir", SqlDbType.NVarChar);
                param[0].Value = dir;
                param[1] = new SqlParameter("@Tel", SqlDbType.NVarChar);
                param[1].Value = tel;
                param[2] = new SqlParameter("@Cd", SqlDbType.NVarChar);
                param[2].Value = codDep;
                param[3] = new SqlParameter("@PN", SqlDbType.NVarChar);
                param[3].Value = pn;
                param[4] = new SqlParameter("@SN", SqlDbType.NVarChar);
                param[4].Value = sn;
                param[5] = new SqlParameter("@PA", SqlDbType.NVarChar);
                param[5].Value = pa;
                param[6] = new SqlParameter("@SA", SqlDbType.NVarChar);
                param[6].Value = sa;
                param[7] = new SqlParameter("@TPC", SqlDbType.Char);
                param[7].Value = tpc;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "NClientNat";
                cmd.Connection = connect;
                cmd.Parameters.AddRange(param);

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds);
            }
            catch (Exception)
            {
                MessageBox.Show("Error en la insercion");
                // Puedes manejar la excepción de alguna manera apropiada para tu aplicación
                return;
            }
        }


        public void InsertarClienteJur(string dir, string tel, string codDep, string pn, string sn, string pa, string sa, string cargo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();

                SqlParameter[] param = new SqlParameter[8];
                param[0] = new SqlParameter("@Dir", SqlDbType.NVarChar);
                param[0].Value = dir;
                param[1] = new SqlParameter("@Tel", SqlDbType.NVarChar);
                param[1].Value = tel;
                param[2] = new SqlParameter("@Cd", SqlDbType.NVarChar);
                param[2].Value = codDep;
                param[3] = new SqlParameter("@PN", SqlDbType.NVarChar);
                param[3].Value = pn;
                param[4] = new SqlParameter("@SN", SqlDbType.NVarChar);
                param[4].Value = sn;
                param[5] = new SqlParameter("@PA", SqlDbType.NVarChar);
                param[5].Value = pa;
                param[6] = new SqlParameter("@SA", SqlDbType.NVarChar);
                param[6].Value = sa;
                param[7] = new SqlParameter("@Cargo", SqlDbType.NVarChar);
                param[7].Value = cargo;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "NClientJur";
                cmd.Connection = connect;
                cmd.Parameters.AddRange(param);

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds);
            }
            catch (Exception)
            {
                MessageBox.Show("Error en la insercion");
                // Puedes manejar la excepción de alguna manera apropiada para tu aplicación
                return;
            }
        }
        public void InsertarEmpleado(String DNI, String PN, String SN, String PA, String SA, String Tel, String IdDep, String IdSuc, String Cargo)
        {

            try
            {
                SqlCommand cmd = new SqlCommand();

                SqlParameter[] param = new SqlParameter[9];
                param[0] = new SqlParameter("@DNI", SqlDbType.VarChar);
                param[0].Value = DNI;
                param[1] = new SqlParameter("@PN", SqlDbType.VarChar);
                param[1].Value = PN;
                param[2] = new SqlParameter("@SN", SqlDbType.VarChar);
                param[2].Value = SN;
                param[3] = new SqlParameter("@PA", SqlDbType.VarChar);
                param[3].Value = PA;
                param[4] = new SqlParameter("@SA", SqlDbType.Char);
                param[4].Value = SA;
                param[5] = new SqlParameter("@Tel", SqlDbType.Char);
                param[5].Value = Tel;
                param[6] = new SqlParameter("@idDep", SqlDbType.Char);
                param[6].Value = IdDep;
                param[7] = new SqlParameter("@idSuc", SqlDbType.Char);
                param[7].Value = IdSuc;
                param[8] = new SqlParameter("@Cargo", SqlDbType.Char);
                param[8].Value = Cargo;


                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "NuevoEmpleado";
                cmd.Connection = connect;
                cmd.Parameters.AddRange(param);

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds);
            }
            catch (Exception)
            {

                MessageBox.Show("Error en la insercion");
                return;
            }


        }

        public void InsertarProveedores(String RUC, String NP, String Dir, String Tel)
        {

            try
            {
                SqlCommand cmd = new SqlCommand();

                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@RUC", SqlDbType.VarChar);
                param[0].Value = RUC;
                param[1] = new SqlParameter("@NP", SqlDbType.VarChar);
                param[1].Value = NP;
                param[2] = new SqlParameter("@Dir", SqlDbType.VarChar);
                param[2].Value = Dir;
                param[3] = new SqlParameter("@Tel", SqlDbType.VarChar);
                param[3].Value = Tel;


                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "NuevosProveedores";
                cmd.Connection = connect;
                cmd.Parameters.AddRange(param);

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds);
            }
            catch (Exception)
            {

                MessageBox.Show("Error en la insercion");
                return;
            }


        }
        public void NuevosEnvios(String Origen, String Destino, String DNI)
        {

            try
            {
                SqlCommand cmd = new SqlCommand();

                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@Origen", SqlDbType.VarChar);
                param[0].Value = Origen;
                param[1] = new SqlParameter("@Destinatario", SqlDbType.VarChar);
                param[1].Value = Destino;
                param[2] = new SqlParameter("@DNI", SqlDbType.VarChar);
                param[2].Value = DNI;



                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "NuevoEnvio";
                cmd.Connection = connect;
                cmd.Parameters.AddRange(param);

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds);
            }
            catch (Exception)
            {

                MessageBox.Show("Error en la insercion");
                return;
            }

        }
        public void InsertarContactos(String PN, String SN, String PA, String SA, String Dir, String Tel, String Mail, String RUC)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();

                SqlParameter[] param = new SqlParameter[8];
                param[0] = new SqlParameter("@PN", SqlDbType.NVarChar);
                param[0].Value = PN;
                param[1] = new SqlParameter("@SN", SqlDbType.NVarChar);
                param[1].Value = SN;
                param[2] = new SqlParameter("@PA", SqlDbType.NVarChar);
                param[2].Value = PA;
                param[3] = new SqlParameter("@SA", SqlDbType.NVarChar);
                param[3].Value = SA;
                param[4] = new SqlParameter("@Dir", SqlDbType.NVarChar);
                param[4].Value = Dir;
                param[5] = new SqlParameter("@Tel", SqlDbType.NVarChar);
                param[5].Value = Tel;
                param[6] = new SqlParameter("@Mail", SqlDbType.NVarChar);
                param[6].Value = Mail;
                param[7] = new SqlParameter("@RUC", SqlDbType.NVarChar);
                param[7].Value = RUC;



                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "NuevosContactos";
                cmd.Connection = connect;
                cmd.Parameters.AddRange(param);

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds);
            }
            catch (Exception)
            {

                MessageBox.Show("Error en la insercion");
                return;
            }
        }



        public void GestionDeCompras(String Nruc, int cc, String cp, float pc)
        {

            try
            {
                SqlCommand cmd = new SqlCommand();

                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@NR", SqlDbType.VarChar);
                param[0].Value = Nruc;
                param[1] = new SqlParameter("@cc", SqlDbType.Int);
                param[1].Value = cc;
                param[2] = new SqlParameter("@CP", SqlDbType.VarChar);
                param[2].Value = cp;
                param[3] = new SqlParameter("@pc", SqlDbType.Float);
                param[3].Value = pc;




                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GestionDeCompras";
                cmd.Connection = connect;
                cmd.Parameters.AddRange(param);

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds);
            }
            catch (Exception)
            {

                MessageBox.Show("Error en la insercion");
                return;
            }

        }
        public void GestionDeVentas(int IdCliente, int Ventaid, int CodigoProducto, int CantidadVendida)
        {

            try
            {
                SqlCommand cmd = new SqlCommand();

                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@IDC", SqlDbType.Int);
                param[0].Value = IdCliente;
                param[1] = new SqlParameter("@VID", SqlDbType.Int);
                param[1].Value = Ventaid;
                param[2] = new SqlParameter("@CP", SqlDbType.Int);
                param[2].Value = CodigoProducto;
                param[3] = new SqlParameter("@cv", SqlDbType.Int);
                param[3].Value = CantidadVendida;




                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GestionarVentas";
                cmd.Connection = connect;
                cmd.Parameters.AddRange(param);

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds);
            }
            catch (Exception)
            {

                MessageBox.Show("Error en la insercion");
                return;
            }


        }
        public void InsertarProductos(String NP, String Desc, float PrecioP, int ExistP, String FecE, String RUC)
        {

            try
            {
                SqlCommand cmd = new SqlCommand();

                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@NP", SqlDbType.VarChar);
                param[0].Value = NP;
                param[1] = new SqlParameter("@Desc", SqlDbType.VarChar);
                param[1].Value = Desc;
                param[2] = new SqlParameter("@PP", SqlDbType.Float);
                param[2].Value = PrecioP;
                param[3] = new SqlParameter("@Exist", SqlDbType.Int);
                param[3].Value = ExistP;
                param[4] = new SqlParameter("@FE", SqlDbType.NVarChar);
                param[4].Value = FecE;
                param[5] = new SqlParameter("@RUC", SqlDbType.NVarChar);
                param[5].Value = RUC;
               

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "NuevoProducto";
                cmd.Connection = connect;
                cmd.Parameters.AddRange(param);

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds);
            }
            catch (Exception)
            {

                MessageBox.Show("Error en la insercion");
                return;
            }

        }
        #endregion

        public DataTable cargarcbo()
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter("ListSupp", connect);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }

        public DataTable Departamentos()
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter("ListDep", connect);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }

        public DataTable Productos()
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter("ListProd", connect);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);

            // Agregar una fila en blanco al inicio del DataTable
            DataRow filaEnBlanco = dt.NewRow();
            filaEnBlanco["CodProd"] = DBNull.Value;
            filaEnBlanco["NombreProd"] = "";  // O cualquier valor que desees mostrar para el producto en blanco
            dt.Rows.InsertAt(filaEnBlanco, 0);

            return dt;

        }

        #region ACTUALIZADORES
        public void ActualizarProducto( String NP, String Desc, float PrecioP, int ExistP, String FecE, int RUC)
        {


            try
            {
                SqlCommand cmd = new SqlCommand();

                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@NP", SqlDbType.VarChar);
                param[0].Value = NP;
                param[1] = new SqlParameter("@Desc", SqlDbType.VarChar);
                param[1].Value = Desc;
                param[2] = new SqlParameter("@PP", SqlDbType.Float);
                param[2].Value = PrecioP;
                param[3] = new SqlParameter("@Exist", SqlDbType.Int);
                param[3].Value = ExistP;
                param[4] = new SqlParameter("@FE", SqlDbType.Char);
                param[4].Value = FecE;
                param[5] = new SqlParameter("@IDP", SqlDbType.Int);
                param[5].Value = RUC;


                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ActualizarProducto";
                cmd.Connection = connect;
                cmd.Parameters.AddRange(param);

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds);
            }
            catch (Exception)
            {

                MessageBox.Show("Error en la actualizacion");
                return;
            }

        }
        public void ActualizarEmpleados( String PN, String SN, String PA, String SA, String Tel, String IdDep, String IdSuc, String Cargo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();

                SqlParameter[] param = new SqlParameter[8];

                param[0] = new SqlParameter("@PN", SqlDbType.VarChar);
                param[0].Value = PN;
                param[1] = new SqlParameter("@SN", SqlDbType.VarChar);
                param[1].Value = SN;
                param[2] = new SqlParameter("@PA", SqlDbType.VarChar);
                param[2].Value = PA;
                param[3] = new SqlParameter("@SA", SqlDbType.Char);
                param[3].Value = SA;
                param[4] = new SqlParameter("@Tel", SqlDbType.Char);
                param[4].Value = Tel;
                param[5] = new SqlParameter("@idDep", SqlDbType.Char);
                param[5].Value = IdDep;
                param[6] = new SqlParameter("@idSuc", SqlDbType.Char);
                param[6].Value = IdSuc;
                param[7] = new SqlParameter("@Cargo", SqlDbType.Char);
                param[7].Value = Cargo;


                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ActualizarEmpleado";
                cmd.Connection = connect;
                cmd.Parameters.AddRange(param);

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds);
            }
            catch (Exception)
            {

                MessageBox.Show("Error en la actualizacion");
                return;
            }

        }
        public void ActualizarClienteNat(String Direccion, String Tel, String CodDep, String PrimerN, String SN, String PA, String SA, char TipoCNatural)
        {


            try
            {
                SqlCommand cmd = new SqlCommand();

                SqlParameter[] param = new SqlParameter[8];
                param[0] = new SqlParameter("@Dir", SqlDbType.NVarChar);
                param[0].Value = Direccion;
                param[1] = new SqlParameter("@Tel", SqlDbType.Char);
                param[1].Value = Tel;
                param[2] = new SqlParameter("@Cd", SqlDbType.Char);
                param[2].Value = CodDep;
                param[3] = new SqlParameter("@PN", SqlDbType.NVarChar);
                param[3].Value = PrimerN;
                param[4] = new SqlParameter("@SN", SqlDbType.NVarChar);
                param[4].Value = SN;
                param[5] = new SqlParameter("@PA", SqlDbType.NVarChar);
                param[5].Value = PA;
                param[6] = new SqlParameter("@SA", SqlDbType.NVarChar);
                param[6].Value = SA;
                param[7] = new SqlParameter("@TPC", SqlDbType.Char);
                param[7].Value = TipoCNatural;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ActClienteNat";
                cmd.Connection = connect;
                cmd.Parameters.AddRange(param);

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds);
            }
            catch (Exception)
            {

                MessageBox.Show("Error en la actualizacion del cliente");
                return;
            }


        }
        public void ActualizarClienteJur( String Direccion, String Tel, String CodDep, String PrimerN, String SN, String PA, String SA, String Cargo)
        {


            try
            {
                SqlCommand cmd = new SqlCommand();

                SqlParameter[] param = new SqlParameter[8];
                param[0] = new SqlParameter("@Dir", SqlDbType.NVarChar);
                param[0].Value = Direccion;
                param[1] = new SqlParameter("@Tel", SqlDbType.Char);
                param[1].Value = Tel;
                param[2] = new SqlParameter("@Cd", SqlDbType.Char);
                param[2].Value = CodDep;
                param[3] = new SqlParameter("@PN", SqlDbType.NVarChar);
                param[3].Value = PrimerN;
                param[4] = new SqlParameter("@SN", SqlDbType.NVarChar);
                param[4].Value = SN;
                param[5] = new SqlParameter("@PA", SqlDbType.NVarChar);
                param[5].Value = PA;
                param[6] = new SqlParameter("@SA", SqlDbType.NVarChar);
                param[6].Value = SA;
                param[7] = new SqlParameter("@Cargo", SqlDbType.NVarChar);
                param[7].Value = Cargo;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ActClienteJur";
                cmd.Connection = connect;
                cmd.Parameters.AddRange(param);

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds);
            }
            catch (Exception)
            {

                MessageBox.Show("Error en la actualizacion del cliente");
                return;
            }

        }
        public void ActualizarProveedores( String RUC, String NP, String Dir, String Tel)
        {


            try
            {
                SqlCommand cmd = new SqlCommand();

                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@RUC", SqlDbType.Char);
                param[0].Value = RUC;
                param[1] = new SqlParameter("@NP", SqlDbType.NVarChar);
                param[1].Value = NP;
                param[2] = new SqlParameter("@Dir", SqlDbType.NVarChar);
                param[2].Value = Dir;
                param[3] = new SqlParameter("@Tel", SqlDbType.Char);
                param[3].Value = Tel;


                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ActualizarProveedores";
                cmd.Connection = connect;
                cmd.Parameters.AddRange(param);

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds);
            }
            catch (Exception)
            {

                MessageBox.Show("Error en la Actualizacion");
                return;
            }


        }
        public void ActualizarContactos(String IdC, String PN, String SN, String PA, String SA, String Dir, String Tel, String Mail, String RUC)
        {

            try
            {
                SqlCommand cmd = new SqlCommand();

                SqlParameter[] param = new SqlParameter[9];
                param[0] = new SqlParameter("@IdC", SqlDbType.Char);
                param[0].Value = IdC;
                param[1] = new SqlParameter("@PN", SqlDbType.NVarChar);
                param[1].Value = PN;
                param[2] = new SqlParameter("@SN", SqlDbType.NVarChar);
                param[2].Value = SN;
                param[3] = new SqlParameter("@PA", SqlDbType.NVarChar);
                param[3].Value = PA;
                param[4] = new SqlParameter("@SA", SqlDbType.BigInt);
                param[4].Value = SA;
                param[5] = new SqlParameter("@Dir", SqlDbType.NVarChar);
                param[5].Value = Dir;
                param[6] = new SqlParameter("@Tel", SqlDbType.Char);
                param[6].Value = Tel;
                param[7] = new SqlParameter("@Mail", SqlDbType.NVarChar);
                param[7].Value = Mail;
                param[8] = new SqlParameter("@RUC", SqlDbType.Char);
                param[8].Value = RUC;



                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ActualizarContactos";
                cmd.Connection = connect;
                cmd.Parameters.AddRange(param);

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds);
            }
            catch (Exception)
            {

                MessageBox.Show("Error en la actualizacion del contacto");
                return;
            }


        }
        public void ActualizarEnvio(String IdEnvio)
        {

            try
            {
                SqlCommand cmd = new SqlCommand();

                SqlParameter[] param = new SqlParameter[9];
                param[0] = new SqlParameter("@IdEnvio", SqlDbType.Bit);
                param[0].Value = IdEnvio;





                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CambiarEstadoEnvio";
                cmd.Connection = connect;
                cmd.Parameters.AddRange(param);

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds);
            }
            catch (Exception)
            {

                MessageBox.Show("Error en la actualizacion del envio");
                return;
            }


        }

        #endregion

        #region DARDEBAJAS
        public void CambiarEstadoProducto(int IdProd)
        {

            try
            {
                SqlCommand cmd = new SqlCommand();

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@CodP", SqlDbType.Int);
                param[0].Value = IdProd;





                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DarBProducto";
                cmd.Connection = connect;
                cmd.Parameters.AddRange(param);

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds);
            }
            catch (Exception)
            {

                MessageBox.Show("Error al dar de baja");
                return;
            }


        }
        public void CambiarEstadoSuc(String IdSuc)
        {

            try
            {
                SqlCommand cmd = new SqlCommand();

                SqlParameter[] param = new SqlParameter[9];
                param[0] = new SqlParameter("@IDS", SqlDbType.Char);
                param[0].Value = IdSuc;





                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DarBSuc";
                cmd.Connection = connect;
                cmd.Parameters.AddRange(param);

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds);
            }
            catch (Exception)
            {

                MessageBox.Show("Error al dar de baja");
                return;
            }


        }
        public void CambiarEstadoEnvio(String IdS)
        {

            try
            {
                SqlCommand cmd = new SqlCommand();

                SqlParameter[] param = new SqlParameter[9];
                param[0] = new SqlParameter("@IDS", SqlDbType.Char);
                param[0].Value = IdS;





                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DarBEnv";
                cmd.Connection = connect;
                cmd.Parameters.AddRange(param);

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds);
            }
            catch (Exception)
            {

                MessageBox.Show("Error al dar de baja");
                return;
            }


        }
        public void CambiarReceta(int IdProd)
        {

            try
            {
                SqlCommand cmd = new SqlCommand();

                SqlParameter[] param = new SqlParameter[9];
                param[0] = new SqlParameter("@IDS", SqlDbType.Int);
                param[0].Value = IdProd;





                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CamRec";
                cmd.Connection = connect;
                cmd.Parameters.AddRange(param);

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds);
            }
            catch (Exception)
            {

                MessageBox.Show("Error al cambiar el producto");
                return;
            }


        }
        #endregion
    }
}


